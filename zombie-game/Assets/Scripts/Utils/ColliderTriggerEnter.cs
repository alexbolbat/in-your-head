using System;
using UnityEngine;

namespace ZSG.Utils
{
    public class ColliderTriggerEnter : MonoBehaviour
    {
        public event Action<Collider> TriggerEntered;

        private void OnTriggerEnter(Collider other)
        {
            TriggerEntered.Call(other);
        }
    }
}
