using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalInteraction : MonoBehaviour {

	public GameObject tiger;
	public GameObject wolf;
	public GameObject kitten;
	public GameObject horse;

	public Lean.Touch.LeanSelect selectControl;

	private GameObject currentSelected;
	private GameObject reactor;

	private float distanceToWolf;
	private float distanceToTiger;
	private float distanceToKitten;
	private float distanceToHorse;

	// Use this for initialization
	void Start () {
		FindCurrentSelected ();
	}

	void FindCurrentSelected() {
		Lean.Touch.LeanSelectable currentSelectable = selectControl.CurrentSelectable;
		currentSelected = currentSelectable.gameObject;
	}

	// Update is called once per frame
	void Update () {
		FindCurrentSelected ();
		DetermineReactor ();
		if (currentSelected != null && reactor != null) {
			distanceToTiger = Vector3.Distance (currentSelected.transform.position, tiger.transform.position);
			distanceToKitten = Vector3.Distance (currentSelected.transform.position, kitten.transform.position);
			distanceToWolf = Vector3.Distance (currentSelected.transform.position, wolf.transform.position);
			distanceToHorse = Vector3.Distance (currentSelected.transform.position, horse.transform.position);
			if (reactor == tiger) {
				if (currentSelected == kitten || currentSelected == horse) {
					ReactorChase ();
				} else {
					ReactorRunAway ();
				}
			} else if (reactor == wolf) {
				// Do something
			} else if (reactor == kitten) {
				// Do something
			} else if (reactor == horse) {
				// Do something
			} else {
			}
//			TextMesh wolfText = GameObject.Find ("WolfText3D").GetComponent<TextMesh> ();
//			string potentialWarning;
//			if (distanceToTiger < distanceToKitten) {
//				potentialWarning = "Found Tiger";
//			} else {
//				potentialWarning = "Found Kitten";
//			}
//			if (distanceToTiger <= 5 || distanceToKitten <= 5) {
//				wolfText.text = potentialWarning;
//				if (potentialWarning == "Found Tiger") {
//					//				GameObject.Find ("tiger_idle").GetComponent<Animation> ().Play ("sound");
//					GameObject tiger = GameObject.Find ("tiger_idle");
//					// Make the tiger use the running animation
//					tiger.GetComponent<Animation> ().Play ("Run");
//					// Find the direction from the tiger to the wolf
//					Vector3 direction = (gameObject.transform.position - tiger.transform.position).normalized;
//					// Moving the tiger along the direction
//					tiger.transform.position += direction * 0.03f;
//					// Rotate the tiger so its face will be toward the wolf
//					tiger.transform.eulerAngles = new Vector3 (tiger.transform.eulerAngles.x, Mathf.Atan2 (direction.x, direction.z) * Mathf.Rad2Deg, tiger.transform.eulerAngles.z);
//				} else {
//					GameObject.Find ("kitten").GetComponent<Animation> ().Play ("IdleSit");
//				}
//			} else {
//				wolfText.text = "";
//				GameObject.Find ("kitten").GetComponent<Animation> ().Play ("Idle");
//				GameObject.Find ("tiger_idle").GetComponent<Animation> ().Play ("Idle");
//			}
		}
	}
		
	void DetermineReactor() {
		float minDistance = DetermineMinDistance ();
		if (minDistance == distanceToWolf) {
			reactor = wolf;
		} else if (minDistance == distanceToTiger) {
			reactor = tiger;
		} else if (minDistance == distanceToKitten) {
			reactor = kitten;
		} else if (minDistance == distanceToHorse) {
			reactor = horse;
		} else {
			reactor = null;
		}
	}

	float DetermineMinDistance() {
		float minDistance;
		if (currentSelected == tiger) {
			minDistance = Mathf.Min (Mathf.Min (distanceToWolf, distanceToHorse), distanceToKitten);
		} else if (currentSelected == wolf) {
			minDistance = Mathf.Min (Mathf.Min (distanceToTiger, distanceToHorse), distanceToKitten);
		} else if (currentSelected == kitten) {
			minDistance = Mathf.Min (Mathf.Min (distanceToTiger, distanceToWolf), distanceToHorse);
		} else {
			minDistance = Mathf.Min (Mathf.Min (distanceToTiger, distanceToWolf), distanceToKitten);
		}
		return minDistance;
	}

	void ReactorChase() {
		float chaseVelocity = 0.03f;
		reactor.GetComponent<Animation> ().Play ("Run");
		// Find the direction from the reactor to the currentSelected animal
		Vector3 direction = (currentSelected.transform.position - tiger.transform.position).normalized;
		// Moving the reactor along the direction
		reactor.transform.position += direction * chaseVelocity;
		// Rotate the reactor so its face will be toward the currentSelected animal
		reactor.transform.eulerAngles = new Vector3 (reactor.transform.eulerAngles.x, Mathf.Atan2 (direction.x, direction.z) * Mathf.Rad2Deg, reactor.transform.eulerAngles.z);
	}

	void ReactorRunAway() {
		float runAwayVelocity = 0.05f;
		reactor.GetComponent<Animation> ().Play ("Run");
		// Find the direction from the currentSelected to the reactor
		Vector3 direction = (reactor.transform.position - currentSelected.transform.position).normalized;
		// Moving the reactor along this direction to get futher away from the chaser
		reactor.transform.position += direction * runAwayVelocity;
		// Rotate the reactor so its face will toward the direction it is running
		reactor.transform.eulerAngles = new Vector3(reactor.transform.eulerAngles.x, Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg, reactor.transform.eulerAngles.z);
	}
}
