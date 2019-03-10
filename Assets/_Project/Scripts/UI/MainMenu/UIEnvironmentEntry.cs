using UnityEngine;
using UnityEngine.UI;

using CarPhotographer.Environments;

namespace CarPhotographer.IU
{
	/// <summary>
	/// Controller for the UI used for representing an environment option.
	/// </summary>
	public class UIEnvironmentEntry : MonoBehaviour
	{
		#region PROPERTIES
		public EnvironmentAsset asset { get; private set; }
		#endregion


		#region VARIABLES
		[SerializeField]
		private Text m_Name = null;
		[SerializeField]
		private Image m_Image = null;
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
			m_Name.text = asset.environmentName;
			m_Image.sprite = asset.thumbnail;
		}
		#endregion
	}
}