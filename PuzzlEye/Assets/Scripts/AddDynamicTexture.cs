using UnityEngine;
using System.Collections;

public class AddDynamicTexture : MonoBehaviour {
	
	// Use this for initialization
	public static Texture2D ApplyDynamicTexture (int row, int col, DifficultySelectionScript.Difficulties difficulty) 
	{

		var entireTexture = UploadImage.FinalPath;

		int height = 0;
		int width = 0;

		int startWidth = 0;
		int startHeight = 0;

		switch (difficulty) 
		{
		case DifficultySelectionScript.Difficulties.Easy :
			height = entireTexture.height/2;
			width = entireTexture.width/2;
			break;
		case DifficultySelectionScript.Difficulties.Medium :
			height = entireTexture.height/3;
			width = entireTexture.width/3;
			break;
		case DifficultySelectionScript.Difficulties.Hard :
			height = entireTexture.height/4;
			width = entireTexture.width/4;
			break;
		}

		startHeight = row*height;
		startWidth = col*width;

		// Get the pixel block and place it into a new texture.
		var pix = entireTexture.GetPixels(startWidth, startHeight, width, height);
		var destTex = new Texture2D(width, height);
		destTex.SetPixels(pix);
		destTex.Apply();
		return destTex;
	}
	
	static IEnumerator Wait(WWW www) {
		yield return www;
	}
	
	
	public enum PuzzleLocations
	{
		TopLeft,
		TopRight,
		BottomLeft,
		BottomRight
	}
}
