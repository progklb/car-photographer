using UnityEngine;
using UnityEngine.UI;

using CarPhotographer.Environments;

namespace CarPhotographer.IU
{
	public class UIEnvironmentEntry : MonoBehaviour
	{
		#region PROPERTIES
		public EnvironmentAsset asset { get; private set; }
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
			EnvironmentManager.instance.SelectEnvironment(asset);
		}
		#endregion


		#region PUBLIC API
		public void Initialise(EnvironmentAsset asset)
		{
			this.asset = asset;

			// TODO Assign all UI
			m_DisplayName.text = asset.environmentName;
			m_Thumbnail.sprite = asset.thumbnail;
		}
		#endregion
	}
}