using UnityEngine;
using System.Collections;

public class Options: MonoBehaviour {
	public 	bool 	visible = false;
	private string	msg;
	private bool 	showbuttons = false;

	void Awake() {
		Application.targetFrameRate=30;
	}

	void OnGUI() {
		if (GUI.Button (new Rect (10,10,120,30), showbuttons?"Hide Menu":"Show Menu")) {
			showbuttons=!showbuttons;
		}
		if (showbuttons) {
			if (GUI.Button (new Rect (10,40,120,30), visible?"Hide Fingertips":"Show Fingertips")) {
				visible=!visible;
			}
			if (GUI.Button (new Rect (10,70,120,30), "Restart")) {
				Application.LoadLevel(Application.loadedLevel);
			}
			if (GUI.Button (new Rect (10,100,120,30), "Main Menu")) {
				Application.LoadLevel(0);
			}
			if (GUI.Button (new Rect (10,130,120,30), "Quit")) {
				if (GUI.Button (new Rect (10,130,120,30), "Are You Sure?"))
				Application.Quit();
			}
			if (GUI.Button (new Rect (5, 160, 130, 30), "Choose New Puzzle")) {
				Application.LoadLevel(2);		
			}
		}
	}
	public void SetMessage(string msg2) {
		msg=msg2;
	}
}
	