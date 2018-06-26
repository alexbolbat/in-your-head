using UnityEngine;

namespace ZSG.Behaviour
{ 
    public class CharacterBehaviour : MonoBehaviour
    {
        protected bool isActive = true;

        public void SetActive(bool value)
        {
            if (value == isActive)
            {
                return;
            }
            isActive = true;
            OnActiveSet(value);
        }

        protected virtual void OnActiveSet(bool value)
        {
        }
    }
}
