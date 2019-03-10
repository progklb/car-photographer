using UnityEngine;

using System.Linq;

namespace CarPhotographer.UI
{
	/// <summary>
	/// A controller for UI elements.
	/// </summary>
	public class UIController : MonoBehaviour
	{
		#region PROPERTIES
		public UIElement uiElement { get => UIElement.LoadingScreen; private set => m_UIElement = value; }
		#endregion


		#region VARIABLES
		[SerializeField]
		private UIElement m_UIElement;
		#endregion


		#region UNITY EVENTS
		void Start()
		{
			UIManager.instance.RegisterController(this);
		}

		void OnDestroy()
		{
			UIManager.instance.DeregisterController(this);
		}
		#endregion


		#region PUBLIC API
		public void ShowUI()
		{
			gameObject.SetActive(true);
		}

		public void HideUI()
		{
			gameObject.SetActive(false);
		}
		#endregion
	}
}