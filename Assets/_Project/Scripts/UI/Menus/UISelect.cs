using UnityEngine;

namespace CarPhotographer.IU
{
	/// <summary>
	/// Controller for displaying/selecting from a set of options.
	/// </summary>
	public abstract class UISelect : MonoBehaviour
	{
		#region PROPERTIES
		/// Indicates whether this instance has been initialised.
		protected bool isInitialised { get; set; }
		/// The parent of the content displayed by this instance.
		protected Transform contentParent { get => m_ContentParent ?? (m_ContentParent = transform); }
		#endregion


		#region VARIABLES
		[SerializeField]
		private Transform m_ContentParent = null;
		#endregion


		#region UNITY EVENTS
		protected void Start()
		{
			if (!isInitialised)
			{
				Initialise();
			}
		}
		#endregion


		#region HELPER FUNCTIONS
		/// <summary>
		/// Initialises this instance.
		/// </summary>
		protected abstract void Initialise();

		/// <summary>
		/// Detroys all current children of the <see cref="contentParent"/>.
		/// </summary>
		protected void ClearContent()
		{
			for (int i = contentParent.childCount - 1; i >= 0; --i)
			{
				Destroy(contentParent.GetChild(i).gameObject);
			}
		}
		#endregion
	}
}