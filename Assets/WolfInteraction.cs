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
//		Debug.Log ("-------> Distance: " + distanceToTiger);
		TextMesh wolfText = GameObject.Find ("WolfText3D").GetComponent<TextMesh> ();
		string potentialWarning;
		if (distanceToTiger < distanceToKitten) {
			potentialWarning = "Found Tiger";
		} else {
			potentialWarning = "Found Kitten";
		}
		if (distanceToTiger <= 5 || distanceToKitten <= 5) {
			wolfText.text = potentialWarning;
		} else {
			wolfText.text = "";
		}
	}
}
