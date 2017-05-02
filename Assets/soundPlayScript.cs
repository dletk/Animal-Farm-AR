using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundPlayScript : MonoBehaviour {

	// Use this for initialization
	private GameObject currentSelected;
	public Lean.Touch.LeanTapSelect selected;
	public Button soundButton;

	void Start () {
		Lean.Touch.LeanSelectable currentSelectable = selected.CurrentSelectable;
		currentSelected = currentSelectable.gameObject;
		soundButton.onClick.AddListener(PlaySound);
	}

	void FindCurrentObject() {
		Lean.Touch.LeanSelectable currentSelectable = selected.CurrentSelectable;
		currentSelected = currentSelectable.gameObject;	
	}

	void PlaySound(){
		currentSelected.GetComponent<AudioSource> ().Play ();
		Debug.Log ("Sound Played!");
	}
	
	// Update is called once per frame
	void Update () {
		FindCurrentObject ();
		soundButton.onClick.AddListener(PlaySound);
	}
}
