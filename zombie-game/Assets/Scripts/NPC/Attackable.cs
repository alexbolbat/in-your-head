using UnityEngine;

namespace NPC
{
    public class Attackable : CharacterBehaviour
    {
        [SerializeField]
        private Movable movable;
        [SerializeField]
        private Weapon weapon;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private string attackAnimnName = "attacking";

        private Character target;


        public void SetTarget(Character target)
        {
            if (isDead)
            {
                return;
            }
            this.target = target;
            if (movable != null && weapon != null)
            {
                movable.MoveTo(target.transform, weapon.Distance);
            }
        }

        public void RemoveTarget()
        {
            target = null;
            movable.RemoveTarget();
        }


        private void Awake()
        {
            if (movable != null)
            {
                movable.TargetReachedChanged += OnTargetReachedChanged;
            }
        }


        protected override void OnDie()
        {
            target = null;
            movable.Die();
        }


        private void OnTargetReachedChanged(bool value)
        {
            if (value)
            { 
                if (target != null)
                { 
                    weapon.Attack(target);
                    SetAttackAnimation(true);
                }
            }
            else
            {
                SetAttackAnimation(false);
            }
        }


        private void SetAttackAnimation(bool value)
        {
            if (animator != null)
            {
                animator.SetBool(attackAnimnName, value);
            }
        }
    }
}
