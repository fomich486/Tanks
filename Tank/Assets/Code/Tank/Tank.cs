using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.Weapons;

namespace Tanks
{
    public abstract class Tank : MonoBehaviour
    {
        #region Movement
        private float nextUpdateTime = 0f;
        [SerializeField]
        protected float updateDelay = 0.2f;

        protected Vector3 currentDirection;
        public virtual Vector3 CurrentDirection
        {
            get => currentDirection;
            set => currentDirection = value;
        }
        #endregion

        #region Weapon
        protected Weapon currentWeapon;
        protected bool canShoot = true;
        public Vector3 TowerPosition { get => transform.position + Vector3.up * transform.localScale.y / 2; }
        #endregion

        #region Health
        protected int armor;
        public virtual int Armor
        {
            get => armor;
            set
            {
                if (armor <= 0)
                    Die();
            }
        }
        #endregion

        #region Methods

        protected virtual void Move()
        {
            Vector3 _nextPosition = transform.position + CurrentDirection;
            if (!CheckBorders(_nextPosition)) // TODO: add checker for filled tile
            {
                transform.position = _nextPosition;
            }

            if (currentDirection != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(currentDirection);
        }

        public virtual void Shoot()
        {
            if(canShoot)
                currentWeapon.Use();
        }

        protected abstract void Die();

        protected virtual bool CheckBorders(Vector3 _nextPosition)
        {
            Vector2 _borders = GameController.Instance.MapSize / 2 - Vector2.one * 0.5f;//0.5f - tileSize
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
            GameObject _weapon = Resources.Load("Tower") as GameObject;
            currentWeapon = Instantiate(_weapon.GetComponent<Weapons.Weapon>(), TowerPosition, Quaternion.identity) as Weapons.Weapon;
            currentWeapon.Init(this);
        }
        #endregion

        #region BehaviourMethods
        protected virtual void Start()
        {
            SpawnTower();
        }

        protected virtual void Update()
        {
            if (Time.time > nextUpdateTime)
            {
                Move();
                nextUpdateTime = Time.time + updateDelay;
            }
        }
        #endregion
    }
}
