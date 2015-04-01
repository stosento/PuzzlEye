using UnityEngine;
using System.Collections;

public class EasyButtonScript : MonoBehaviour {

	public void SetEasyDifficulty() {
		DifficultySelectionScript.Difficulty = DifficultySelectionScript.Difficulties.Easy;
		Application.LoadLevel (2);
	}
}
