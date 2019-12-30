using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public float score = 0.0f;

	private int difficultyLevel = 1;
	private int maxDifficultyLevel=10;
	private float scoreToNextlevel = 10;

	public Text scoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<PlayerMotor> ().playStates.isPlaying) {
			if (score >= scoreToNextlevel)
				LevelUp ();
			score += Time.deltaTime;
			scoreText.text = ((int)score).ToString ();
		}
		if(GetComponent<PlayerMotor>().playStates.isDead){
			scoreText.text = "";
		}
	}

	void LevelUp(){
		if (difficultyLevel >= maxDifficultyLevel)
			return;
		scoreToNextlevel*=2f;
		difficultyLevel++;
		GetComponent<PlayerMotor> ().setSpeed (1);
	}
}
