using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public 	float	 secondsTaken = 0;
	public  float 	 minutesTaken = 0;
	public 	float 	 time;
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
		largetext.normal.textColor = Color.white;
	}

	void OnGUI() {
		if (secondsTaken > 60) {
			minutesTaken++;
			secondsTaken = 0;
		}
		
		if (minutesTaken > 0)
			GUI.Label(new Rect (630, 10, 230, 400), "Time : " + minutesTaken + ":" + secondsTaken);
		else
			GUI.Label(new Rect (630, 10, 230, 400), "Time : " + secondsTaken);
		
		if (gameover)
			EndGame ();
	}
	public void EndGame() {
		Debug.Log("Game Over");
		time = (minutesTaken * 60) + secondsTaken;
		GUI.Label(new Rect (600, 70, 500, 400), "Good Game!", largetext);
		GUI.Label(new Rect (530, 100, 500, 400), "Your Time: " + time, largetext);
		GUI.Label(new Rect (450, 550, 500, 400), "Press Restart or Menu to Play Again!", largetext);
	}
}