using UnityEngine;

using Utilities;

namespace CarPhotographer.Vehicles
{
	/// <summary>
	/// A high-level manager for providing control over vehicles.
	/// </summary>
	public class VehicleManager : Singleton<VehicleManager>
	{
		#region CONSTANTS
		/// File path in Resources where assets are stored.
		public const string VEHICLE_ASSET_PATH = "Vehicle Assets";
		/// File path in Resources where prefabs are stored.
		public const string VEHICLE_PREFAB_PATH = "Vehicle Prefabs";
		#endregion


		#region PUBLIC API
		public VehicleAsset[] GetVehiclesAssets()
		{
			return Resources.LoadAll<VehicleAsset>(VEHICLE_ASSET_PATH);
		}

		public void UnloadVehicleAssets()
		{
			// Unity throws an error when unloading a specified resource.
			// Let's just release all unused assets instead.
			Resources.UnloadUnusedAssets();
		}
		#endregion
	}
}