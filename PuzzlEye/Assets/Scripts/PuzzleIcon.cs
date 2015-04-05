using UnityEngine;
using System.Collections;
using System;

public class PuzzleIcon : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}

	public void OnClick(Texture2D image)
	{
//		UploadImage.FinalPath = new Texture2D (4, 4, TextureFormat.RGBA32, false);
		UploadImage.FinalPath = image;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
