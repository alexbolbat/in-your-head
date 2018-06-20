using System.Collections.Generic;
using UnityEngine;
using ZSG.Weapons;

namespace ZSG.Controller
{
    public class ProjectileFactory
    {
        public static void InitProjectile(Projectile origin, Transform muzzle, float damage)
        {
            Projectile projectile = GameObject.Instantiate<Projectile>(origin, muzzle.position, muzzle.rotation);
            projectile.gameObject.SetActive(true);
            projectile.Launch(damage);
        }
    }
}
