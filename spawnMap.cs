using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMap : MonoBehaviour {

	private GameObject gameObj;

	// Use this for initialization
	void Start () {
		gameObj = GameObject.FindGameObjectWithTag ("finish");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
