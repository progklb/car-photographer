using UnityEngine;

using CarPhotographer.Vehicles;

namespace CarPhotographer.IU
{
	public class UIVehicleSelect : UISelect
	{
		#region VARIABLES
		[SerializeField]
		private UIVehicleEntry m_EntryPrefab = null;
		#endregion


		#region HELPER FUNCTIONS
		protected override void Initialise()
		{
			ClearContent();

			var assets = VehicleManager.GetVehiclesAssets();

			foreach (var asset in assets)
			{
				var entry = Instantiate(m_EntryPrefab, contentParent);
				entry.name = asset.vehicleName;
				entry.Initialise(asset);
			}

			isInitialised = true;
		}
		#endregion
	}
}