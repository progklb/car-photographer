using UnityEngine;

using CarPhotographer.Environments;

namespace CarPhotographer.IU
{
	/// <summary>
	/// Controller for the UI used for displaying/selecting environment options.
	/// </summary>
	public class UIEnvironmentSelect : MonoBehaviour
	{
		#region PROPERTIES
		private bool isInitialised { get; set; }
		#endregion


		#region VARIABLES
		[SerializeField]
		private UIEnvironmentEntry m_EntryPrefab = null;
		#endregion


		#region UNITY EVENTS
		void Start()
		{
			if (!isInitialised)
			{
				Initialise();
			}
		}
		#endregion


		#region HELPER FUNCTIONS
		void Initialise()
		{
			var assets = EnvironmentManager.GetEnvironmentAssets();

			// TODO Populate UI
			foreach (var asset in assets)
			{
				m_EntryPrefab.Initialise(asset);
			}

			isInitialised = true;
		}
		#endregion
	}
}