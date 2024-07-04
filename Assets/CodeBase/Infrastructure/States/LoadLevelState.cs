using CodeBase.CameraLogic;
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

    public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
    {
      _stateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
      _loadingCurtain = loadingCurtain;
    }
    
    public void Enter(string sceneName)
    {
      _loadingCurtain.Show();
      _sceneLoader.Load(sceneName, onLoaded);
    }

    public void Exit() => 
    	_loadingCurtain.Hide();
      

    private void onLoaded()
    {
        var initialPoint = GameObject.FindWithTag(InitialPointTag);
        GameObject hero = _gameFactroy.CreateHero(initialPoint);
        _gameFactroy.CreateHud();

        CameraFollow(hero);

        _stateMachine.Enter<GameLoopState>();
    }

    

	private void CameraFollow(GameObject hero) => 
		Camera.main.GetComponent<CameraFollow>().Follow(hero);

    
  }
}