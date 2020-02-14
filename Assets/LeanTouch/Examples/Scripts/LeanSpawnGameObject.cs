using UnityEngine;
using System.Collections;

namespace Lean.Touch
{
	// This script can be used to spawn a GameObject via an event
	public class LeanSpawnGameObject : MonoBehaviour
	{
		[Tooltip("The prefab that gets spawned")]
		public GameObject Prefab;

		[Tooltip("The distance from the finger the prefab will be spawned in world space")]
		public float FingerDistance = 10.0f;
		
		public void Spawn()
		{
            Debug.Log("S");
			if (Prefab != null)
			{
				MF_AutoPool.Spawn(Prefab, transform.position, Quaternion.identity);
			}
		}

		public void Spawn(LeanFinger finger)
		{
           
            if (finger != null && Prefab != null)
			{
				MF_AutoPool.Spawn(Prefab, finger.GetWorldPosition(FingerDistance), Quaternion.identity);
                
            }
		}
	}
}