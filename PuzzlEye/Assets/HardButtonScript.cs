using UnityEngine;
using System.Collections;

public class HardButtonScript : MonoBehaviour {
	
	public void SetHardDifficulty() {
		DifficultySelectionScript.Difficulty = DifficultySelectionScript.Difficulties.Hard;
		Application.LoadLevel (2);
	}
}


