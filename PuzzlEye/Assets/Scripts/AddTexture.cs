using UnityEngine;
using System.Collections;

public class AddTexture : MonoBehaviour {

	// Use this for initialization
	public static Texture2D ApplyTexture (PuzzleLocations puzzleLocation) 
	{
		
		var entireTexture = UploadImage.FinalPath;


		int height = entireTexture.height/2;
		int width = entireTexture.width/2;

		int startWidth = 0;
		int startHeight = 0;

		if (puzzleLocation == PuzzleLocations.TopLeft) {
			startHeight = entireTexture.height/2;
			startWidth = 0;
		} else if (puzzleLocation == PuzzleLocations.TopRight) {
			startHeight = entireTexture.height/2;
			startWidth = entireTexture.width/2;
		} else if (puzzleLocation == PuzzleLocations.BottomRight) {
			startHeight = 0;
			startWidth = entireTexture.width/2;
		} else if (puzzleLocation == PuzzleLocations.BottomLeft) {
			startHeight = 0;
			startWidth = 0;
		}
		
		// Get the pixel block and place it into a new texture.
		var pix = entireTexture.GetPixels(startWidth, startHeight, width, height);
		var destTex = new Texture2D(width, height);
		destTex.SetPixels(pix);
		destTex.Apply();
		return destTex;
	}

	public static IEnumerator Wait(WWW www) {
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
