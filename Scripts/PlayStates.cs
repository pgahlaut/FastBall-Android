using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStates  {
	//

	public bool isPlaying = false;
	public bool isDead=false;
	public bool isPaused = false;

	public void setIsPlaying(bool b){
		isPlaying = b;
		if (b = true)
			isDead = false;
		else
			isDead = true;
	}

	public void setIsDead(bool b){
		isDead = b;
		if (b = true)
			isPlaying = false;
		else
			isPlaying = true;
	}
	public void setIsPaused(bool b){
		isPaused = b;
		if (b = true)
			isPlaying = false;
		else
			isPlaying = true;
	
	}
}
