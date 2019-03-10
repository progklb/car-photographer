using UnityEngine;

namespace CarPhotographer.Environments
{
	/// <summary>
	/// Provides fine-grained control over specific levels.
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
			EnvironmentManager.instance.RegisterController(this);
		}

		void OnDestroy()
		{
			EnvironmentManager.instance.DeregisterController(this);
		}
		#endregion
	}
}