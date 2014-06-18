using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject slicer;
	private GameObject slicerInstant;

	public int life;
	public int score=0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)&&GameState.state==1){
			slicerInstant = (GameObject)Instantiate(slicer);
			slicerInstant.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			slicerInstant.transform.position = new Vector3(slicerInstant.transform.position.x, slicerInstant.transform.position.y, 1);
		}
		if(life<=0)
			GameState.state=0;
	}
}
