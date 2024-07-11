using System;
using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public class LoadLevelState : IPayloadedState<string>
  {
    private const string InitialPointTag = "InitialPoint";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _loadingCurtain;
    private readonly IGameFactory _gameFactroy;
    private readonly IPersistenProgressServies _progressServies;

    public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactroy, IPersistenProgressServies progressServies)
    {
		_stateMachine = gameStateMachine;
		_sceneLoader = sceneLoader;
		_loadingCurtain = loadingCurtain;
		_gameFactroy = gameFactroy;
		_progressServies = progressServies;
    }
    
    public void Enter(string sceneName)
    {
		_loadingCurtain.Show();
		_gameFactroy.CleanUp();
		_sceneLoader.Load(sceneName, onLoaded);
    }

    public void Exit() => 
    	_loadingCurtain.Hide();
      

    private void onLoaded()
    {
        IntiGameWorld();
		InformProgressReaders();

        _stateMachine.Enter<GameLoopState>();
    }

	private void InformProgressReaders()
	{
		foreach (ISavedProgressReader progressReader in _gameFactroy.progressReaders)
		{
			progressReader.LoadProgress(_progressServies.Progress);
		}
	}

        private void IntiGameWorld()
    {
        var initialPoint = GameObject.FindWithTag(InitialPointTag);
        GameObject hero = _gameFactroy.CreateHero(initialPoint);
        _gameFactroy.CreateHud();

        CameraFollow(hero);
    }


        private void CameraFollow(GameObject hero) => 
		Camera.main.GetComponent<CameraFollow>().Follow(hero);

    
  }
}