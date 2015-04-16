using UnityEngine;
using System.Collections;

public class Options: MonoBehaviour {
	public 	bool 	visible;
	private string	msg;

	void Awake() {
		Application.targetFrameRate=30;
	}

	void OnGUI() {
		if (GUI.Button (new Rect (10,10,120,30), visible?"Hide Fingertips":"Show Fingertips")) {
			visible=!visible;
		}
		if (GUI.Button (new Rect (10,40,120,30), "Restart")) {
			Application.LoadLevel(Application.loadedLevel);
		}
		if (GUI.Button (new Rect (10,70,120,30), "Main Menu")) {
			Application.LoadLevel(0);
		}
		if (GUI.Button (new Rect (10,100,120,30), "Quit")) {
			Application.Quit();
		}

		if (GUI.Button (new Rect (5, 130, 130, 30), "Choose New Puzzle")) {
			Application.LoadLevel(2);		
		}
		
		GUI.Label(new Rect(10, 160, 230, 400), 
			msg!=null?msg:"Instructions: Show your hand(s) to the camera, "+
			"and use your fingertips to interact with the puzzle pieces.\n\n"+
			"Challenge: Use your finger to select a piece, pinch to release.\n\n" +
			"Click restart to reset the pieces as well as the timer. Enjoy!");
	}
	public void SetMessage(string msg2) {
		msg=msg2;
	}
}
	