using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wolfText : MonoBehaviour {

	public Button textButton;
	public Text displayText;
	bool display = false;

	// Use this for initialization
	void Start() {
		displayText.text = "";
		textButton.onClick.AddListener(DisplayText);
	}

	public void DisplayText() {
		if (!display) {
			displayText.text = "Hey! This is a wolf!";
			Debug.Log ("Touched");
			display = true;
		} else {
			displayText.text = "";
			display = false;
		}
	}


//	void OnGUI()
//	{
//		if (display) {
//			// If you've clicked the object, show this button
//			GUI.Label (new Rect (100, 100, 100, 20), "Hello World");
//			display = false;
////			Debug.Log("Touched!");
//		}
//	}
//
	// Update is called once per frame
	void Update () {

	}
			
}
