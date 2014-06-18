using UnityEngine;
using System.Collections;

public class Fruit : Target {

	private int incScore = 1;

	// Update is called once per frame
	void Update () {
		if(transform.position.y<-5){
			Camera.main.GetComponent<Player>().life--;
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Slicer"){
			Camera.main.GetComponent<Player>().score+=incScore;
			incScore=0;
			sliced();
		}
	}

	void sliced(){
		Destroy(gameObject);
	}
}
