using UnityEngine;
using System.Collections;
using System.Threading;

public class PuzzleAreaScript : MonoBehaviour {
	
	public int rows, columns, correctPlaces=0;
	public GameObject[][] piecePlanes;
	public GameObject piecePlane;

	public float totalHeight;
	public float totalWidth;

	public float pieceHeight;
	public float pieceWidth;

	public SphereCollider pieceCollider;
	public Rigidbody pieceRigidBody;

	public bool gameisover = false;

	// Use this for initialization
	void Start () {

		switch(DifficultySelectionScript.Difficulty) 
		{
		case DifficultySelectionScript.Difficulties.Easy :
			GeneratePiecePlanes(2,2);
			break;
		case DifficultySelectionScript.Difficulties.Medium :
			GeneratePiecePlanes(3,3);
			break;
		case DifficultySelectionScript.Difficulties.Hard :
			GeneratePiecePlanes(4,4);
			break;
		}

	}
	

	void GeneratePiecePlanes(int rows, int columns) {
		this.rows = rows;
		this.columns = columns;
		
		piecePlanes = new GameObject[rows][];
		
		float rowInverse = 1.0f / rows;
		float columnInverse = 1.0f / columns;

		totalHeight = GameObject.Find("PuzzleArea").renderer.bounds.size.y;
		totalWidth = GameObject.Find ("PuzzleArea").renderer.bounds.size.x;

		pieceHeight = totalHeight/rows;
		pieceWidth = totalWidth/columns;

		piecePlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
		piecePlane.gameObject.AddComponent<PuzzlePiece>();

		GameObject.Find("PuzzleArea").AddComponent<Timer>();

		for (int i = 0; i < rows; i++) {
			piecePlanes[i] = new GameObject[columns];
			
			for (int j = 0; j < columns; j++) {

				float randX = 0f;
				float randY = 0f;

				while(((Mathf.Abs(randX) <= (5f + pieceWidth) && (Mathf.Abs(randY) <= (5f + pieceHeight))))) {
					randX = Random.Range (-20f, 20f);
					randY = Random.Range (-7f, 7f);
				}

				piecePlanes[i][j] = GameObject.Instantiate(piecePlane, 
				                                           new Vector3( 0, 0, 0),
				                                           Quaternion.Euler(90f, 180f, 0f)) as GameObject;
				piecePlanes[i][j].transform.parent = GameObject.Find("PuzzleArea").transform;
				
				piecePlanes[i][j].transform.localScale = new Vector3(rowInverse*1f, columnInverse*1f, columnInverse*1f);
				piecePlanes[i][j].transform.localPosition = new Vector3( randX, 1f, randY);

				//Will place puzzle pieces in correct location initially
//				piecePlanes[i][j].transform.localPosition = new Vector3((-2)*j*pieceHeight + (totalHeight - pieceHeight), 2f, (-2)*i*pieceWidth + (totalWidth - pieceWidth));

				piecePlanes[i][j].renderer.material.mainTexture = AddDynamicTexture.ApplyDynamicTexture(i, j, DifficultySelectionScript.Difficulty);
				piecePlanes[i][j].name = "Piece:(" + i.ToString() + "," + j.ToString() + ")";
				piecePlanes[i][j].tag = "Pieces";

				pieceCollider = piecePlanes[i][j].AddComponent<SphereCollider>();
				pieceRigidBody = piecePlanes[i][j].AddComponent<Rigidbody>();

				pieceRigidBody.freezeRotation = true;
				pieceRigidBody.useGravity = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		bool done = true;
		for (int i = 0; i < rows; i++) {
			for(int j = 0; j < columns; j++) {
				if(!piecePlanes[i][j].GetComponent<PuzzlePiece>().inCorrectPlace) {
					done = false;
				}
			}
		}
		if (done) {
			GameObject go = GameObject.Find("PuzzleArea");
			go.gameObject.GetComponent<Timer>().gameover = true;
			Debug.Log("Gameover? : " + go.gameObject.GetComponent<Timer>().gameover);
			Debug.Log("Time: " + go.gameObject.GetComponent<Timer>().time);
		}
	}
}
