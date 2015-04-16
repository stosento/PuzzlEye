using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ChoosePuzzlePlayButtonScript : MonoBehaviour {

	// Use this for initialization
	public void OnClick () 
	{
		if (UploadImage.FinalPath == null) {
			#if UNITY_EDITOR
			EditorUtility.DisplayDialog("No Image Selected", "Please select an image!", "OK");
			#endif
		} else {
			Application.LoadLevel(3);
		}
	}
}
