using UnityEngine;
using System.Collections;

public class TopLeftPlane : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		renderer.material.mainTexture = AddTexture.ApplyTexture (AddTexture.PuzzleLocations.TopLeft);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
