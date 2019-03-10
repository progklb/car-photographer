using UnityEngine;

namespace CarPhotographer.Vehicles
{
	/// <summary>
	/// Identifies a particular vehicle and stores information associated with it.
	/// </summary>
	[CreateAssetMenu(fileName = "New Vehicle Asset", menuName = "Car Photographer/Vehicle Asset")]
	public class VehicleAsset : ScriptableObject
	{
		#region PROPERTIES
		/// Display name of the vehicle.
		public string vehicleName { get => m_VehicleName; }
		/// Name of the resource prefab to load.
		public string resourceName { get => m_ResourceName; }
		/// Thumbnail to display in UI.
		public Sprite thumbnail { get => m_Thumbnail; }
		#endregion


		#region VARIABLES
		[SerializeField]
		private string m_VehicleName = string.Empty;
		[SerializeField]
		private string m_ResourceName = string.Empty;
		[SerializeField]
		private Sprite m_Thumbnail = null;
		#endregion
	}
}