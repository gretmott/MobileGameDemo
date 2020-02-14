using UnityEngine;
using UnityEngine.Events;

namespace Lean.Touch
{
	// This script allows you to select this GameObject via another component
	public class LeanSelectable : MonoBehaviour
	{
		// Event signature
		[System.Serializable] public class LeanFingerEvent : UnityEvent<LeanFinger> {}

		[Tooltip("Is this GameObject currently selected? NOTE: Don't modify this from the inspector")]
		public bool IsSelected;

		// The finger that selected this
		[System.NonSerialized]
		public LeanFinger Finger;
		
		public LeanFingerEvent OnSelect;

		public UnityEvent OnDeselect;
		
		[ContextMenu("Select")]
		public void Select()
		{
			Select(null);
		}

		public void Select(LeanFinger finger)
		{
			if (IsSelected == false)
			{
				IsSelected = true;
				Finger     = finger;

				OnSelect.Invoke(finger);
			}
		}

		[ContextMenu("Deselect")]
		public void Deselect()
		{
			if (IsSelected == true)
			{
				OnDeselect.Invoke();
				
				Finger     = null;
				IsSelected = false;
			}
		}
	}
}