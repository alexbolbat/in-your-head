using System;
using UnityEngine;
using ZSG.Factory;
using ZSG.Objects;
using ZSG.Weapons;

namespace ZSG
{
    public class App : MonoBehaviour
    {
        public static NPCFactory NPCs { get; private set; }
        public static ProjectilesFactory Projectiles { get; private set; }
        public static CollideEffects CollideEffects { get; private set; }

        [SerializeField]
        private NPCFactory npcs;
        [SerializeField]
        private ProjectilesFactory projectiles;
        [SerializeField]
        private CollideEffects collideEffects;

        private void Awake()
        {
            this.AssertAsset(collideEffects);
            this.AssertAsset(projectiles);
            this.AssertAsset(npcs);

            CollideEffects = collideEffects;
            Projectiles = projectiles;
            NPCs = npcs;
        }
    }
    

    public class PoolLayer
    {
        public TemplatePool<Projectile> Projectiles { get; private set; }

        public PoolLayer(Transform projectilesContainer)
        {
            Projectiles = new TemplatePool<Projectile>(projectilesContainer);
        }
    }
}
