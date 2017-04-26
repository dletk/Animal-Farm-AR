using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfInteraction : MonoBehaviour {

	public Transform tigerPosition;
	public float distanceToTiger;

	// Use this for initialization
	void Start () {
		tigerPosition = GameObject.Find("tiger_idle").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		distanceToTiger = Vector3.Distance (gameObject.transform.position, tigerPosition.position);
//		Debug.Log ("-------> Distance: " + distanceToTiger);
		TextMesh wolfText = GameObject.Find ("WolfText3D").GetComponent<TextMesh> ();
		if (distanceToTiger <= 5) {
			wolfText.text = "Found Tiger";
		} else {
			wolfText.text = "";
		}
	}
}
