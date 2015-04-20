using UnityEngine;
using System.Collections;

public class Options: MonoBehaviour {
	public 	bool 	visible = false;
	private string	msg;
	private bool 	showbuttons = false;
	private bool	readytoquit = false;

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
			if (GUI.Button (new Rect (10,130,130,30), readytoquit?"Press Again to Quit":"Quit")) {
				if (readytoquit)
					Application.Quit();
				else
					readytoquit=!readytoquit;
			}
			if (GUI.Button (new Rect (10, 160, 130, 30), "Choose New Puzzle")) {
				Application.LoadLevel(2);		
			}
		}
	}
	public void SetMessage(string msg2) {
		msg=msg2;
	}
}
	