using UnityEngine;
using ZSG.Weapons;

namespace ZSG.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput input;

        [SerializeField]
        private Weapon weapon;


        private void Awake()
        {
            this.AssertAsset(input);
        }

        private void Start()
        {
            input.FireStart += OnFireStart;
            input.FireEnd += OnFireEnd;
        }


        private void OnFireStart()
        {
            if (weapon != null)
            {
                weapon.Attack();
            }
        }

        private void OnFireEnd()
        {
            if (weapon != null)
            {
                weapon.Stop();
            }
        }
    }
}
