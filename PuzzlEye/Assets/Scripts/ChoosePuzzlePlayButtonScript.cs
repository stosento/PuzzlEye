using UnityEngine;
using System.Collections;
using UnityEditor;

public class ChoosePuzzlePlayButtonScript : MonoBehaviour {

	// Use this for initialization
	public void OnClick () 
	{
		if (UploadImage.FinalPath == null) {
			EditorUtility.DisplayDialog("No Image Selected", "Please select an image!", "OK");
		} else {
			SwitchScene.Switch(5);
		}
	}
}
