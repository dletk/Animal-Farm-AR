using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wolfText : MonoBehaviour {

	public Button textButton;
	public Text displayText;
	public TextMesh textMesh;
	bool display = false;

	// Use this for initialization
	void Start() {
//		displayText.text = "";
		textMesh = GameObject.Find ("WolfText3D").GetComponent<TextMesh> ();
		textMesh.text = "";
		textButton.onClick.AddListener(DisplayText);
	}

	public void DisplayText() {
		if (!display) {
//			displayText.text = "Hey! This is a wolf!";
//			GetComponent<TextMesh> ().text = "Hello wolf";
			textMesh.text = "Hello Wolf";
			Debug.Log ("Touched");
			display = true;
		} else {
//			displayText.text = "";
			textMesh.text = "";
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
