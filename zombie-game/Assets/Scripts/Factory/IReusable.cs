using System;

namespace ZSG.Factory
{
    public interface IReusable
    {
        event Action BecameUsed;
        void Reset();
    }
}
