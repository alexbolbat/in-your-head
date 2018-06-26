using System;
using UnityEngine;
using ZSG.Factory;

namespace ZSG.Effects
{
    public abstract class Effect : MonoBehaviour, IReusable
    {
        public event Action BecameUsed;
        
        public abstract void Show();
        public abstract void Reset();
    }
}
