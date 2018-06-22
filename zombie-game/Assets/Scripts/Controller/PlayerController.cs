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
    }
}
