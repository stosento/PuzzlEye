using UnityEngine;
using System.Collections;
using System;

public class PuzzleIcon : MonoBehaviour {


	public void OnClick(String imageName)
	{
//		Debug.Log ("file://" + Application.dataPath + "/Resources/" + imageName + ".jpg");
//
		UploadImage.FinalPath = new Texture2D (4, 4, TextureFormat.RGBA32, false);
//		var www = new WWW ("file://" + Application.dataPath + "/Resources/" + imageName + ".jpg");
//		www.LoadImageIntoTexture (UploadImage.FinalPath);
//		AddTexture.Wait (www);

//		Debug.Log ("Format: " + UploadImage.FinalPath.format);


//		UploadImage.FinalPath = new Texture2D (4, 4, TextureFormat.RGBA32, false);
		UploadImage.FinalPath = Resources.Load (imageName) as Texture2D;

	}

}
