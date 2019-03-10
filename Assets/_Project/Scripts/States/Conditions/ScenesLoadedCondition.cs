using UnityEngine;

using Utilities.StateMachine.Conditions;

using CarPhotographer.Scenes;

namespace CarPhotographer.States.Conditions
{
	/// <summary>
	/// Is satisfied if the expected scenes are in the expected loaded states.
	/// </summary>
	[AddComponentMenu(App.APP_NAME + "/States/Conditions/Scenes Loaded Condition")]
	public class ScenesLoadedCondition : ConditionBehaviour
	{
		#region TYPES
		public enum LoadedState
		{
			Loaded,
			Unloaded
		}
		#endregion

		#region PROPERTIES
		public SceneSet sceneSet { get => m_SceneSet; private set => m_SceneSet = value; }
		public LoadedState state { get => m_State; private set => m_State = value; }
		#endregion


		#region VARIABLES
		[SerializeField]
		private SceneSet m_SceneSet;
		[SerializeField]
		private LoadedState m_State;
		#endregion


		#region PUBLIC API
		public override void OnUpdate()
		{
			bool hasLoaded = SceneManager.instance.HasLoaded(sceneSet);

			isSatisfied = (hasLoaded && state == LoadedState.Loaded) || (!hasLoaded && state == LoadedState.Unloaded);
		}
		#endregion
	}
}