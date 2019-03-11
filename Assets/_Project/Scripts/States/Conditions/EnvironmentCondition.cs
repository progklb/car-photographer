using UnityEngine;

using Utilities.StateMachine.Conditions;

using CarPhotographer.Environments;
using CarPhotographer.Scenes;

namespace CarPhotographer.States.Conditions
{
	/// <summary>
	/// Is satisfied if the specified environment behaviour occurs.
	/// </summary>
	[AddComponentMenu(App.APP_NAME + "/States/Conditions/Environment Condition")]
	public class EnvironmentCondition : ConditionBehaviour
	{
		#region TYPES
		public enum Behaviour
		{
			Selected,
			BeginLoading,
			FinishedLoading,
			Unloaded
		}
		#endregion

		#region PROPERTIES
		public Behaviour behaviour { get => m_Behaviour; private set => m_Behaviour = value; }
		#endregion


		#region VARIABLES
		[SerializeField]
		private Behaviour m_Behaviour;
		#endregion


		#region PUBLIC API
		public override void OnBegin()
		{
			EnvironmentManager.onEnvironmentSelected += HandleEnvironmentSelected;
			EnvironmentManager.onEnvironmentBeginLoading += HandleEnvironmentBeginLoading;
			EnvironmentManager.onEnvironmentFinishedLoading += HandleEnvironmentFinishedLoading;
			EnvironmentManager.onEnvironmentUnload += HandleEnvironmentUnload;
		}

		public override void OnEnd()
		{
			EnvironmentManager.onEnvironmentSelected -= HandleEnvironmentSelected;
			EnvironmentManager.onEnvironmentBeginLoading -= HandleEnvironmentBeginLoading;
			EnvironmentManager.onEnvironmentFinishedLoading -= HandleEnvironmentFinishedLoading;
			EnvironmentManager.onEnvironmentUnload -= HandleEnvironmentUnload;
		}
		#endregion


		#region EVENT HANDLERS
		void HandleEnvironmentSelected(EnvironmentAsset asset)
		{
			if (m_Behaviour == Behaviour.Selected)
			{
				isSatisfied = true;
			}
		}

		void HandleEnvironmentBeginLoading(EnvironmentAsset asset)
		{
			if (m_Behaviour == Behaviour.BeginLoading)
			{
				isSatisfied = true;
			}
		}

		void HandleEnvironmentFinishedLoading(EnvironmentAsset asset)
		{
			if (m_Behaviour == Behaviour.FinishedLoading)
			{
				// Wait for the environment controller to be available. This indicates that the environment is fully loaded and ready.
				isSatisfied = EnvironmentManager.instance.currentController != null;
			}
		}

		void HandleEnvironmentUnload(EnvironmentAsset asset)
		{
			if (m_Behaviour == Behaviour.Unloaded)
			{
				isSatisfied = true;
			}
		}
		#endregion
	}
}