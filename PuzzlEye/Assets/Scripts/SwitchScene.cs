using UnityEngine;
using System.Collections;

public class SwitchScene : MonoBehaviour {

	public static void Switch(int newScene)
	{
		Application.LoadLevel (newScene);
	}
}
