using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class animalController : MonoBehaviour {

	private Rigidbody rigid;
	private Animation anim;
	private GameObject currentSelected;
	public Lean.Touch.LeanTapSelect selected;

	// Use this for initialization
	void Start () {
		Lean.Touch.LeanSelectable currentSelectable = selected.CurrentSelectable;
		currentSelected = currentSelectable.gameObject;

		rigid = currentSelected.GetComponent<Rigidbody> ();	
		anim = currentSelected.GetComponent<Animation> ();
	}

	void FindCurrentObject() {
		Lean.Touch.LeanSelectable currentSelectable = selected.CurrentSelectable;
		currentSelected = currentSelectable.gameObject;

		rigid = currentSelected.GetComponent<Rigidbody> ();	
		anim = currentSelected.GetComponent<Animation> ();
	}

	// Update is called once per frame
	void Update () {
		FindCurrentObject ();
		if (currentSelected != GameObject.Find("AnimalController")) {
			float x = CrossPlatformInputManager.GetAxis ("Horizontal");
			float y = CrossPlatformInputManager.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (x, 0, y);

			rigid.velocity = movement * 2f;

			if (x != 0 && y != 0) {
				currentSelected.transform.eulerAngles = new Vector3 (currentSelected.transform.eulerAngles.x, Mathf.Atan2 (x, y) * Mathf.Rad2Deg, currentSelected.transform.eulerAngles.z);
			}

			if (x != 0 || y != 0) {
				anim.Play ("Walk");
			} else {
				anim.Play ("Idle");
			}
		}
	}
}
