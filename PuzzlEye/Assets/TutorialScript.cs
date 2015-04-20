using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

	void OnGUI() {
		if (GUI.Button (new Rect (620,500,120,30), "I'm Done!")) {
			Application.LoadLevel(0);
		}
	}
}
