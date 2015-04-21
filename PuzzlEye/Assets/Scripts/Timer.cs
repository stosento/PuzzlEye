using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public 	float	 secondsTaken = 0;
	public  float 	 minutesTaken = 0;
	public 	bool	 gameover = false;
	public 	GUIStyle largetext;


	void Update() {
		if (!gameover) {
			secondsTaken += Time.deltaTime;
		}
	}

	void Start() {
		largetext = new GUIStyle();
		largetext.fontSize = 30;
		largetext.normal.textColor = Color.black;
	}

	void OnGUI() {
		GUI.color = Color.black;

		if (secondsTaken > 60) {
			minutesTaken++;
			secondsTaken = 0;
		}
		
		if (minutesTaken > 0)
		else
		
		if (gameover)
			EndGame ();
	}
	public void EndGame() {
		GUI.Label(new Rect (600, 70, 500, 400), "Good Game!", largetext);
		GUI.Label(new Rect (530, 100, 500, 400), "Your Time: " + minutesTaken + ":" + secondsTaken, largetext);
		GUI.Label(new Rect (450, 670, 500, 400), "Press Restart or Menu to Play Again!", largetext);
	}
}