using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure
{
	public class GameStateMachine
	{
		private readonly Dictionary<Type, IState> _states;
		private IState _activeState;

		public GameStateMachine(SceneLoader sceneLoader)
		{
			_states = new Dictionary<Type, IState>
			{
				[typeof(BoostrapState)] = new BoostrapState(this, sceneLoader),
			};
		}

		public void Enter<TState>() where TState : IState
		{
			_activeState?.Exit();

			var state = _states[typeof(TState)];
			_activeState = state;
			state.Enter();
		}
	}
}