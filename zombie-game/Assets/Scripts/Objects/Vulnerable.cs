using System;
using UnityEngine;

namespace ZSG.Objects
{
    public class Vulnerable : MonoBehaviour
    {
        public event Action<float> DamageReceived;

        [SerializeField]
        private SurfaceType surface;
        [SerializeField]
        private float damageMultiplier = 1f;


        public SurfaceType Surface
        {
            get
            {
                return surface;
            }
        }


        public void DealDamage(float hp)
        {
            DamageReceived.Call(hp * damageMultiplier);
        }
    }
}
