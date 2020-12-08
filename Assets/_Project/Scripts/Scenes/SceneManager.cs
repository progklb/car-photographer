using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Utilities.Frameworks;

using USceneManager = UnityEngine.SceneManagement.SceneManager;
using LoadSceneMode = UnityEngine.SceneManagement.LoadSceneMode;

namespace CarPhotographer.Scenes
{
	/// <summary>
	/// A high-level manager for providing control over scenes.
	/// </summary>
	public sealed class SceneManager : Singleton<SceneManager>
	{
		#region PROPERTIES
		/// Raised when a scene set is successfully loaded.
		public static Action<SceneSet> onSceneSetLoaded = delegate { };
		/// Raised when a scene set is successfully unloaded.
		public static Action<SceneSet> onSceneSetUnloaded = delegate { };
		#endregion


		#region PROPERTIES
		/// A list of the currently loaded scene sets.
		public List<SceneSet> currentSceneSets { get; private set; } = new List<SceneSet>();
		/// The available configurations of scene sets that can be loaded.
		private SceneSetConfig[] sceneSet { get => m_SceneSet; set => m_SceneSet = value; }
		#endregion


		#region VARIABLES
		[SerializeField]
		private SceneSetConfig[] m_SceneSet = new SceneSetConfig[0];
		#endregion


		#region PUBLIC API
		public void LoadScene(string sceneName, Action callback = null)
		{
			StartCoroutine(LoadSceneCoroutine(sceneName, callback));
		}

		public void LoadScene(SceneSet set, Action callback = null)
		{
			if (!HasLoaded(set))
			{
				StartCoroutine(LoadSceneCoroutine(set, callback));
			}
			else
			{
				Debug.LogError($"Cannot load scene set {set} as it is already loaded.");
			}
		}

		public void UnloadScene(string sceneName, Action callback = null)
		{
			StartCoroutine(UnloadSceneCoroutine(sceneName, callback));
		}

		public void UnloadScene(SceneSet set, Action callback = null)
		{
			if (HasLoaded(set))
			{
				StartCoroutine(UnloadSceneCoroutine(set, callback));
			}
			else
			{
				Debug.LogError($"Cannot unload scene set {set} as it is not currently loaded.");
			}
		}

		public bool HasLoaded(SceneSet set)
		{
			return currentSceneSets.Contains(set);
		}
		#endregion


		#region HELPER FUNCTIONS
		SceneSetConfig GetSceneConfig(SceneSet set)
		{
			return sceneSet.First(x => x.set == set);
		}

		IEnumerator LoadSceneCoroutine(SceneSet set, Action callback = null)
		{
			var sceneSet = GetSceneConfig(set);

			foreach (var sceneName in sceneSet.scenes)
			{
				yield return LoadSceneCoroutine(sceneName);
			}

			currentSceneSets.Add(set);

			callback?.Invoke();

			onSceneSetLoaded(set);
		}

		IEnumerator LoadSceneCoroutine(string sceneName, Action callback = null)
		{
			var asyncOp = USceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
			yield return new WaitUntil(() => asyncOp.isDone);
			callback?.Invoke();
		}

		IEnumerator UnloadSceneCoroutine(SceneSet set, Action callback = null)
		{
			var sceneSet = GetSceneConfig(set);

			foreach (var sceneName in sceneSet.scenes)
			{
				yield return UnloadSceneCoroutine(sceneName);
			}

			currentSceneSets.Remove(set);

			callback?.Invoke();

			onSceneSetUnloaded(set);
		}

		IEnumerator UnloadSceneCoroutine(string sceneName, Action callback = null)
		{
			var asyncOp = USceneManager.UnloadSceneAsync(sceneName);
			yield return new WaitUntil(() => asyncOp.isDone);
			callback?.Invoke();
		}
		#endregion
	}
}