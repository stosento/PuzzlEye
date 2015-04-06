using UnityEngine;
using System.Collections;
using System;
using System.Threading;

public class PuzzlePiece : MonoBehaviour {

	int row, column;
	float minX, minY, maxX, maxY, halfW, halfH;
	public bool inCorrectPlace = false; 
	public bool gameOver = false;

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

		if (this.inCorrectPlace) {
			Destroy(this.collider);
			Destroy(this.rigidbody);
		}
		if (this.rigidbody){
			this.rigidbody.velocity = Vector3.zero;
		}
	}

	void OnCollisionStay(Collision col) {
		if (col.gameObject.tag == "Fingers") {
			this.rigidbody.transform.position = col.gameObject.transform.renderer.bounds.center;
		}
	}

	void OnCollisionExit(Collision col) {
		if (col.gameObject.tag == "Fingers") {
			if (this.rigidbody)
				this.rigidbody.velocity = Vector3.zero;

			if((col.transform.position.x >= minX) && (col.transform.position.x <= maxX) && 
			   (col.transform.position.y >= minY) && (col.transform.position.y <= maxY))
			{
				this.rigidbody.transform.position = new Vector3(minX + halfW, maxY - halfW, 0);
				this.rigidbody.isKinematic = true;
				this.collider.enabled = false;
				this.inCorrectPlace = true;
				
				script.correctPlaces++;
				Debug.Log ("This piece just locked");
				if (script.correctPlaces == script.rows * script.columns){
					Debug.Log ("The game is over");
					gameOver = true;
				}
			}
		}
	}
}
