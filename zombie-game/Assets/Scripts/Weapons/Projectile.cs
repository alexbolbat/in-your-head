using System;
using UnityEngine;
using ZSG.Objects;
using ZSG.Factory;

namespace ZSG.Weapons
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private ProjectileType type;
        [SerializeField]
        private Rigidbody rigidbody;

        private float damage;
        private Vector3 prevPosition;
        private Vector3 startPosition;

        public void Launch(float damage)
        {
            this.damage = damage;
            rigidbody.AddForce(transform.forward * 100);
            startPosition = transform.position;
            prevPosition = startPosition;
        }

        private void Update()
        {
            RaycastHit hitinfo;
            if (Physics.Linecast(prevPosition, transform.position, out hitinfo))
            {
                Vulnerable vulnurable = hitinfo.collider.GetComponent<Vulnerable>();
                if (vulnurable != null)
                {
                    vulnurable.DealDamage(damage);
                    CollideEffectsFactory.Show(hitinfo.point, type, vulnurable.Surface);
                    //TODO
                    Destroy(gameObject);
                }
            }
            prevPosition = transform.position;
            //TODO
            if (Vector3.Distance(prevPosition, startPosition) > 1000f)
            {
                Destroy(gameObject);
            }
        }
    }
}
