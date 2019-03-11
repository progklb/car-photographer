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
		public UIElement uiElement { get => m_UIElement; private set => m_UIElement = value; }
		#endregion


		#region VARIABLES
		[SerializeField]
		private UIElement m_UIElement;

		[SerializeField]
		private GameObject m_Root;
		#endregion


		#region UNITY EVENTS
		void Start()
		{
			if (m_Root == null)
			{
				m_Root = gameObject;
			}

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
			m_Root.SetActive(true);
		}

		public void HideUI()
		{
			m_Root.SetActive(false);
		}
		#endregion
	}
}