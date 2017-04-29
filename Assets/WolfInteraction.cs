using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfInteraction : MonoBehaviour {

	public Transform tigerTransform;
	public float distanceToTiger;
	public Transform kittenTransform;
	public float distanceToKitten;

	// Use this for initialization
	void Start () {
		tigerTransform = GameObject.Find ("tiger_idle").GetComponent<Transform> ();
		kittenTransform = GameObject.Find ("kitten").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		distanceToTiger = Vector3.Distance (gameObject.transform.position, tigerTransform.position);
		distanceToKitten = Vector3.Distance (gameObject.transform.position, kittenTransform.position);
		TextMesh wolfText = GameObject.Find ("WolfText3D").GetComponent<TextMesh> ();
		string potentialWarning;
		if (distanceToTiger < distanceToKitten) {
			potentialWarning = "Found Tiger";
		} else {
			potentialWarning = "Found Kitten";
		}
		if (distanceToTiger <= 5 || distanceToKitten <= 5) {
			wolfText.text = potentialWarning;
			if (potentialWarning == "Found Tiger") {
//				GameObject.Find ("tiger_idle").GetComponent<Animation> ().Play ("sound");
				GameObject tiger = GameObject.Find("tiger_idle");
				// Make the tiger use the running animation
				tiger.GetComponent<Animation> ().Play ("Run");
				// Find the direction from the tiger to the wolf
				Vector3 direction = (gameObject.transform.position - tiger.transform.position).normalized;
				// Moving the tiger along the direction
				tiger.transform.position += direction * 0.03f;
				// Rotate the tiger so its face will be toward the wolf
				tiger.transform.eulerAngles = new Vector3 (tiger.transform.eulerAngles.x, Mathf.Atan2 (direction.x, direction.z) * Mathf.Rad2Deg, tiger.transform.eulerAngles.z);
			} else {
				GameObject.Find ("kitten").GetComponent<Animation> ().Play ("IdleSit");
			}
		} else {
			wolfText.text = "";
			GameObject.Find("kitten").GetComponent<Animation>().Play("Idle");
			GameObject.Find ("tiger_idle").GetComponent<Animation> ().Play ("idle");
		}
	}
}
