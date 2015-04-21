using UnityEngine;
using System.Collections;

public class SwitchScene : MonoBehaviour {

	public void Switch(int newScene)
	{
		if (LoginScript._curUser == "" && newScene != 5)
			return;

		Application.LoadLevel (newScene);
	}
}
