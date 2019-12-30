using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void exitButton(){
		Application.Quit ();
	}
	public void playButtons(){
		
		Debug.Log ("PLay");
		//GameObject.FindGameObjectWithTag ("play_button").SetActive (false);
		//GameObject.FindGameObjectWithTag ("exitButton").SetActive (false);\
		SceneManager.LoadScene(1);
	}


}
