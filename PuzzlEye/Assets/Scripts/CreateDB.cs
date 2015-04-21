using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;


public class CreateDB : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DataService ds = new DataService ("PuzzlEye.db");
		ds.createDB ();

		User u = ds.getUser ("test");
		ToConsole (u.ToString ());

		IEnumerable<UserScore> scores = ds.getUserScores ("test");
		ToConsole (scores);
	}
	
	/*private void ToConsole(IEnumerable<PuzzleImage> puzzleImages) {
		foreach (PuzzleImage pi in puzzleImages) {
			ToConsole (pi.ToString());
		}
	}*/

	private void ToConsole(IEnumerable<UserScore> scores) {
		foreach (UserScore score in scores) {
			ToConsole (score.ToString());
		}
	}

	private void ToConsole(string msg) {
		Debug.Log (msg);
	}
}
