using System;
using UnityEngine;

namespace ZSG.Objects
{
    public class Vulnerable : MonoBehaviour
    {
        public Action<float> DamageReceived;

        public void DealDamage(float hp)
        {
            DamageReceived.Call(hp);
        }
    }
}
