using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoScript : MonoBehaviour {

	// Use this for initialization
	private GameObject currentSelected;
	public Lean.Touch.LeanTapSelect selected;
	public Button infoButton;
	bool displayOn = false;
	GUIStyle currentStyle = null;
	Text displayText;

	void Start () {
		FindCurrentObject ();
		displayText = currentSelected.GetComponent<Text> ();
		infoButton.onClick.AddListener(DisplayText);
	}

	void FindCurrentObject() {
		Lean.Touch.LeanSelectable currentSelectable = selected.CurrentSelectable;
		currentSelected = currentSelectable.gameObject;    
	}

	void DisplayText(){
		if (displayOn) {
			displayOn = false;
			Debug.Log ("Info Displayed!");
		} else {
			displayOn = true;
		}
	}

	void OnGUI() {
		if (displayOn) {
			GUI.contentColor = Color.yellow;
			InitStyles();
			GUI.Box (new  Rect(600, 50, 700, 500), displayText.text, currentStyle);

		}
	}

	// Update is called once per frame
	void Update () {
		FindCurrentObject ();
		displayText = currentSelected.GetComponent<Text> ();
		Debug.Log("Info displayed!: " + displayText.text);
		infoButton.onClick.AddListener(DisplayText);

	}

	private void InitStyles()
	{
		if( currentStyle == null )
		{
			currentStyle = new GUIStyle( GUI.skin.box );
			currentStyle.fontSize = 30;
			currentStyle.wordWrap = true;
			currentStyle.alignment = TextAnchor.MiddleCenter;
			currentStyle.normal.background = MakeTex( 2, 2, new Color( 5/225f, 51/255f, 141f, 0.3f ) );
		}
	}

	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}

}

