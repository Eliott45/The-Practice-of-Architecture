using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure
{
	public class BoostrapState : IState
	{
		private const string Initial = "Initial";
		private readonly GameStateMachine _gameStateMachine;
		private readonly SceneLoader _sceneLoader;

		public BoostrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
		{
			_gameStateMachine = gameStateMachine;
			_sceneLoader = sceneLoader;
		}

		public void Enter()
		{
			RegistryServices();
			_sceneLoader.Load(Initial, EnterLoadLevel);
		}

		private void RegistryServices()
		{
			Game.InputService = RegisterInputService();
		}

		public void Exit()
		{
		}

		private void EnterLoadLevel() =>
			_gameStateMachine.Enter<LoadLevelState>();

		private IInputService RegisterInputService()
		{
			if (Application.isEditor)
			{
				return new StandaloneInputService();
			}

			return new MobileInputService();
		}
	}
}