using UnityEngine;

namespace Lean.Touch
{
	// This script will zoom the main camera based on finger gestures
	public class LeanSideCamera2D : MonoBehaviour
	{
		[Tooltip("The camera we will be moving")]
		public Camera Camera;

		[Tooltip("The minimum field of view angle we want to zoom to")]
		public float Minimum = 10.0f;
		
		[Tooltip("The maximum field of view angle we want to zoom to")]
		public float Maximum = 60.0f;
		
		protected virtual void LateUpdate()
		{
			// If camera is null, try and get the main camera, return true if a camera was found
			if (LeanTouch.GetCamera(ref Camera) == true)
			{
				// Get the world delta of all the fingers
				var worldDelta = LeanGesture.GetWorldDelta(1.0f, Camera); // Distance doesn't matter with an orthographic camera
				
				// Subtract the delta to the position
				Camera.transform.position -= worldDelta;
				
				// Store the old size in a temp variable
				var orthographicSize = Camera.orthographicSize;

				// Scale the size based on the pinch scale
				orthographicSize *= LeanGesture.GetPinchRatio();
					
				// Clamp the size to out min/max values
				orthographicSize = Mathf.Clamp(orthographicSize, Minimum, Maximum);

				// Set the new size
				Camera.orthographicSize = orthographicSize;
			}
		}
	}
}