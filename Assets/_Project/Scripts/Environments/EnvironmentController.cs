using UnityEngine;

namespace CarPhotographer.Environments
{
	/// <summary>
	/// Provides fine-grained control over a specific environment.
	/// </summary>
	public sealed class EnvironmentController : MonoBehaviour
	{
		#region PROPERTIES
		/// The shooting locations available in the current environment.
		public ShootingLocation[] shootingLocations { get => m_ShootingLocations; private set => m_ShootingLocations = value; }

		// TODO
		// Time of day - have a time controller: direction, intensity, golden hours, fog.
		// Current shoot location
		#endregion


		#region VARIABLES
		[SerializeField]
		private ShootingLocation[] m_ShootingLocations;
		#endregion


		#region UNITY EVENTS
		void Start()
		{
			EnvironmentManager.instance.Register(this);
		}

		void OnDestroy()
		{
			EnvironmentManager.instance.Deregister(this);
		}
		#endregion
	}
}