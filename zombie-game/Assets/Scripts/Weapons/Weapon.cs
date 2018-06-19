using System;
using UnityEngine;

namespace ZSG.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField]
        protected float distance = 1f;
        [SerializeField]
        protected float damage = 1f;

        public float Distance
        {
            get
            {
                return distance;
            }
        }

        public abstract void Attack();

        public abstract void Stop();
    }
}
