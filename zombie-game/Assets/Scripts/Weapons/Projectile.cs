using System;
using UnityEngine;
using ZSG.Objects;
using ZSG.Factory;

namespace ZSG.Weapons
{
    public class Projectile : MonoBehaviour, IReusable
    {
        public event Action BecameUsed;

        [SerializeField]
        private ProjectileType type;
        [SerializeField]
        private Rigidbody rigidbody;

        private float damage;
        private Vector3 prevPosition;
        private Vector3 startPosition;


        public void Launch(Transform direction, float damage)
        {
            transform.position = direction.position;
            transform.rotation = direction.rotation;

            Launch(damage);
        }

        public void Launch(float damage)
        {
            this.damage = damage;
            rigidbody.AddForce(transform.forward * 100);
            startPosition = transform.position;
            prevPosition = startPosition;
        }

        public void Reset()
        {
            gameObject.SetActive(true);
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
                    App.CollideEffects.Show(hitinfo.point, type, vulnurable.Surface);

                    Utilize();
                    return;
                }
            }
            prevPosition = transform.position;
            if (Vector3.Distance(prevPosition, startPosition) > 500f)
            {
                Utilize();
            }
        }

        private void OnDestroy()
        {
            BecameUsed = null;
            rigidbody = null;
        }


        private void Utilize()
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;

            gameObject.SetActive(false);
            BecameUsed.Call();
        }
    }
}
