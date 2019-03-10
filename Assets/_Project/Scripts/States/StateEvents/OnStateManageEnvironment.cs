using UnityEngine;

using Utilities.StateMachine;
using Utilities.StateMachine.StateEvents;

using CarPhotographer.Environments;
using CarPhotographer.Scenes;

namespace CarPhotographer.States.Events
{
	/// <summary>
	/// Provides control logic for environments.
	/// </summary>
	[AddComponentMenu(App.APP_NAME + "/States/State Events/Manage Environment")]
	public class OnStateManageEnvironment : OnStateBehaviour
	{
		#region TYPES
		private enum Behaviour
		{
			LoadSelected,
			Unload
		}
		#endregion


		#region VARIABLES
		[SerializeField]
		private Behaviour m_Behaviour = Behaviour.LoadSelected;
		#endregion


		#region PUBLIC API
		public override void OnBegin(IState previousState, IState currentState)
		{
			if (m_Behaviour == Behaviour.LoadSelected)
			{
				EnvironmentManager.instance.LoadSelectedEnvironment();
			}
			else if (m_Behaviour == Behaviour.Unload)
			{
				EnvironmentManager.instance.UnloadSelectedEnvironment();
			}
		}
		#endregion
	}
}