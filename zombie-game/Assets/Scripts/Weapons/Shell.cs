using UnityEngine;

namespace Weapons
{
    public class Shell : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody rigidbody;

        private float damage;

        public void SetDamage(float value)
        {
            damage = value;
        }

        private void OnTriggerEnter(Collider other)
        {

        }

        private void OnCollisionEnter(Collision collision)
        {

        }
    }
}
