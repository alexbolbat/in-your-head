using System;
using UnityEngine;

namespace NPC
{
    public class Weapon : MonoBehaviour
    {
        public event Action<float> DamageMade;

        [SerializeField]
        protected float distance = 1f;
        [SerializeField]
        protected float damage = 1f;
        [SerializeField]
        protected float fireRate = 1f;

        public float Distance
        {
            get
            {
                return distance;
            }
        }

        public virtual void Attack()
        {
        }

        public virtual void Stop()
        {
        }
    }
}
