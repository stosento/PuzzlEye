using UnityEngine;
using System.Collections;

public class ButtonClick : MonoBehaviour {
	private int counter = 0;
	
	void OnClick ()
	{
		counter++;
		Debug.Log ("Clicked " + counter.ToString () + " times.");
	}

	public void Michael() {
		Debug.Log ("Button Click");
	}
}
