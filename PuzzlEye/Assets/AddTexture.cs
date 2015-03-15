using UnityEngine;
using System.Collections;

public class AddTexture : MonoBehaviour {

	// Use this for initialization
	public static Texture2D ApplyTexture (PuzzleLocations puzzleLocation) 
	{

		var path = UploadImage.FinalPath;
		var url = "file://" + path;
		var www = new WWW(url);

		// Wait for picture to fully load
		Wait (www);
		
		var entireTexture = new Texture2D (4, 4, TextureFormat.DXT1, false);

		www.LoadImageIntoTexture(entireTexture);


		int height = entireTexture.height / 2;
		int width = entireTexture.width / 2;

		int startWidth = 0;
		int startHeight = 0;

		if (puzzleLocation == PuzzleLocations.TopLeft)
			startHeight = height;
		else if (puzzleLocation == PuzzleLocations.TopRight) {
			startHeight = height;
			startWidth = width;
		} else if (puzzleLocation == PuzzleLocations.BottomRight)
			startWidth = width;

		
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
