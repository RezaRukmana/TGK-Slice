﻿using UnityEngine;
using System.Collections;

public class Slicer : MonoBehaviour {

	private float lifetime = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;
		if(lifetime<=0)
			Destroy(gameObject);
	}


}
