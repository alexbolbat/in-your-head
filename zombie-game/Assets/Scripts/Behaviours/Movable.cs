using System;
using UnityEngine;
using UnityEngine.AI;

namespace ZSG.Behaviour
{ 
    public class Movable : CharacterBehaviour
    {
        public event Action<bool> TargetReachedChanged;

        [SerializeField]
        private NavMeshAgent agent;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private string moveAnimnName = "moving";

        private Transform target;
        private bool isMoving;
        private bool isTargetReached;

        public void MoveTo(Transform target)
        {
            MoveTo(target, -1f);
        }

        public void MoveTo(Transform target, float reachedDistance)
        {
            if (isDead)
            {
                return;
            }
            //Debug.Log("move to " + target + " " + reachedDistance);
            this.target = target;
            //this.reachedDistance = reachedDistance;
            agent.stoppingDistance = reachedDistance;
        }

        public void RemoveTarget()
        {
            target = null;
        }


        protected override void OnDie()
        {
            agent.isStopped = true;
        }


        private void Awake()
        {
            if (agent == null)
            {
                agent = GetComponent<NavMeshAgent>();
            }
        }

        private void Update()
        {
            if (isMoving)
            {
                if (target == null || GetIsReachedTarget(0f))
                {
                    isMoving = false;

                    agent.isStopped = true;

                    SetMoveAnimation(false);
                    SetTargetReached(true);
                }
                else if (target != null)
                {
                    agent.SetDestination(target.position);
                }
            }
            else
            {
                if (target != null)
                {   
                    if (!GetIsReachedTarget(0.1f))
                    { 
                        isMoving = true;

                        agent.isStopped = false;

                        SetMoveAnimation(true);
                        SetTargetReached(false);
                    }
                    else
                    {
                        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
                    }
                    agent.SetDestination(target.position);
                }
            }
        }

        private void SetMoveAnimation(bool value)
        {
            if (animator != null)
            {
                animator.SetBool(moveAnimnName, value);
            }
        }

        private void SetTargetReached(bool value)
        {
            if (isTargetReached != value)
            {
                isTargetReached = value;
                TargetReachedChanged.Call(value);
            }
        }


        private bool GetIsReachedTarget(float thresold)
        {
            if (agent == null || target == null)
            {
                return false;
            }
            //float distance = reachedDistance >= 0 ? reachedDistance : agent.stoppingDistance + thresold;
            float distance = agent.stoppingDistance + thresold;
            //Debug.Log(Vector3.Distance(ZeroY(target.position), ZeroY(transform.position)) + "<=" + distance);
            return Vector3.Distance(ZeroY(target.position), ZeroY(transform.position)) <= distance;
        }

        private Vector3 ZeroY(Vector3 vector)
        {
            return new Vector3(vector.x, 0f, vector.z);
        }
    }
}
