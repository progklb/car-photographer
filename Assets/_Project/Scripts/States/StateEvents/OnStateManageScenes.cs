using UnityEngine;

using Utilities.StateMachine;
using Utilities.StateMachine.StateEvents;

using CarPhotographer.Scenes;

namespace CarPhotographer.States.Events
{
	/// <summary>
	/// Provided control logic for the specified set of scenes.
	/// </summary>
	[AddComponentMenu(App.APP_NAME + "/States/State Events/Manage Scenes")]
	public class OnStateManageScenes : OnStateBehaviour
	{
		#region TYPES
		private enum LoadBehaviour
		{
			None,
			Load,
			Unload
		}
		#endregion


		#region VARIABLES
		[SerializeField]
		private SceneSet m_SceneSet = SceneSet.MainMenu;

		[SerializeField]
		private LoadBehaviour m_OnBeginBehaviour = LoadBehaviour.None;
		[SerializeField]
		private LoadBehaviour m_OnEndBehaviour = LoadBehaviour.None;
		#endregion


		#region PUBLIC API
		public override void OnBegin(IState previousState, IState currentState)
		{
			if (m_OnBeginBehaviour == LoadBehaviour.Load)
			{
				SceneManager.instance.LoadScene(m_SceneSet);
			}
			else if (m_OnBeginBehaviour == LoadBehaviour.Unload)
			{
				SceneManager.instance.UnloadScene(m_SceneSet);
			}
		}

		public override void OnEnd(IState currentState, IState nextState)
		{
			if (m_OnEndBehaviour == LoadBehaviour.Load)
			{
				SceneManager.instance.LoadScene(m_SceneSet);
			}
			else if (m_OnEndBehaviour == LoadBehaviour.Unload)
			{
				SceneManager.instance.UnloadScene(m_SceneSet);
			}
		}
		#endregion
	}
}