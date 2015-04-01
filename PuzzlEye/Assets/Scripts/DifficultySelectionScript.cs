using UnityEngine;
using System.Collections;

public class DifficultySelectionScript : MonoBehaviour {

	public static Difficulties Difficulty = Difficulties.Easy;

	public enum Difficulties {
		Easy,
		Medium,
		Hard
	}
}
