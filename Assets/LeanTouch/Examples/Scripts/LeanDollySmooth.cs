using UnityEngine;

namespace Lean.Touch
{
	// This script allows you to smoothly dolly in/out the current GameObject (e.g. camera) by pinching your finger(s)
	public class LeanDollySmooth : MonoBehaviour
	{
		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		[Tooltip("Ignore fingers if the finger count doesn't match? (0 = any)")]
		public int RequiredFingerCount;

		[Tooltip("The direction and distance of the dolly movement based on pinching")]
		public Vector3 Vector = Vector3.forward;

		[Tooltip("If you want the mouse wheel to simulate pinching then set the strength of it here")]
		[Range(-1.0f, 1.0f)]
		public float WheelSensitivity;

		[Tooltip("How quickly the zoom reaches the target value")]
		public float Dampening = 10.0f;

		[HideInInspector]
		public Vector3 RemainingDelta;

		protected virtual void LateUpdate()
		{
			// Get the fingers we want to use
			var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount);

			// Get the world delta of all the fingers
			var pinch = LeanGesture.GetPinchRatio(fingers, WheelSensitivity);

			// Dolly the camera based on the pinch ratio
			RemainingDelta += Vector - Vector * pinch;

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