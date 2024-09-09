using Architectural_training.Assets.CodeBase.Enemy;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    class Attack : MonoBehaviour
    {
        private EnemyAnimator animator;
        private IGameFactory gameFactory;
        private Transform HeroTransform;

        private void Awake()
        {
            gameFactory = AllSerices.Container.Single<IGameFactory>();
            gameFactory.HeroCreated += OnHeroCreated;
        }

        private void OnHeroCreated()
        {
            HeroTransform = gameFactory.HeroGameObject.transform;
        }
    }
}
