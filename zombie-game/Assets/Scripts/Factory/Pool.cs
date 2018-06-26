using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ZSG.Factory
{
    public class Pool<R> where R : Object, IReusable
    {
        private List<Reusable> activeItems = new List<Reusable>();
        private List<Reusable> pool = new List<Reusable>();
        private Transform parent;
        private R origin;


        public Pool(R origin, Transform parent)
        {
            this.origin = origin;
            this.parent = parent;
        }

        public R Get()
        {
            Reusable reusable;
            if (pool.Count > 0)
            {
                reusable = pool[0];
                pool.RemoveAt(0);
            }
            else
            {
                reusable = new Reusable(Object.Instantiate(origin, parent));
                reusable.BecameUsed += OnItemBecameUsed;
            }
            activeItems.Add(reusable);
            reusable.Item.Reset();
            return (R)reusable.Item;
        }

        private void OnItemBecameUsed(Reusable reusable)
        {
            activeItems.Remove(reusable);
            pool.Add(reusable);
        }

        //wrpapper for detecting an exect item in the list
        private class Reusable
        {
            public event Action<Reusable> BecameUsed;

            private IReusable item;

            public Reusable(IReusable item)
            {
                this.item = item;
                item.BecameUsed += OnBecameUsed;
            }

            public IReusable Item
            {
                get
                {
                    return item;
                }
            }

            private void OnBecameUsed()
            {
                BecameUsed.Call(this);
            }
        }
    }
}
