using UnityEngine;

namespace Lean.Touch
{
	// This script makes handling selectable actions easier
	[RequireComponent(typeof(LeanSelectable))]
	public class LeanSelectableBehaviour : MonoBehaviour
	{
		[System.NonSerialized]
		private LeanSelectable selectable;

		public LeanSelectable Selectable
		{
			get
			{
				if (selectable == null)
				{
					selectable = GetComponent<LeanSelectable>();
				}

				return selectable;
			}
		}

		protected virtual void OnEnable()
		{
			if (selectable == null)
			{
				selectable = GetComponent<LeanSelectable>();
			}

			// Hook LeanSelectable events
			selectable.OnSelect.AddListener(OnSelect);
			selectable.OnDeselect.AddListener(OnDeselect);
		}

		protected virtual void OnDisable()
		{
			if (selectable == null)
			{
				selectable = GetComponent<LeanSelectable>();
			}

			// Unhook LeanSelectable events
			selectable.OnSelect.RemoveListener(OnSelect);
			selectable.OnDeselect.RemoveListener(OnDeselect);
		}
		
		protected virtual void OnSelect(LeanFinger finger)
		{
		}

		protected virtual void OnDeselect()
		{
		}
	}
}