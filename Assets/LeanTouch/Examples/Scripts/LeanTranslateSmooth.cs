using UnityEngine;

namespace Lean.Touch
{
	// This script allows you to transform the current GameObject with smoothing
	public class LeanTranslateSmooth : MonoBehaviour
	{
		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		[Tooltip("Allows you to force rotation with a specific amount of fingers (0 = any)")]
		public int RequiredFingerCount;

		[Tooltip("Does translation require an object to be selected?")]
		public LeanSelectable RequiredSelectable;
		
		[Tooltip("How smoothly this object moves to its target position")]
		public float Smoothness = 10.0f;

		// The position we still need to add
		private Vector3 remainingDelta;

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

		protected virtual void LateUpdate()
		{
			// The framerate independent damping factor
			var factor = Mathf.Exp(-Smoothness * Time.deltaTime);

			// Dampen remainingDelta
			var newDelta = remainingDelta * factor;

			// Shift this transform by the change in delta
			transform.position += remainingDelta - newDelta;

			// Update remainingDelta with the dampened value
			remainingDelta = newDelta;
		}

		private void Translate(Vector2 screenDelta)
		{
			// Store old position
			var oldPosition = transform.position;

			// Screen position of the transform
			var screenPosition = Camera.main.WorldToScreenPoint(oldPosition);
			
			// Add the deltaPosition
			screenPosition += (Vector3)screenDelta;
			
			// Convert back to world space
			var newPosition = Camera.main.ScreenToWorldPoint(screenPosition);
			var delPosition = newPosition - oldPosition;

			// Add to delta
			remainingDelta += delPosition;
		}
	}
}