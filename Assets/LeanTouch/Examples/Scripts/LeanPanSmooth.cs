using UnityEngine;

namespace Lean.Touch
{
	// This script allows you to pan the current GameObject (e.g. camera) by dragging your finger(s)
	public class LeanPanSmooth : MonoBehaviour
	{
		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		[Tooltip("Ignore fingers if the finger count doesn't match? (0 = any)")]
		public int RequiredFingerCount;

		[Tooltip("The camera the pan will be calculated using (default = MainCamera)")]
		public Camera Camera;

		[Tooltip("The distance from the camera the world drag delta will be calculated from (this only matters for perspective cameras)")]
		public float Distance = 1.0f;

		[Tooltip("How quickly the zoom reaches the target value")]
		public float Dampening = 10.0f;

		[HideInInspector]
		public Vector3 RemainingDelta;

		protected virtual void LateUpdate()
		{
			// Get the fingers we want to use
			var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount);

			// Get the world delta of all the fingers
			var worldDelta = LeanGesture.GetWorldDelta(fingers, Distance, Camera);

			// Pan the camera based on the world delta
			RemainingDelta -= worldDelta;

			// The framerate independent damping factor
			var factor = Mathf.Exp(-Dampening * Time.deltaTime);

			// Dampen remainingDelta
			var newDelta = RemainingDelta * factor;

			// Shift this transform by the change in delta
			transform.position += RemainingDelta - newDelta;

			// Update remainingDelta with the dampened value
			RemainingDelta = newDelta;
		}
	}
}