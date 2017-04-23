using UnityEngine;

namespace Lean.Touch
{
	// This script allows you to dolly in/out the current GameObject (e.g. camera) by pinching your finger(s)
	public class LeanDolly : MonoBehaviour
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

		protected virtual void LateUpdate()
		{
			// Get the fingers we want to use
			var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount);

			// Get the world delta of all the fingers
			var pinch = LeanGesture.GetPinchRatio(fingers, WheelSensitivity);

			// Dolly the camera based on the pinch ratio
			transform.position += Vector - Vector * pinch;
		}
	}
}