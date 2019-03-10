using UnityEngine;

namespace CarPhotographer.Environments
{
	/// <summary>
	/// Identifies a particular environment and stores information associated with it.
	/// </summary>
	[CreateAssetMenu(fileName = "New Environment Asset", menuName = "Car Photographer/Environment Asset")]
	public class EnvironmentAsset : ScriptableObject
	{
		#region PROPERTIES
		/// Display name of the environment.
		public string environmentName { get => m_EnvironmentName; }
		/// Name of the scene to load.
		public string sceneName { get => m_SceneName; }
		/// Thumbnail to display in UI.
		public Sprite thumbnail { get => m_Thumbnail; }
		#endregion


		#region VARIABLES
		[SerializeField]
		private string m_EnvironmentName = string.Empty;
		[SerializeField]
		private string m_SceneName = string.Empty;
		[SerializeField]
		private Sprite m_Thumbnail = null;
		#endregion
	}
}