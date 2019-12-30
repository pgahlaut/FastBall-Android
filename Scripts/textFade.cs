using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textFade : MonoBehaviour {
	Text t;
	bool a=true;
	bool b=false;
	// Use this for initialization
	void Start () {
		t = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (a) {
			t.CrossFadeAlpha (0.5f, 0.2f, false);
			b = true;
			a = false;
		}
		if (b) {
			t.CrossFadeAlpha (1.0f, 0.2f, true);
			b = false;
			a = true;
		}
	}
}
