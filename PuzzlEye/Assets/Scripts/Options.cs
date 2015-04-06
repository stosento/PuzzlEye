using UnityEngine;
using System.Collections;

public class Options: MonoBehaviour {
	public 	bool 	visible;
	public 	float	secondsTaken = 0;
	private float 	minutesTaken = 0;
	private string	msg;
	public GUIStyle largetext;
	public float time;
	
	void Awake() {
		Application.targetFrameRate=30;
	}

	void Update() {
		if (!GameOver()) {
			secondsTaken += Time.deltaTime;
		}
	}

	void Start() {
		largetext = new GUIStyle();
		largetext.fontSize = 30;
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
		
		GUI.Label(new Rect(10, 130, 230, 400), 
			msg!=null?msg:"Instructions: Show your hand(s) to the camera, "+
			"and use your fingertips to interact with the colored balls.\n\n"+
			"Challenge: Use your finger to select a ball, pinch to release.\n\n" +
			"Tips: If all balls disappear (out of screen). Click restart to resume.");

		if (secondsTaken > 60) {
			minutesTaken++;
			secondsTaken = 0;
		}

		if (minutesTaken > 0)
			GUI.Label(new Rect (620, 10, 230, 400), "Time : " + minutesTaken + ":" + secondsTaken);
		else
			GUI.Label(new Rect (620, 10, 230, 400), "Time : " + secondsTaken);

		if (GameOver()) {
			Debug.Log("Game Over");
			time = (minutesTaken * 60) + secondsTaken;
			GUI.Label(new Rect (400, 250, 500, 400), "Good Game! Press Restart to Play Again!", largetext);
			GUI.Label(new Rect (400, 300, 500, 400), "Your Time: " + time + ". Nice Work!", largetext);
		}
	}
	public void SetMessage(string msg2) {
		msg=msg2;
	}
	private bool GameOver() {
		/*GameObject go = GameObject.FindWithTag("Balls");
		if (go == null) return true;*/
		return false;
	}
	private IEnumerator Pause(int p) {
		Time.timeScale = 0.1f;
		float pauseEndTime = Time.realtimeSinceStartup + 1;
		while (Time.realtimeSinceStartup < pauseEndTime)
			yield return 0;
		Time.timeScale = 1;
	}
}
	