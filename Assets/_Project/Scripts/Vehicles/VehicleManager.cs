using UnityEngine;

using System;

using Utilities.Frameworks;

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


		#region EVENTS
		/// Raised when <see cref="SelectVehicle(VehicleAsset)"/> is called.
		public static event Action<VehicleAsset> onVehicleSelected = delegate { };
		#endregion


		#region PROPERTIES
		public VehicleAsset selectedVehicle { get; private set; }
		#endregion


		#region PUBLIC API
		public static VehicleAsset[] GetVehiclesAssets()
		{
			return Resources.LoadAll<VehicleAsset>(VEHICLE_ASSET_PATH);
		}

		public static void UnloadVehicleAssets()
		{
			// Unity throws an error when unloading a specified resource.
			// Let's just release all unused assets instead.
			Resources.UnloadUnusedAssets();
		}

		public void SelectVehicle(VehicleAsset asset)
		{
			selectedVehicle = asset;
			onVehicleSelected(asset);
		}
		#endregion
	}
}