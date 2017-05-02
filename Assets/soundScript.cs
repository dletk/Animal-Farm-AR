using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundScript : MonoBehaviour {

	//	public GameObject gameObj;
	// Use this for initialization
	public Button soundButton;
	public GameObject gameObject;

	void Start () {
		soundButton.onClick.AddListener(PlaySound);
	}

	void PlaySound(){
		gameObject.GetComponent<AudioSource> ().Play ();
		Debug.Log ("Sound Played!");
	}

	// Update is called once per frame
	void Update () {
	}
}

