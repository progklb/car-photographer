using UnityEngine;

using Utilities.StateMachine.Conditions;

using CarPhotographer.Vehicles;

namespace CarPhotographer.States.Conditions
{
	/// <summary>
	/// Is satisfied if the specified vehicle behaviour occurs.
	/// </summary>
	[AddComponentMenu(App.APP_NAME + "/States/Conditions/Vehicle Condition")]
	public class VehicleCondition : ConditionBehaviour
	{
		#region TYPES
		public enum Behaviour
		{
			Selected
		}
		#endregion

		#region PROPERTIES
		public Behaviour behaviour { get => m_Behaviour; private set => m_Behaviour = value; }
		#endregion


		#region VARIABLES
		[SerializeField]
		private Behaviour m_Behaviour;
		#endregion


		#region PUBLIC API
		public override void OnBegin()
		{
			VehicleManager.onVehicleSelected += HandleVehicleSelected;
		}

		public override void OnEnd()
		{
			VehicleManager.onVehicleSelected -= HandleVehicleSelected;
		}
		#endregion


		#region EVENT HANDLERS
		void HandleVehicleSelected(VehicleAsset asset)
		{
			if (m_Behaviour == Behaviour.Selected)
			{
				isSatisfied = true;
			}
		}
		#endregion
	}
}