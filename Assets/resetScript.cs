using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetScript : MonoBehaviour {

//	public GameObject gameObj;
	// Use this for initialization
	public Button resetButton;

	void Start () {
		resetButton.onClick.AddListener(ResetPos);
	}

	void ResetPos(){
		GameObject.Find("Wolf").transform.position = GameObject.Find("WolfImageTarget").GetComponent<Transform>().position;
		GameObject.Find("Tiger").transform.position = GameObject.Find("TigerImageTarget").GetComponentInParent<Transform>().position;
		GameObject.Find("Kitten").transform.position = GameObject.Find("KittenImageTarget").GetComponentInParent<Transform>().position;
		GameObject.Find("Horse").transform.position = GameObject.Find("HorseImageTarget").GetComponentInParent<Transform>().position;
//		GameObject.Find ("Wolf").transform.rotation = Quaternion.identity;
//		GameObject.Find("Tiger").transform.rotation = Quaternion.identity;
//		GameObject.Find("Kitten").transform.rotation = Quaternion.identity;
//		GameObject.Find("Horse").transform.rotation = Quaternion.identity;
		Debug.Log ("Reset!");
	}
	
	// Update is called once per frame
	void Update () {
	}
}
