using System;
using UnityEngine;
using UnityEngine.AI;

namespace Architectural_training.Assets.CodeBase.Enemy
{   
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyAnimator))]

    public class AnimateAlongAgent : MonoBehaviour
    {
        private const float MinimalVelocity = 0.1f;
        
        public NavMeshAgent agent;
        public EnemyAnimator animator;

        void Update()
        {
            if (ShouldMove())
                animator.Move(agent.velocity.magnitude);
            else
                animator.StopMoving();
        }

        private bool ShouldMove() =>
            agent.velocity.magnitude > MinimalVelocity && agent.remainingDistance > agent.radius;

    }
    
}