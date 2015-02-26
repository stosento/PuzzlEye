using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallScript : MonoBehaviour {
	public Camera camera2;
	public float offBase;
	
	void FixedUpdate() {
		Vector3 pos2=camera2.WorldToViewportPoint(rigidbody.position);
		if (pos2.x<-offBase || pos2.x>1.0f+offBase || pos2.y<-offBase || pos2.y>1.0f+offBase) {
			if (pos2.x<-offBase) pos2.x=-offBase;
			if (pos2.x>1.0f+offBase)  pos2.x=1.0f+offBase;
			if (pos2.y<-offBase) pos2.y=-offBase;
			if (pos2.y>1.0f+offBase)  pos2.y=1.0f+offBase;
			pos2=camera2.ViewportToWorldPoint(pos2);
			pos2.z=0;
			//rigidbody.MovePosition(pos2);
		}
		pos2=camera2.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0));
		pos2.z=0;
		rigidbody.AddForce((pos2-rigidbody.position));
	}
}
