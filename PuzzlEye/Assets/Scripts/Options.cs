using UnityEngine;
using System.Collections;

public class Options: MonoBehaviour {
	public 	bool 	visible = false;
	private string	msg;
	private bool 	showbuttons = false;
	private bool	readytoquit = false;
	private GUIStyle largetext;

	void Awake() {
		Application.targetFrameRate=30;
	}

	void Start() {
		largetext = new GUIStyle("button");
		largetext.fontSize = 17;
		largetext.normal.textColor = Color.white;
	}

	void OnGUI() {
		if (GUI.Button (new Rect (10,10,130,100), showbuttons?"Hide Menu":"Show Menu")) {
			showbuttons=!showbuttons;
		}
		if (showbuttons) {
			GUI.color = Color.magenta;
			if (GUI.Button (new Rect (10,110,130,100), visible?"Hide Fingertips":"Show Fingertips", largetext)) {
				visible=!visible;
			}
			GUI.color = Color.green;
			if (GUI.Button (new Rect (10,210,130,100), "Restart", largetext)) {
				Application.LoadLevel(Application.loadedLevel);
			}
			GUI.color = Color.grey;
			if (GUI.Button (new Rect (10,310,130,100), "Main Menu", largetext)) {
				Application.LoadLevel(0);
			}
			GUI.color = Color.red;
			if (GUI.Button (new Rect (10,410,130,100), readytoquit?"Quit, Really?":"Quit", largetext)) {
				if (readytoquit)
					Application.Quit();
				else
					readytoquit=!readytoquit;
			}
			GUI.color = Color.cyan;
			if (GUI.Button (new Rect (10, 510, 130, 100), "New Puzzle", largetext)) {
				Application.LoadLevel(2);		
			}
		}
	}
	public void SetMessage(string msg2) {
		msg=msg2;
	}
}
	