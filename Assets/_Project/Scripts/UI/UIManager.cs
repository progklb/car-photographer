using UnityEngine;

using System.Collections.Generic;

using Utilities;

namespace CarPhotographer.UI
{
	/// <summary>
	/// A manager for high-level manager for providing control over UI.
	/// </summary>
	public sealed class UIManager : Singleton<UIManager>
	{
		#region PROPERTIES
		public Dictionary<UIElement, UIController> currentControllers { get; set; } = new Dictionary<UIElement, UIController>();
		#endregion


		#region PUBLIC API - REGISTRATIONS
		public void RegisterController(UIController controller)
		{
			if (!currentControllers.ContainsKey(controller.uiElement))
			{
				currentControllers.Add(controller.uiElement, controller);
			}
			else
			{
				Debug.LogError($"Cannot register controller of UI element {controller.uiElement} as an existing controller is already registered.");
			}
		}

		public void DeregisterController(UIController controller)
		{
			if (currentControllers.ContainsKey(controller.uiElement))
			{
				currentControllers.Remove(controller.uiElement);
			}
			else
			{
				Debug.LogError($"Cannot deregister controller of UI element {controller.uiElement} as there is no existing controller.");
			}
		}
		#endregion


		#region PUBLIC API - REGISTRATIONS
		public void ShowUI(UIElement uiElement)
		{
			if (currentControllers.ContainsKey(uiElement))
			{
				currentControllers[uiElement].ShowUI();
			}
		}

		public void HideUI(UIElement uiElement)
		{
			if (currentControllers.ContainsKey(uiElement))
			{
				currentControllers[uiElement].HideUI();
			}
		}
		#endregion
	}
}