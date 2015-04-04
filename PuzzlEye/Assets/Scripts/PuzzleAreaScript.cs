using UnityEngine;
using System.Collections;

public class PuzzleAreaScript : MonoBehaviour {
	
	public int rows, columns;
	public GameObject[][] piecePlanes;
	
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

		for (int i = 0; i < rows; i++) {
			piecePlanes[i] = new GameObject[columns];
			
			for (int j = 0; j < columns; j++) {
				piecePlanes[i][j] = GameObject.CreatePrimitive(PrimitiveType.Plane);
				piecePlanes[i][j].transform.parent = GameObject.Find("PuzzleArea").transform;

				float totalHeight = GameObject.Find("PuzzleArea").renderer.bounds.size.y;
				float totalWidth = GameObject.Find("PuzzleArea").renderer.bounds.size.x;

				float randX = 0f;
				float randY = 0f;

				while(((Mathf.Abs(randX) <= (5f + totalWidth/columns)) && (Mathf.Abs(randY) <= (5f + totalWidth/rows)))) {
					randX = Random.Range (-20f, 20f);
					randY = Random.Range (-7f, 7f);
				}
				
				piecePlanes[i][j].transform.localScale = new Vector3(rowInverse*1f, columnInverse*1f, columnInverse*1f);
				piecePlanes[i][j].transform.localPosition = new Vector3( randX,2f, randY);
				piecePlanes[i][j].transform.Rotate(new Vector3(90f, 180f, 0f));
				piecePlanes[i][j].renderer.material.mainTexture = AddDynamicTexture.ApplyDynamicTexture(i, j, DifficultySelectionScript.Difficulty);
				piecePlanes[i][j].name = "Piece:(" + i.ToString() + "," + j.ToString() + ")";
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
