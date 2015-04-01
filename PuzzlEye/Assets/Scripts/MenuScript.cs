using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnGUI() {
		GUI.color = Color.yellow;
		GUI.backgroundColor = Color.red;
		GUI.contentColor = Color.green;

		if (GUI.Button (new Rect (15, 15, 100, 50), "Click Me")) {
			Debug.Log("Button Click1");
			Application.LoadLevel("MyTestCube");
		}

		if (GUI.Button(new Rect(75, 75, 100, 50), "Play")) {
			Debug.Log ("Play");
		}
	}

	public void test() {
		Debug.Log("Button Click2");

	}
}
