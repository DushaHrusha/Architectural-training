using System;
using Architectural_training.Assets.CodeBase.Data;
using Architectural_training.Assets.CodeBase.Infrastructure.Services;
using Architectural_training.Assets.CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure;
using CodeBase.Services.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Hero
{
    public class HeroMove : MonoBehaviour, ISaveProgress
  {
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _movementSpeed;

    private IInputService _inputService;
    private Camera _camera;

    public void LoadProgress(PlayerProgress progress)
    {
		if (CurentLevel() == progress.WorldData.PossitionOnLevel.Level)
		{
			Vector3Data savedPosition = progress.WorldData.PossitionOnLevel.Possition;
			if(savedPosition != null)
			{
				Warp(savedPosition);
			}
		}
	}

	private void Warp(Vector3Data to)
	{
		_characterController.enabled = false;
		transform.position = to.AsUnityVector();
		_characterController.enabled = true;
	}

        public void UpdateProgress(PlayerProgress progress)
    {
        progress.WorldData.PossitionOnLevel = new PossitionOnLevel(CurentLevel(), transform.position.AsVectorData());
    }

    private string CurentLevel()
    {
        return SceneManager.GetActiveScene().name;
    }

    private void Awake()
    {
      _inputService = AllSerices.Container.Single<IInputService>();
    }

    private void Start() => 
      _camera = Camera.main;

    private void Update()
    {
      Vector3 movementVector = Vector3.zero;

      if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
      {
        movementVector = _camera.transform.TransformDirection(_inputService.Axis);
        movementVector.y = 0;
        movementVector.Normalize();

        transform.forward = movementVector;
      }

      movementVector += Physics.gravity;

      _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
    }
  }
}