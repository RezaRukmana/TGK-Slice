using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {

	private int lifeInc = 1;

	// Use this for initialization
	void Start () {
		if(Random.Range(0,3)<2){
			transform.position = new Vector3(-9,Random.Range(3,5),1);
			rigidbody.velocity = new Vector3(13,5,0);
		}
		else{
			transform.position = new Vector3(9,Random.Range(3,5),1);
			rigidbody.velocity = new Vector3(-13,5,0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > 10||transform.position.x < -10)
			Destroy(gameObject);
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Slicer"){
			Camera.main.GetComponent<Player>().life+=lifeInc;
			lifeInc=0;
			Destroy(gameObject);
		}
	}
}
