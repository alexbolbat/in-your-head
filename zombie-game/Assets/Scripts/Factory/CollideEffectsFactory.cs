using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZSG.Effects;
using ZSG.Objects;
using ZSG.Weapons;

namespace ZSG.Factory
{
    public class CollideEffectsFactory : MonoBehaviour
    {
        private static CollideEffectsFactory instance;

        public static void Show(Vector3 position, ProjectileType projectile, SurfaceType surface)
        {
            instance.ShowEffect(position, projectile, surface);
        }


        [SerializeField]
        private List<CollisionEffect> effects;

        private void ShowEffect(Vector3 position, ProjectileType projectile, SurfaceType surface)
        {
            CollisionEffect effect = effects.FirstOrDefault(e => e.Projectile == projectile && e.Surface == surface);
            if (effect != null && effect.Effect != null)
            {
                Effect instance = Instantiate(effect.Effect, transform);
                instance.gameObject.SetActive(true);
                instance.transform.position = position;
                instance.Show();
            }
        }

        private void Awake()
        {
            instance = this;
        }


        [Serializable]
        public class CollisionEffect
        {
            public ProjectileType Projectile;
            public SurfaceType Surface;
            public Effect Effect;
        }
    }
}
