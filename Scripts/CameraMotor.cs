using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

	private Transform lookAt;
	private Vector3 startOffset;
	private Vector3 moveVector;

	private float transition = 0.0f;
	private float animationDuration = 2.0f;
	private Vector3 animationOffset =new Vector3(0,1.3f,-0.67f);

	// Use this for initialization
	void Start () {
		lookAt=GameObject.FindGameObjectWithTag ("Player").transform;
		startOffset = transform.position - lookAt.position;

	}
	
	// Update is called once per frame
	void Update () {
		moveVector = lookAt.position + startOffset;
		//X

		//Y
		moveVector.y=Mathf.Clamp(moveVector.y,3,5);

			moveVector.x = 0;
			transform.position = moveVector;
		 
		
	}
}
