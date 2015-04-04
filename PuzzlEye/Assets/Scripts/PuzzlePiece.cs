using UnityEngine;
using System.Collections;
using System;

public class PuzzlePiece : MonoBehaviour {

	float correctX;
	float correctZ;

	// Use this for initialization
	void Start () {
		string name = this.name;
		if (name.Length > 7) {
				int column = Convert.ToInt32 (name [7]) - Convert.ToInt32 ('0');
				int row = Convert.ToInt32 (name [9]) - Convert.ToInt32 ('0');

				//the position each piece needs to be in to be correct
				correctX = (-2) * row * PuzzleAreaScript.pieceHeight + 
						(PuzzleAreaScript.totalHeight - PuzzleAreaScript.pieceHeight);
				correctZ = (-2) * column * PuzzleAreaScript.pieceWidth + 
						(PuzzleAreaScript.totalWidth - PuzzleAreaScript.pieceWidth);

				//puts puzzle piece in correct location on start
				//this.transform.localPosition = new Vector3 (correctX, 2f, correctY);
		}

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 12f);
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);
		mousePos = new Vector3 (mousePos.x*-2f, mousePos.y*-2f, mousePos.z);
		if (Input.GetMouseButtonDown (0) && (mousePos.x <= (this.transform.localPosition.x + PuzzleAreaScript.pieceWidth)) 
						&& (mousePos.x >= (this.transform.localPosition.x - PuzzleAreaScript.pieceWidth)) 
						&& (mousePos.y <= (this.transform.localPosition.z + PuzzleAreaScript.pieceHeight))
						&& (mousePos.y >= (this.transform.localPosition.z - PuzzleAreaScript.pieceHeight))) 
		{
			this.transform.localPosition = new Vector3(mousePos.x, this.transform.localPosition.y, mousePos.y);
		}

		if((Math.Abs (Math.Abs (correctX) - Math.Abs (this.transform.localPosition.x)) < 0.3) 
		   && (Math.Abs (Math.Abs (correctZ) - Math.Abs (this.transform.localPosition.z)) < 0.3)) {
			this.transform.localPosition = new Vector3(correctX, 0.9f, correctZ);
			this.GetComponent<PuzzlePiece>().enabled = false;
		}
	}
}
