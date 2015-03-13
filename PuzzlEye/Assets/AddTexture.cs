using UnityEngine;
using System.Collections;

public class AddTexture : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		var url = "file://C:\\Users\\User\\Pictures\\sunset.jpg";
		var www = new WWW(url);

		yield return www;

		var ThisTexture = new Texture2D (4, 4, TextureFormat.DXT1, false);

		www.LoadImageIntoTexture(ThisTexture);

		renderer.material.mainTexture = ThisTexture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
