using UnityEngine;
using System.Collections;

public class TopLeftPlane : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		AddTexture.ApplyTexture (renderer.material.mainTexture, 
		                         AddTexture.PuzzleLocations.TopLeft);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
