using UnityEngine;
using System.Collections;
using System;

public class PuzzleIcon : MonoBehaviour {


	public void OnClick(String imageName)
	{
		Debug.Log ("file://" + Application.dataPath + "/DefaultPuzzles/" + imageName);

		UploadImage.FinalPath = new Texture2D (4, 4, TextureFormat.RGBA32, false);
		var www = new WWW ("file://" + Application.dataPath + "/DefaultPuzzles/" + imageName);
		www.LoadImageIntoTexture (UploadImage.FinalPath);
		AddTexture.Wait (www);
	}

}
