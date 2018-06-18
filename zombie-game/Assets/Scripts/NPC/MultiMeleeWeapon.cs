using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
    public class MultiMeleeWeapon : AnimationDependWeapon
    {
        [SerializeField]
        private List<Transform> weapons;
        [SerializeField]
        private float hitDistance = 1f;

        private Character target;


        public override void Attack(Character target)
        {
            this.target = target;
        }

        public override void Stop()
        {
            target = null;
        }

        public override void Hit()
        {
            //Debug.Log("HIT");
            if (target == null)
            {
                return;
            }
            foreach (var weapon in weapons)
            {
                //Debug.Log(Vector3.Distance(weapon.position, target.transform.position) + " <= " +  hitDistance);
                if (Vector3.Distance(weapon.position, target.transform.position) <= hitDistance)
                {
                    target.DealDamage(damage);
                    break;
                }
            }
        }
    }
}
