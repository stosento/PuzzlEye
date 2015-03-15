using UnityEngine;
using System.Collections;

public class BottomRightPlane : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.material.mainTexture = AddTexture.ApplyTexture (AddTexture.PuzzleLocations.BottomRight);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
