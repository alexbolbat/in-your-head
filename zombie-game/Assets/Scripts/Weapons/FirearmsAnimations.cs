using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ZSG.Weapons
{
    public class FirearmsAnimations : MonoBehaviour
    {
        public event Action FireCompleted;
        public event Action ReloadCompleted;

        public enum State
        {
            Idle, Fire, Reload
        }

        [SerializeField]
        private Animation animation;
        [SerializeField]
        private AnimationsNames names;


        public void Fire()
        {
            PlayAnimation(names.Fire, FireCompleted);
        }

        public void Reload()
        {
            PlayAnimation(names.Reload, ReloadCompleted);
        }

        public void FireEmpty()
        {
            animation.Play(names.OutOfAmmo);
        }


        private void Awake()
        {
            this.AssertAsset(animation);
        }


        private void PlayAnimation(string name, Action completeCallback)
        {
            animation.Play(name);

            StartCoroutine(ExecuteOnAnimationEnd(completeCallback, name));
        }

        private IEnumerator ExecuteOnAnimationEnd(Action callback, string name)
        {
            while (animation.IsPlaying(name))
            {
                yield return null;
            }
            callback.Call();
        }



        [Serializable]
        public class AnimationsNames
        {
            public List<string> Idle;
            public string Fire = "fire";
            public string OutOfAmmo = "outOfAmmo";
            public string Reload = "reload";

            public string GetRandomIdle()
            {
                if (Idle.Count == 0)
                {
                    return null;
                }
                return Idle[Random.Range(0, Idle.Count)];
            }
        }
    }
}
