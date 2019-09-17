using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.Weapons;
using FactorySpace;
using UnityEngine.Events;

namespace Tanks
{
    //TODO: add Idestractable element to comunicate with projectiles and have GET and SET methods
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Tank : MonoBehaviour, IDamageable, ISpawnable
    {

        #region Movement
        bool isDestroying = false;
        protected string MaterialName;

        protected Rigidbody rb;
        protected float speed;

        protected Vector3 currentDirection;
        //TODO: ramake to method
        public virtual Vector3 CurrentDirection
        {
            get => currentDirection;
            set => currentDirection = value;
        }
        #endregion

        #region Weapon
        protected Weapon currentWeapon;
        protected Factory weaponFactory;
        protected WeaponsTypes weaponType;
        public Vector3 TowerPosition { get => transform.position + Vector3.up * transform.localScale.y / 2; }


        #endregion

        #region Health
        protected int maxArmor;
        protected int armor;
        public int Armor => armor;

        public Transform Type => transform;

        public virtual void ReceiveDamage(int _damage)
        {
            armor -= _damage;
            if (armor <= 0 && !isDestroying)
            {
                isDestroying = true;
                Die();
            }
        }
        public virtual void Die()
        {
            Destroy(currentWeapon.gameObject);
            Destroy(gameObject);
        }
        #endregion

        #region Methods

        protected abstract void InitValues();

        protected virtual void Move()
        {
            Vector3 _nextPosition = transform.position + rb.velocity*Time.deltaTime;
            if (!CheckBorders(_nextPosition))
            {
                rb.velocity = CurrentDirection.normalized * speed;
            }

            if (currentDirection != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(currentDirection);
        }

        public virtual void Shoot()
        {
            if(currentWeapon.canShoot)
                currentWeapon.Use();
        }

        protected virtual bool CheckBorders(Vector3 _nextPosition)
        {
            Vector2 _borders = GameController.Instance.MapSize / 2 - new Vector2(transform.localScale.x, transform.localScale.z)/2;
            if (Mathf.Abs(_nextPosition.x) > _borders.x)
            {
                int dirCoef = -1 * (int)(Mathf.Abs(_nextPosition.x) / _nextPosition.x);
                transform.position = new Vector3(dirCoef * _borders.x, transform.position.y, transform.position.z);
                return true;
            }
            if (Mathf.Abs(_nextPosition.z) > _borders.y)
            {
                int dirCoef = -1 * (int)(Mathf.Abs(_nextPosition.z) / _nextPosition.z);
                transform.position = new Vector3(transform.position.x, transform.position.y, dirCoef * _borders.y);
                return true;
            }
            return false;
        }

        protected virtual void SpawnTower()
        {
            weaponFactory = FactoryProducer.GetFactory(FactoryProductType.Weapons);
            currentWeapon = weaponFactory.GetProduct((int)weaponType).Type.GetComponent<Weapon>();
            currentWeapon.Init(this);
        }

        protected virtual void SwitchMaterial()
        {
            Material _mat = Resources.Load(MaterialName) as Material;
            Renderer _renderer = GetComponent<Renderer>();
            _renderer.sharedMaterial = _mat;
        }
        #endregion

        #region BehaviourMethods
        protected virtual void Start()
        {
            rb = GetComponent<Rigidbody>();
            InitValues();
            SpawnTower();
            armor = maxArmor;
            SwitchMaterial();
        }

        protected virtual void Update()
        {
            Move();
        }

        #endregion
    }
}
