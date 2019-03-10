using UnityEngine;

using System;

namespace CarPhotographer.Scenes
{
	[Serializable]
	public class SceneSetConfig
	{
		#region PROPERTIES
		/// The collective set of scenes this instance represents.
		public SceneSet set { get => m_Set; private set => m_Set = value; }
		/// The list of scene names represented by this scene set.
		public string[] scenes { get => m_Scenes; private set => m_Scenes = value; }
		#endregion

		#region VARIABLES
		[SerializeField]
		private SceneSet m_Set;
		[SerializeField]
		private string[] m_Scenes;
		#endregion
	}
}