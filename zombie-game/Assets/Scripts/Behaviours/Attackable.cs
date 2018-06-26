using UnityEngine;
using ZSG.Objects;
using ZSG.Weapons;

namespace ZSG.Behaviour
{
    public class Attackable : CharacterBehaviour
    {
        [SerializeField]
        private Movable movable;
        [SerializeField]
        private Weapon weapon;

        private Character target;


        public void SetTarget(Character target)
        {
            if (!isActive || target.IsDead)
            {
                return;
            }
            this.target = target;
            if (movable != null)
            {
                movable.MoveTo(target.transform, weapon.Distance);
            }
            target.Died += OnTargetDied;
        }

        public void RemoveTarget()
        {
            if (target != null)
            { 
                target.Died -= OnTargetDied;
                target = null;

                weapon.StopAttack();
                movable.RemoveTarget();
            }
        }


        private void Awake()
        {
            this.AssertAsset(weapon);

            if (movable != null)
            {
                movable.TargetReachedChanged += OnTargetReachedChanged;
            }
        }

        private void OnDestroy()
        {
            RemoveTarget();
            if (movable != null)
            {
                movable.TargetReachedChanged -= OnTargetReachedChanged;
            }

            movable = null;
            weapon = null;
        }


        private void OnTargetDied()
        {
            RemoveTarget();
        }


        protected override void OnActiveSet(bool isActive)
        {
            if (!isActive)
            {
                RemoveTarget();
            }
        }


        private void OnTargetReachedChanged(bool value)
        {
            if (value)
            { 
                if (target != null)
                { 
                    weapon.StartAttack();
                }
            }
            else
            {
                weapon.StopAttack();
            }
        }
    }
}
