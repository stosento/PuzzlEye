using UnityEngine;
using System.Collections;
using System;
using System.Threading;

public class PuzzlePiece : MonoBehaviour {

	int row, column;
	float minX, minY, maxX, maxY, halfW, halfH;

	PuzzleAreaScript script;

	// Use this for initialization
	void Start () {
		string name = this.name;
		if (name.Length > 7) {

			script = transform.parent.GetComponent<PuzzleAreaScript>();

			row = Convert.ToInt32 (name [7]) - Convert.ToInt32 ('0');
			column = Convert.ToInt32 (name [9]) - Convert.ToInt32 ('0');

			minX = GameObject.Find ("PuzzleArea").renderer.bounds.min.x + (script.pieceWidth * column);
			maxX = minX + script.pieceWidth;
			minY = GameObject.Find ("PuzzleArea").renderer.bounds.min.y + (script.pieceHeight * row);
			maxY = minY + script.pieceHeight;

			halfW = script.pieceWidth / 2;
			halfH = script.pieceHeight / 2;
		}

	}
	
	// Update is called once per frame
	void Update () {

		//this.rigidbody.velocity = Vector3.zero;

		/*acquired = false;
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
			acquired = false;
			this.transform.localPosition = new Vector3(correctX, 0.9f, correctZ);
			this.GetComponent<PuzzlePiece>().enabled = false;
		}*/
	}

	void OnCollisionStay(Collision col) {
		if (col.gameObject.tag == "Fingers") {
			this.rigidbody.transform.position = col.gameObject.transform.renderer.bounds.center;
			Debug.Log (this.rigidbody.transform.position);
		}
	}

	void OnCollisionExit(Collision col) {
		if (col.gameObject.tag == "Fingers") {
			if (this.rigidbody)
				this.rigidbody.velocity = Vector3.zero;

			if((col.transform.position.x >= minX) && (col.transform.position.x <= maxX) && 
			   (col.transform.position.y >= minY) && (col.transform.position.y <= maxY))
			{
				this.rigidbody.transform.position = new Vector3(minX + halfW, maxY - halfW, 0.5f);
				this.rigidbody.isKinematic = true;
				this.collider.enabled = false;
				if (this.rigidbody)
					Debug.Log ("Why are you here");
			}
		}
	}
}
