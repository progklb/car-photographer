using UnityEngine;

using CarPhotographer.Environments;

namespace CarPhotographer.IU
{
	public class UIEnvironmentSelect : UISelect
	{
		#region VARIABLES
		[SerializeField]
		private UIEnvironmentEntry m_EntryPrefab = null;
		#endregion


		#region HELPER FUNCTIONS
		protected override void Initialise()
		{
			ClearContent();

			var assets = EnvironmentManager.GetEnvironmentAssets();

			foreach (var asset in assets)
			{
				var entry = Instantiate(m_EntryPrefab, contentParent);
				entry.name = asset.environmentName;
				entry.Initialise(asset);
			}

			isInitialised = true;
		}
		#endregion
	}
}