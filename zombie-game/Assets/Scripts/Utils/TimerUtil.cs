using System;
using System.Collections;
using UnityEngine;

namespace ZSG.Utils
{
    public class TimerUtil : MonoBehaviour
    {
        private static TimerUtil instance;


        public static void Timeout(float delay, Action callback)
        {
            Init();

            instance.StartCoroutine(instance.TimeoutProcess(delay, callback));
        }

        public static void Init()
        {
            if (instance == null)
            {
                instance = new GameObject("MB").AddComponent<TimerUtil>();
            }
        }



        private void Awake()
        {
            if (instance == null)
            { 
                instance = this;
            }
        }

        private IEnumerator TimeoutProcess(float delay, Action callback)
        {
            yield return new WaitForSeconds(delay);

            callback();
        }
    }
}
