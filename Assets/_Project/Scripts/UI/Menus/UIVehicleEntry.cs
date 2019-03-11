using UnityEngine;
using UnityEngine.UI;

using CarPhotographer.Vehicles;

namespace CarPhotographer.IU
{
	public class UIVehicleEntry : MonoBehaviour
	{
		#region PROPERTIES
		public VehicleAsset asset { get; private set; }
		#endregion


		#region VARIABLES
		[SerializeField]
		private Text m_DisplayName;
		[SerializeField]
		private Image m_Thumbnail = null;
		[SerializeField]
		private Button m_Button = null;
		#endregion


		#region UNITY EVENTS
		void Start()
		{
			m_Button.onClick.AddListener(HandleClicked);
		}
		#endregion


		#region EVENT HANDLERS
		void HandleClicked()
		{
			VehicleManager.instance.SelectVehicle(asset);
		}
		#endregion


		#region PUBLIC API
		public void Initialise(VehicleAsset asset)
		{
			this.asset = asset;

			m_DisplayName.text = asset.vehicleName;
			m_Thumbnail.sprite = asset.thumbnail;
		}
		#endregion
	}
}