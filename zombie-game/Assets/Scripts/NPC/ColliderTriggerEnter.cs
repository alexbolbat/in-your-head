using System;
using UnityEngine;

namespace NPC
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
