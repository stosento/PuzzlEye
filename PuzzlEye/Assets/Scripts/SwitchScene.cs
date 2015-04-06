using UnityEngine;
using System.Collections;

public class SwitchScene : MonoBehaviour {

	public void Switch(int newScene)
	{
		Application.LoadLevel (newScene);
	}
}
