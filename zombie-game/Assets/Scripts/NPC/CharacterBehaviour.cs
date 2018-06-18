using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
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
