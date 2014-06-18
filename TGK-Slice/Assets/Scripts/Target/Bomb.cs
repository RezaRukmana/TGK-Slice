using UnityEngine;
using System.Collections;

public class Bomb : Target {

	// Update is called once per frame
	void Update () {
		if(transform.position.y<-5){
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Slicer")
			GameState.state = 0;
			sliced();
	}

	void sliced(){

	}
}
