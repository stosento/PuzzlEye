using UnityEngine;
using System.Collections;

public class PuzzleAreaScript : MonoBehaviour {
	
	public int rows, columns;
	public GameObject piecePlane;
	public GameObject[][] piecePlanes;
	
	// Use this for initialization
	void Start () {
		GeneratePiecePlanes (2, 4);

	}
	

	void GeneratePiecePlanes(int rows, int columns) {
		this.rows = rows;
		this.columns = columns;
		
		piecePlanes = new GameObject[rows][];
		
		float rowInverse = 1.0f / rows;
		float columnInverse = 1.0f / columns;
		
		Debug.Log (rowInverse);
		Debug.Log (columnInverse);
		
		for (int i = 0; i < rows; i++) {
			piecePlanes[i] = new GameObject[columns];
			
			for (int j = 0; j < columns; j++) {
				piecePlanes[i][j] = Instantiate(piecePlane, new Vector3( 0f, 0f, 0f), Quaternion.identity) as GameObject;
				piecePlanes[i][j].transform.parent = GameObject.Find("PuzzleArea").transform;
				
				piecePlanes[i][j].transform.localScale = new Vector3(columnInverse, rowInverse, 1);
				piecePlanes[i][j].transform.localPosition = new Vector3( -.5f + columnInverse / 2f + j * columnInverse, -.5f + rowInverse / 2f + i * rowInverse, 0f);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
