using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NPC
{ 
    [RequireComponent(typeof(NavMeshAgent))]
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
        private float reachedDistance = -1f;


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
            this.reachedDistance = reachedDistance;
        }

        public void RemoveTarget()
        {
            target = null;
        }

        protected override void OnDie()
        {
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
            if (GetIsReachedTarget())
            {
                SetMoving(false);
            }
            else
            {
                if (target != null)
                {
                    SetMoving(true);

                    agent.SetDestination(target.position);
                }
            }
        }


        private void SetMoving(bool value)
        {
            if (isMoving != value)
            {
                Debug.Log("SetMoving " + value);
                isMoving = value;

                agent.isStopped = !value;

                SetMoveAnimation(value);
                SetTargetReached(!value);
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


        private bool GetIsReachedTarget()
        {
            if (agent == null || target == null)
            {
                return false;
            }
            //TODO: remove magic
            float distance = reachedDistance >= 0 ? reachedDistance : agent.stoppingDistance + 0.08f;
            //Debug.Log("GetIsReachedTarget " + Vector3.Distance(target.position, transform.position) + " <= " + distance);
            return Vector3.Distance(target.position, transform.position) <= distance;
        }
    }
}
