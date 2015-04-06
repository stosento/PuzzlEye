using UnityEngine;
using System.Collections;
using System;

public class PuzzleIcon : MonoBehaviour {


	public void OnClick(String imageName)
	{
		UploadImage.FinalPath = Resources.Load (imageName) as Texture2D;
	}

}
