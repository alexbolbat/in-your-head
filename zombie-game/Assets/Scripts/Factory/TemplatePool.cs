using System.Collections.Generic;
using UnityEngine;

namespace ZSG.Factory
{
    public class TemplatePool<T> where T : Object, IReusable
    {
        private Dictionary<Object, Pool<T>> pools;
        private Transform parent;

        public TemplatePool(Transform parent)
        {
            this.parent = parent;
            pools = new Dictionary<Object, Pool<T>>();
        }

        public T Get(T origin)
        {
            if (!pools.ContainsKey(origin))
            {
                pools[origin] = new Pool<T>(origin, parent);
            }
            return pools[origin].Get();
        }
    }
}
