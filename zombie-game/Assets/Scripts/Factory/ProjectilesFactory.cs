using UnityEngine;
using ZSG.Weapons;

namespace ZSG.Factory
{
    public class ProjectilesFactory : MonoBehaviour
    {
        private TemplatePool<Projectile> pool;


        public Projectile Create(Projectile original)
        {
            return pool.Get(original);
        }

        public void Create(Projectile original, Transform direction, float damage)
        {
            Create(original).Launch(direction, damage);
        }

        private void Awake()
        {
            pool = new TemplatePool<Projectile>(transform);
        }
    }
}
