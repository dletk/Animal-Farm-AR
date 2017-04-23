using UnityEngine;

namespace Lean.Touch
{
	// This script allows you to pan the current GameObject (e.g. camera) by dragging your finger(s)
	public class LeanPan : MonoBehaviour
	{
		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		[Tooltip("Ignore fingers if the finger count doesn't match? (0 = any)")]
		public int RequiredFingerCount;

		[Tooltip("The camera the pan will be calculated using (default = MainCamera)")]
		public Camera Camera;

		[Tooltip("The distance from the camera the world drag delta will be calculated from (this only matters for perspective cameras)")]
		public float Distance = 1.0f;
		
		protected virtual void LateUpdate()
		{
			// Get the fingers we want to use
			var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount);

			// Get the world delta of all the fingers
			var worldDelta = LeanGesture.GetWorldDelta(fingers, Distance, Camera);
			
			// Pan the camera based on the world delta
			transform.position -= worldDelta;
		}
	}
}