using UnityEngine;

namespace ZSG.Behaviour
{ 
    public class CharacterBehaviour : MonoBehaviour
    {
        protected bool isDead;

        public void Die()
        {
            if (!isDead)
            {
                isDead = true;
                OnDie();
            }
        }

        protected virtual void OnDie()
        {

        }
    }
}
