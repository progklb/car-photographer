using UnityEngine;

using Utilities;

using System;

using CarPhotographer.Scenes;

namespace CarPhotographer.Environments
{
	/// <summary>
	/// A high-level manager for providing control over environments.
	/// </summary>
	public class EnvironmentManager : Singleton<EnvironmentManager>
	{
		#region CONSTANTS
		/// File path in Resources where assets are store d.
		public const string ENVIRONMENT_ASSET_PATH = "Environment Assets";
		#endregion


		#region EVENTS
		/// Raised when <see cref="SelectEnvironment(EnvironmentAsset)"/> is called.
		public static event Action<EnvironmentAsset> onEnvironmentSelected = delegate { };
		/// Raised when <see cref="LoadSelectedEnvironment"/> begins loading an environment.
		public static event Action<EnvironmentAsset> onEnvironmentBeginLoading = delegate { };
		/// Raised when <see cref="LoadSelectedEnvironment"/> finishes loading an environment.
		public static event Action<EnvironmentAsset> onEnvironmentFinishedLoading = delegate { };
		/// Raised when <see cref="UnloadSelectedEnvironment"/> is called.
		public static event Action<EnvironmentAsset> onEnvironmentUnload = delegate { };
		#endregion


		#region PROPERTIES
		public EnvironmentController currentController { get; private set; }

		public EnvironmentAsset selectedEnvironment { get; private set; }

		public bool hasLoadedEnvironment { get => currentController != null; }
		#endregion


		#region PUBLIC API - CONTROLLERS
		public void RegisterController(EnvironmentController controller)
		{
			if (currentController != null)
			{
				Debug.LogError("Controller attempted to register itself while another controller is still active. Please deregister any existing controllers first.");
				return;
			}

			currentController = controller;
		}

		public void DeregisterController(EnvironmentController controller)
		{
			if (currentController != controller)
			{
				Debug.LogError("Cannot deregister controller as the provided controller is not the active controller.");
				return;
			}

			currentController = null;
		}
		#endregion



		#region PUBLIC API - ASSETS
		public static EnvironmentAsset[] GetEnvironmentAssets()
		{
			return Resources.LoadAll<EnvironmentAsset>(ENVIRONMENT_ASSET_PATH);
		}

		public static void UnloadEnvironmentAssets()
		{
			// Unity throws an error when unloading a specified resource.
			// Let's just release all unused assets instead.
			Resources.UnloadUnusedAssets();
		}

		public void SelectEnvironment(EnvironmentAsset asset)
		{
			selectedEnvironment = asset;
			onEnvironmentSelected(asset);
		}

		public void LoadSelectedEnvironment()
		{
			if (selectedEnvironment != null)
			{
				onEnvironmentBeginLoading(selectedEnvironment);
				SceneManager.instance.LoadScene(selectedEnvironment.sceneName, () =>  {
					onEnvironmentFinishedLoading(selectedEnvironment);
				});
			}
			else
			{
				Debug.LogError("No selected environment to load. Please set an environment before attempting to load.");
			}
		}

		public void UnloadSelectedEnvironment()
		{
			onEnvironmentUnload(selectedEnvironment);
			SceneManager.instance.UnloadScene(selectedEnvironment.sceneName);
		}
		#endregion
	}
}