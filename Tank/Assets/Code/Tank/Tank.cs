using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public abstract class Tank : MonoBehaviour
    {
        private float nextUpdateTime = 0f;
        [SerializeField]
        private float updateDelay = 0.2f;

        protected int armor;
        abstract public int Armor { get; set; }

        protected abstract void Move();
        protected abstract void Shoot();

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

        protected void Update()
        {
            if (Time.time > nextUpdateTime)
            {
                Move();
                nextUpdateTime = Time.time + updateDelay;
            }
        }

        protected abstract void Die();
    }
}
