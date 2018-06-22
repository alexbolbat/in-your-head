using System.Collections;
using UnityEngine;

namespace Behaviours
{
    public class IdleAnimation : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private string triggerName = "Idle";
        [SerializeField]
        private string animnNumIntName = "IdleNum";
        [SerializeField]
        private int animnsCount = 2;
        [SerializeField]
        private float minInterval = 1f;
        [SerializeField]
        private float maxInterval = 10f;


        private void Awake()
        {
            this.AssertAsset(animator);
        }

        private void Start()
        {
            StartCoroutine(DelayedNextAnimation());
        }


        private IEnumerator DelayedNextAnimation()
        {
            while (true)
            { 
                yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));

                animator.SetInteger(animnNumIntName, Random.Range(1, animnsCount + 1));
                animator.SetTrigger(triggerName);
            }
        }
    }
}
