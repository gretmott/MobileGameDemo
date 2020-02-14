#if UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4
	#define UNITY_OLD_LINE_RENDERER
#endif
using UnityEngine;
using System.Collections.Generic;

namespace Lean.Touch
{
	// This script will draw the path each finger has taken since it started being pressed
	public class LeanDragTrail : MonoBehaviour
	{
		// This class will store an association between a Finger and a LineRenderer instance
		[System.Serializable]
		public class Link
		{
			// The finger associated with this link
			public LeanFinger Finger;

			// The LineRenderer instance associated with this link
			public LineRenderer Line;
		}

		[Tooltip("The line prefab")]
		public LineRenderer Prefab;

		[Tooltip("The distance from the camera the line points will be spawned in world space")]
		public float Distance = 1.0f;

		// This stores all the links between Fingers and LineRenderer instances
		private List<Link> links = new List<Link>();
	
		protected virtual void OnEnable()
		{
			// Hook events
			LeanTouch.OnFingerSet += OnFingerSet;
			LeanTouch.OnFingerUp  += OnFingerUp;
		}

		protected virtual void OnDisable()
		{
			// Unhook events
			LeanTouch.OnFingerSet -= OnFingerSet;
			LeanTouch.OnFingerUp  -= OnFingerUp;
		}

		// Override the WritePositions method from LeanDragLine
		protected virtual void WritePositions(LineRenderer line, LeanFinger finger)
		{
			// Reserve one vertex for each snapshot
#if UNITY_OLD_LINE_RENDERER
			line.SetVertexCount(finger.Snapshots.Count);
#else
			line.positionCount = finger.Snapshots.Count;
#endif
			// Loop through all snapshots
			for (var i = 0; i < finger.Snapshots.Count; i++)
			{
				var snapshot = finger.Snapshots[i];
				
				// Get the world postion of this snapshot
				var position = snapshot.GetWorldPosition(Distance);

				// Write position
				line.SetPosition(i, position);
			}
		}

		private void OnFingerSet(LeanFinger finger)
		{
			// Make sure the prefab exists
			if (Prefab != null)
			{
				// Try and find the link for this finger
				var link = links.Find(l => l.Finger == finger);

				// Link doesn't exist?
				if (link == null)
				{
					// Make new link
					link = new Link();

					// Assign this finger to this link
					link.Finger = finger;

					// Create LineRenderer instance for this link
					link.Line = Instantiate(Prefab);
					
					// Add new link to list
					links.Add(link);
				}

				WritePositions(link.Line, link.Finger);
			}
		}

		private void OnFingerUp(LeanFinger finger)
		{
			// Try and find the link for this finger
			var link = links.Find(l => l.Finger == finger);

			// Link exists?
			if (link != null)
			{
				// Remove link from list
				links.Remove(link);

				// Destroy line GameObject
				Destroy(link.Line.gameObject);
			}
		}
	}
}