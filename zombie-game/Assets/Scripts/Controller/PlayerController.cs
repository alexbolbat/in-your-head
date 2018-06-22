using System.Collections.Generic;
using UnityEngine;
using ZSG.Objects;
using ZSG.Weapons;

namespace ZSG.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Character character;
        [SerializeField]
        private MonoBehaviour moveController;
        [SerializeField]
        private PlayerInput input;
        [SerializeField]
        private List<Weapon> weapons;

        private Weapon currentWeapon;


        private void Awake()
        {
            this.AssertAsset(input);
        }

        private void Start()
        {
            input.FireStart += OnFireStart;
            input.FireEnd += OnFireEnd;
            character.Died += OnDied;

            if (weapons.Count > 0)
            {
                currentWeapon = weapons[0];
                currentWeapon.Show();
            }
        }


        private void OnFireStart()
        {
            if (currentWeapon != null)
            {
                currentWeapon.StartAttack();
            }
        }

        private void OnFireEnd()
        {
            if (currentWeapon != null)
            {
                currentWeapon.StopAttack();
            }
        }

        private void OnDied()
        {
            input.enabled = false;
            moveController.enabled = false;
        }
    }
}
