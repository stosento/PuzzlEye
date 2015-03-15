using UnityEngine;
using System.Collections;

public class TopRightPlane : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.material.mainTexture = AddTexture.ApplyTexture (AddTexture.PuzzleLocations.TopRight);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
