using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure
{
	public class BoostrapState : IState
	{
		private readonly GameStateMachine _gameStateMachine;

		public BoostrapState(GameStateMachine gameStateMachine)
		{
			_gameStateMachine = gameStateMachine;
		}

		public void Enter()
		{
			RegistryServices();
		}

		private void RegistryServices()
		{
			Game.InputService = RegisterInupService();
		}

		public void Exit()
		{
		}

		private IInputService RegisterInupService()
		{
			if (Application.isEditor)
			{
				return new StandaloneInputService();
			}

			return new MobileInputService();
		}
	}
}