using Architectural_training.Assets.CodeBase.Infrastructure.AssetManagment;
using Architectural_training.Assets.CodeBase.Infrastructure.Services;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public class BootstrapState : IState
  {
    private const string Initial = "Initial";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly AllSerices _serices;
    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllSerices serices)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _serices = serices;
      RegisterServices();
    }

    
    public void Enter()
    {
      _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
    }

    public void Exit()
    {
    }

    private void EnterLoadLevel() => 
      _stateMachine.Enter<LoadLevelState, string>("Main");

    private void RegisterServices()
    {
      _serices.RegisterSingle<IInputService>(InputService());
      _serices.RegisterSingle<IAssets>(new AssetProvider());
      _serices.RegisterSingle<IGameFactory>(new GameFactory(_serices.Single<IAssets>()));
    }

    private static IInputService InputService()
    {
      if (Application.isEditor)
        return new StandaloneInputService();
      else
        return new MobileInputService();
    }
  }
}