using UnityEngine;
using System.Collections;

public class CreatePuzzleIcons : MonoBehaviour {

	public int rows, columns;
	public GameObject iconButton;
	
	// Use this for initialization
	void Start () {

//		GameObject newObj = Instantiate(iconButton, new Vector3( 2f, 0f, 0f), Quaternion.identity) as GameObject;
//		newObj.transform.SetParent(GameObject.Find("Canvas").transform);
						
		
	}
	
	
	void GenerateIcons() {
//		this.rows = rows;
//		this.columns = columns;
//		
//		puzzleIcons = new GameObject[rows][];
//		
//		float rowInverse = 1.0f / rows;
//		float columnInverse = 1.0f / columns;
//		
//		Debug.Log (rowInverse);
//		Debug.Log (columnInverse);
//		
//		for (int i = 0; i < rows; i++) {
//			puzzleIcons[i] = new GameObject[columns];
//			
//			for (int j = 0; j < columns; j++) {
//				puzzleIcons[i][j] = Instantiate(exampleIcon, new Vector3( 0f, 0f, 0f), Quaternion.identity) as GameObject;
//				puzzleIcons[i][j].transform.SetParent(GameObject.Find("Image").transform);
//				
//				puzzleIcons[i][j].transform.localScale = new Vector3(columnInverse, rowInverse, 1);
//				puzzleIcons[i][j].transform.localPosition = new Vector3( -.5f + columnInverse / 2f + j * columnInverse, -.5f + rowInverse / 2f + i * rowInverse, 0f);
//			}
//		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
