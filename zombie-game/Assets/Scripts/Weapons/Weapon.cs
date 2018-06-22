using System;
using UnityEngine;

namespace ZSG.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        protected float distance = 1f;
        [SerializeField]
        protected float damage = 1f;
        [SerializeField]
        private string weaponName;
        [SerializeField]
        protected Animator animator;
        [SerializeField]
        private string visibleAnimnParamPrefix = "Visible";
        [SerializeField]
        protected string attackAnimnName = "Attacking";
        [SerializeField]
        protected string attackOnceAnimnName = "Attack";


        public string WeaponName
        {
            get
            {
                return weaponName;
            }
        }

        public float Distance
        {
            get
            {
                return distance;
            }
        }


        public virtual void StartAttack()
        {
            SetAnimationParam(attackAnimnName, true);
        }

        public virtual void StopAttack()
        {
            SetAnimationParam(attackAnimnName, false);
        }

        public virtual void AttackOnce()
        {
            SetAnimationParam(attackOnceAnimnName);
        }

        public virtual void Show()
        {
            SetAnimationParam(weaponName + visibleAnimnParamPrefix, true);
        }

        public virtual void Hide()
        {
            SetAnimationParam(weaponName + visibleAnimnParamPrefix, false);
        }


        protected void SetAnimationParam(string name)
        {
            if (animator != null && !string.IsNullOrEmpty(name))
            {
                animator.SetTrigger(name);
            }
        }

        protected void SetAnimationParam(string name, bool value)
        {
            if (animator != null && !string.IsNullOrEmpty(name))
            {
                animator.SetBool(name, value);
            }
        }

        protected void SetAnimationParam(string name, int value)
        {
            if (animator != null && !string.IsNullOrEmpty(name))
            {
                animator.SetInteger(name, value);
            }
        }
    }
}
