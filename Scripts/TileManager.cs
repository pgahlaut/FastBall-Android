using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public GameObject[] tile;
	public float tileLength = 10.0f;
	private float spawnZ = -10.0f;
	private float obsX = 2.0f;
	private int tilesOnScreen = 15;
	private float SAFE_ZONE=15.0f;
	private bool first_tile=true;

	private Transform playerTransform;

	private List<GameObject> activeTiles;
	private List<GameObject> activeObst;

	// Use this for initialization
	private void Start () {
		
		activeTiles = new List<GameObject> ();
		activeObst = new List<GameObject> ();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		for (int i = 0; i < tilesOnScreen; i++) {
			SpawnTile ();
			SpawnObstacle ();
			
		}
	}
	
	// Update is called once per frame
	private void Update () {
		 
		if((playerTransform.position.z-SAFE_ZONE)>(spawnZ-tilesOnScreen*tileLength)){
			SpawnTile();
			SpawnObstacle ();


		}
		if ((playerTransform.position.z - SAFE_ZONE) > ((spawnZ * 1.5f) - tilesOnScreen * tileLength)) {
			deleteTile ();
		}
	}

	private void SpawnTile(){
		GameObject go;
		go = Instantiate (GameObject.FindGameObjectWithTag("Respawn")) as GameObject;
		go.transform.SetParent (transform);

		if (first_tile) {
			go.transform.position = Vector3.forward * -50.0f;
			first_tile = false;
			Debug.Log ("SPAWNED LEVEL");
		} else {
			go.transform.position = Vector3.forward * spawnZ;
			spawnZ += tileLength;
		}

		activeTiles.Add (go);
	}

	private void deleteTile(){
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);
		Destroy (activeObst [0]);
		activeObst.RemoveAt (0);
	}

	private void renderObstaclesOne(){
		GameObject go;
		go = Instantiate (GameObject.FindGameObjectWithTag ("Obstacle")) as GameObject;
		go.transform.SetParent (transform);
		Vector3 v = new Vector3 (1.75f, 0.5f, spawnZ*1.5f);
		go.transform.position = v;

		activeObst.Add (go);
	}

	private void renderObstacleTwo(){
		GameObject go;
		go = Instantiate (GameObject.FindGameObjectWithTag ("obstacle2")) as GameObject;
		go.transform.SetParent (transform);
		float f = Random.Range (-1.75f, 1.75f);
		Vector3 v = new Vector3 (f, 0.5f, spawnZ*1.5f);
		go.transform.position = v;

		activeObst.Add (go);
	}
	private void renderObstacleThree(){
		GameObject go;
		go = Instantiate (GameObject.FindGameObjectWithTag ("obstacle3")) as GameObject;
		go.transform.SetParent (transform);
		float f = Random.Range (-3f,3f);
		Vector3 v = new Vector3 (f, 0.5f, spawnZ*1.5f);
		go.transform.position = v;

		activeObst.Add (go);
	}
	private void renderObstacleFour(){
		GameObject go;
		go = Instantiate (GameObject.FindGameObjectWithTag ("obstacle4")) as GameObject;
		go.transform.SetParent (transform);

		Vector3 v = new Vector3 (0.0f, 0.0f, spawnZ*1.5f);
		go.transform.position = v;

		activeObst.Add (go);
	}

	private void SpawnObstacle(){
		int r = Random.Range (0, 10); 
		if (r == 0) {
			renderObstaclesOne ();
		} else if (r == 1) {
			renderObstacleTwo ();
		} else if (r == 2) {
			renderObstacleThree ();
		} else if (r == 3) {
			renderObstacleFour ();
		} else if (r == 4) {
			renderObstacleThree ();
		} else if (r == 5) {
			renderObstacleThree ();
		} else if (r == 6) {
			renderObstacleTwo ();
		} else if (r == 7) {
			renderObstacleTwo ();
		} else if (r == 8) {
			renderObstaclesOne ();
		} else if (r == 9) {
			renderObstacleThree ();
		}

	}

	public  void Retry(){
		
		GameObject go;
		go = Instantiate (GameObject.FindGameObjectWithTag ("plane")) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * (spawnZ-tilesOnScreen*tileLength);

		Debug.Log ("RETRYEVENT");
	}
}
