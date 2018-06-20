using System;
using UnityEngine;
using UnityEngine.Assertions;

public static class GlobalExtensions
{
    public static void Call(this Action action)
    {
        if(action != null)
            action.Invoke();
    }

    public static void Call<T>(this Action<T> action, T arg)
    {
        if(action != null)
            action.Invoke(arg);
    }

    public static void Call<T, K>(this Action<T, K> action, T arg1, K arg2)
    {
        if(action != null)
            action.Invoke(arg1, arg2);
    }

    public static void AssertAsset(this MonoBehaviour mb, UnityEngine.Object asset)
    {
        Assert.IsNotNull(asset, mb + " " + mb.name + ": missing asset");
    }
}
