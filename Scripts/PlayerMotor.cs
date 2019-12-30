using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using AdColony;



public class PlayerMotor : MonoBehaviour {
	private CharacterController controller;
	private float speed=5.0f;
	private float verticalVelocity=-0.5f;
	private float gravity=12;
	private Vector3 moveVector;
	public PlayStates playStates;
	private float touchXspeed=0.2f;
	private ParticleSystem p;
	private Transform initialPlayerTransform;

	public TileManager tileM;
	public Text yourScore;
	public Text highScore;
	//InterstitialAd _ad = null;
	string[] zoneID=new string[]{"vz0f796d8e873a4e85a6"};


	// Use this for initialization
	void Start () {
		
		controller = GetComponent<CharacterController>();
		playStates = new PlayStates ();
		p = gameObject.GetComponent<ParticleSystem> ();
		//GameObject.FindGameObjectWithTag ("retryButton").SetActive (false);
		initialPlayerTransform = gameObject.transform;
		gameObject.GetComponent<MeshRenderer> ().enabled = false;

		disableRetryCanvas ();

		//Setiing up high sCore;
		highScore.text=((int)PlayerPrefs.GetFloat("HighScore",0)).ToString();


		//Ad Integration


		/*if (Application.platform == RuntimePlatform.Android) {
			AdColony.Ads.Configure ("app92fd13f814ce4b128e", null, zoneID);
		}*/

		/*AdColony.Ads.OnRequestInterstitial += (InterstitialAd ad) => {
			_ad = ad;
			Debug.Log("GOt an AD");
		};
		AdColony.Ads.OnExpiring += (InterstitialAd ad) => {
			AdColony.Ads.RequestInterstitialAd(ad.ZoneId, null);


		};
		AdColony.Ads.RequestInterstitialAd (zoneID [0], null);
		Debug.Log ("AD REQUESTED");*/
	}
	
	// Update is called once per frame
	void Update () {
		if (playStates.isPlaying) {
			moveVector = Vector3.zero;
			if (controller.isGrounded) {
				verticalVelocity = 0;
			} else {
				verticalVelocity -= gravity;
			}
			//X
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
				Vector2 v = Input.GetTouch (0).deltaPosition;

				moveVector.x = v.x * touchXspeed;
			}

			//Y
			moveVector.y = verticalVelocity;
			//Z
			moveVector.z = speed;

			controller.Move (moveVector * speed * Time.deltaTime);
			controller.transform.Rotate (500 * Time.deltaTime, 0, 0);
		}

		if ((gameObject.transform.position.x < -3.8||gameObject.transform.position.x>3.8)&& !playStates.isDead) {
			playStates.setIsDead (true);
			Debug.Log("DEAD DEAD");
			DeadAnimation ();
		}

	}

	//Colliding
	private void OnControllerColliderHit(ControllerColliderHit hit){
		//if (hit.point.z > (transform.position.z + controller.radius)) {

		if (hit.gameObject.tag == "Obstacle"||hit.gameObject.tag == "obstacle2"||hit.gameObject.tag == "obstacle3"
			||hit.gameObject.tag == "obstacle4"||hit.gameObject.tag == "arch_obs") {
			playStates.setIsDead (true);
			Debug.Log("DEAD DEAD");
			DeadAnimation ();
		}
	}

	public void setSpeed(float i){

		speed = speed + i;
	}
	public void exitButton(){
		Application.Quit ();
	}
	public void playButtons(){
		playStates.setIsPlaying (true);
		Debug.Log ("PLay");
		//GameObject.FindGameObjectWithTag ("play_button").SetActive (false);
		//GameObject.FindGameObjectWithTag ("exitButton").SetActive (false);
		GameObject.FindGameObjectWithTag ("playmenu").SetActive (false);
		EnableGamePlayObjects ();
	}



	private void DeadAnimation(){
		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		p.Play ();
		enableRetryCanvas ();
		yourScore.text = ((int)gameObject.GetComponent<Score> ().score).ToString();

		if (PlayerPrefs.GetFloat ("HighScore", 0) <gameObject.GetComponent<Score> ().score) 
			PlayerPrefs.SetFloat ("HighScore", gameObject.GetComponent<Score> ().score);
		
		gameObject.GetComponent<Score> ().score = 0.0f;
		//ShowAd ();
	}

	private void EnableGamePlayObjects(){
		gameObject.GetComponent<MeshRenderer> ().enabled = true;
	}

	private void disableRetryCanvas(){
		GameObject.FindGameObjectWithTag ("retryButton").GetComponent<Canvas> ().enabled = false;
	}
	private void enableRetryCanvas(){
		GameObject.FindGameObjectWithTag ("retryButton").GetComponent<Canvas> ().enabled = true;


	}

	public void RetryEvent(){
		/*GameObject gameObject = GameObject.FindGameObjectWithTag ("Player");
		gameObject.GetComponent<MeshRenderer> ().enabled = true;
		controller.Move (new Vector3 (0f, 0.6f, -45.0f));
		disableRetryCanvas ();
		playStates.setIsPlaying (true);
	
		//GameObject.FindGameObjectWithTag ("MainCamera").transform.position.

		tileM.Retry ();*/
		SceneManager.LoadScene (0);
	}

	/*private void ShowAd(){
		

		if (_ad == null)
			Debug.Log ("NULL AD");
		AdColony.Ads.ShowAd (_ad);


	}*/




}
