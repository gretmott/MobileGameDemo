using UnityEngine;

namespace Lean.Touch
{
	// This script allows you to transform the current GameObject
	public class LeanTranslate : MonoBehaviour
	{
		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		[Tooltip("Allows you to force rotation with a specific amount of fingers (0 = any)")]
		public int RequiredFingerCount;

		[Tooltip("Does translation require an object to be selected?")]
		public LeanSelectable RequiredSelectable;

#if UNITY_EDITOR
		protected virtual void Reset()
		{
			if (RequiredSelectable == null)
			{
				RequiredSelectable = GetComponent<LeanSelectable>();
			}
		}
#endif

		protected virtual void Update()
		{
			// If we require a selectable and it isn't selected, cancel translation
			if (RequiredSelectable != null && RequiredSelectable.IsSelected == false)
			{
				return;
			}

			// Get the fingers we want to use
			var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount);

			// Calculate the screenDelta value based on these fingers
			var screenDelta = LeanGesture.GetScreenDelta(fingers);

			// Perform the translation
			Translate(screenDelta);
		}

		private void Translate(Vector2 screenDelta)
		{
			// Screen position of the transform
			var screenPosition = Camera.main.WorldToScreenPoint(transform.position);
			
			// Add the deltaPosition
			screenPosition += (Vector3)screenDelta;
			
			// Convert back to world space
			transform.position = Camera.main.ScreenToWorldPoint(screenPosition);
		}
	}
}