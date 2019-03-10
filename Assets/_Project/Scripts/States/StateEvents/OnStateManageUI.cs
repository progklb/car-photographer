using UnityEngine;

using Utilities.StateMachine;
using Utilities.StateMachine.StateEvents;

using CarPhotographer.UI;

namespace CarPhotographer.States.Events
{
	/// <summary>
	/// Provided control logic for the specified UI.
	/// </summary>
	[AddComponentMenu(App.APP_NAME + "/States/State Events/Manage UI")]
	public class OnStateManageUI : OnStateBehaviour
	{
		#region TYPES
		private enum LoadBehaviour
		{
			None,
			Show,
			Hide
		}
		#endregion


		#region VARIABLES
		[SerializeField]
		private UIElement m_UIElement = UIElement.LoadingScreen;

		[SerializeField]
		private LoadBehaviour m_OnBeginBehaviour = LoadBehaviour.None;
		[SerializeField]
		private LoadBehaviour m_OnEndBehaviour = LoadBehaviour.None;
		#endregion


		#region PUBLIC API
		public override void OnBegin(IState previousState, IState currentState)
		{
			if (m_OnBeginBehaviour == LoadBehaviour.Show)
			{
				UIManager.instance.ShowUI(m_UIElement);
			}
			else if (m_OnBeginBehaviour == LoadBehaviour.Hide)
			{
				UIManager.instance.HideUI(m_UIElement);
			}
		}

		public override void OnEnd(IState currentState, IState nextState)
		{
			if (m_OnEndBehaviour == LoadBehaviour.Show)
			{
				UIManager.instance.ShowUI(m_UIElement);
			}
			else if (m_OnEndBehaviour == LoadBehaviour.Hide)
			{
				UIManager.instance.HideUI(m_UIElement);
			}
		}
		#endregion
	}
}