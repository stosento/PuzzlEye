using UnityEngine;
using System.Collections;
using System;

public class PuzzlePiece : MonoBehaviour {

	float correctX;
	float correctY;

	// Use this for initialization
	void Start () {

		string name = this.name;
		int column = Convert.ToInt32 (name [7]) - Convert.ToInt32('0');
		int row = Convert.ToInt32 (name [9]) - Convert.ToInt32 ('0');
		correctX = (-2) * row * PuzzleAreaScript.pieceHeight + 
						(PuzzleAreaScript.totalHeight - PuzzleAreaScript.pieceHeight);
		correctY = (-2) * column * PuzzleAreaScript.pieceWidth + 
						(PuzzleAreaScript.totalWidth - PuzzleAreaScript.pieceWidth);

		//puts puzzle piece in correct location on start
		this.transform.localPosition = new Vector3 (correctX, 2f, correctY);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
