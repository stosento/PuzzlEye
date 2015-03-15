using UnityEngine;
using System.Collections;

public class MediumButtonScript : MonoBehaviour {
		
	public void SetMediumDifficulty() {
		DifficultySelectionScript.Difficulty = DifficultySelectionScript.Difficulties.Medium;
		Application.LoadLevel (2);
	}

}
