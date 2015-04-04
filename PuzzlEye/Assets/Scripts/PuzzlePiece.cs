using UnityEngine;
using System.Collections;
using System;
using System.Threading;

public class PuzzlePiece : MonoBehaviour {

	float correctX;
	float correctZ;

	PuzzleAreaScript script;

	public bool acquired = false;
	

	// Use this for initialization
	void Start () {
		string name = this.name;
		if (name.Length > 7) {

			script = transform.parent.GetComponent<PuzzleAreaScript>();

			int column = Convert.ToInt32 (name [7]) - Convert.ToInt32 ('0');
			int row = Convert.ToInt32 (name [9]) - Convert.ToInt32 ('0');

			//the position each piece needs to be in to be correct
			correctX = (-2) * row * script.pieceHeight + (script.totalHeight - script.pieceHeight);
			correctZ = (-2) * column * script.pieceWidth + (script.totalWidth - script.pieceWidth);
			//puts puzzle piece in correct location on start
			//this.transform.localPosition = new Vector3 (correctX, 2f, correctY);
		}

	}
	
	// Update is called once per frame
	void Update () {
		acquired = false;
		bool elseAcquired = false;
		Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 12f);
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);
		mousePos = new Vector3 (mousePos.x*-2f, mousePos.y*-2f, mousePos.z);
		if (Input.GetMouseButtonDown (0) && (mousePos.x <= (this.transform.localPosition.x + script.pieceWidth)) 
						&& (mousePos.x >= (this.transform.localPosition.x - script.pieceWidth)) 
						&& (mousePos.y <= (this.transform.localPosition.z + script.pieceHeight))
						&& (mousePos.y >= (this.transform.localPosition.z - script.pieceHeight))) 
		{
			for(int i = 0; i < script.rows; i++) {
				for(int j = 0; j < script.columns; j++) {
					if(script.piecePlanes[i][j].GetComponent<PuzzlePiece>().acquired) elseAcquired = true;
				}
			}
			if(!elseAcquired) {
				acquired = true;
				this.transform.localPosition = new Vector3(mousePos.x, this.transform.localPosition.y, mousePos.y);
			}
		}

		if((Math.Abs (Math.Abs (correctX) - Math.Abs (this.transform.localPosition.x)) < 0.3) 
		   && (Math.Abs (Math.Abs (correctZ) - Math.Abs (this.transform.localPosition.z)) < 0.3)) {
			this.transform.localPosition = new Vector3(correctX, 0.9f, correctZ);
			this.GetComponent<PuzzlePiece>().enabled = false;
		}
	}
}
