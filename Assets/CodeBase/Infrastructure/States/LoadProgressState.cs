using System;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEditor;

namespace CodeBase.Infrastructure
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistenProgressServies _progressServies;
        private readonly ISaveLoadServies _saveLoadServies;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistenProgressServies progressServies, ISaveLoadServies saveLoadServies)
        {
            _gameStateMachine = gameStateMachine;
            _progressServies = progressServies;
            _saveLoadServies = saveLoadServies;
        }
        public void Enter()
        {
            LoadPrograssOrInitNew();
            _gameStateMachine.Enter<LoadLevelState,string>(_progressServies.Progress.WorldData.PossitionOnLevel.Level);
        }

        public void Exit()
        {

        }

        private void LoadPrograssOrInitNew()
        {
            _progressServies.Progress = _saveLoadServies.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {
            return new PlayerProgress("Main");
        }
    }
}