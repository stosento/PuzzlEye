using UnityEngine;
using System.Collections;

public class BottomLeftPlane : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.material.mainTexture = AddTexture.ApplyTexture (AddTexture.PuzzleLocations.BottomLeft);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
