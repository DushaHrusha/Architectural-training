using System;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

namespace Architectural_training.Assets.CodeBase.Enemy
{
    public class AgentMoveToPlayer : MonoBehaviour 
    {
        public NavMeshAgent Agent;
        private Transform _heroTransform;
        private IGameFactory _gameFactory;
        private const float MinimalDistanse = 1;

        async void Start()
        {

            _heroTransform = await _gameFactory.GetHeroGameObject();

            _gameFactory = AllSerices.Container.Single<IGameFactory>();
            if(_gameFactory.HeroGameObject != null)
                InitializeHeroTransform();
            else
                _gameFactory.HeroCreated += InitializeHeroTransform;
                
        }

        private void InitializeHeroTransform() =>
            _heroTransform = _gameFactory.HeroGameObject.transform;

        void Update()
        {
            if (HeroNotReached())
                Agent.destination = _heroTransform.transform.position;

        }

        private bool HeroNotReached() =>
            Vector3.Distance(Agent.transform.position, _heroTransform.transform.position) >= MinimalDistanse;
        

    }
}