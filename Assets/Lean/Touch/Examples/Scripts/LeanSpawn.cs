using UnityEngine;
using System.Collections.Generic;

namespace Lean.Touch
{
	/// <summary>This component allows you to spawn a prefab at a point relative to a finger and the specified ScreenDepth.
	/// NOTE: To trigger the prefab spawn you must call the Spawn method on this component from somewhere.</summary>
	[HelpURL(LeanTouch.HelpUrlPrefix + "LeanSpawn")]
	public class LeanSpawn : MonoBehaviour
	{
		public enum RotateType
		{
			ThisTransform,
			ScreenDepthNormal
		}

		[Tooltip("The prefab that this component can spawn.")]
		public Transform Prefab;

		[Tooltip("The conversion method used to find a world point from a screen point.")]
		public LeanScreenDepth ScreenDepth;

		[Tooltip("How should the spawned prefab be rotated?")]
		public RotateType RotateTo;

		/// <summary>This will spawn Prefab at the specified finger based on the ScreenDepth setting.</summary>
		public virtual void Spawn(LeanFinger finger)
		{
			var instance = default(Transform);

			TrySpawn(finger, ref instance);
		}

		protected bool TrySpawn(LeanFinger finger, ref Transform instance)
		{
			if (Prefab != null && finger != null)
			{
				// Spawn and position
				instance = Instantiate(Prefab);

				UpdateSpawnedTransform(finger, instance);

				// Select?
				var selectable = instance.GetComponent<LeanSelectable>();

				if (selectable != null)
				{
					selectable.Select(finger);
				}

				return true;
			}

			return false;
		}

		protected void UpdateSpawnedTransform(LeanFinger finger, Transform instance)
		{
			var worldPoint = ScreenDepth.Convert(finger.ScreenPosition, gameObject, instance);

			instance.position = worldPoint;

			switch (RotateTo)
			{
				case RotateType.ThisTransform:
				{
					instance.rotation = transform.rotation;
				}
				break;

				case RotateType.ScreenDepthNormal:
				{
					instance.up = LeanScreenDepth.LastWorldNormal;
				}
				break;
			}
		}
	}
}