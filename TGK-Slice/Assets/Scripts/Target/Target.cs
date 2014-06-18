using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	// Use this for initialization
	void Start () {
		randomAttribute();
	}

	void randomAttribute(){
		float vx;
		float px = Random.Range(-4,4);
		if(px<-1)
			vx = Random.Range(0,3);
		else if(px>1)
			vx = Random.Range(-3,0);
		else
			vx = Random.Range(-3,3);
		transform.position = new Vector3(px,-5,1);
		rigidbody.velocity = new Vector3(vx,Random.Range(11,14),0);
	}
}
