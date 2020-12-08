using UnityEngine;

namespace CarPhotographer.Environments
{
	/// <summary>
	/// Defines a photo shoot location within an environment.
	/// </summary>
	public class ShootingLocation : MonoBehaviour
	{
		// TODO Location effects

		#region PROPERTIES
		/// The positions available for camera placement.
		public Transform[] cameraPositions { get => m_CameraPositions; private set => m_CameraPositions = value; }
		/// The positions available for vehicle placement.
		public Transform[] vehiclePositions { get => m_VehiclePositions; private set => m_VehiclePositions = value; }
		#endregion


		#region VARIABLES
		[SerializeField]
		private Transform[] m_CameraPositions;
		[SerializeField]
		private Transform[] m_VehiclePositions;
		#endregion


		#region GIZMOS
		void OnDrawGizmos()
		{
			foreach (var pos in vehiclePositions)
			{
				Gizmos.color = Color.green;
				Gizmos.DrawWireCube(pos.position, Vector3.one * 1f);
			}

			foreach (var pos in cameraPositions)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(pos.position, 1f);
			}
		}
		#endregion
	}
}