using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTimer : MonoBehaviour {

	[SerializeField]
	private float timer = 5f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		Debug.Log(timer);
		if (timer <= 0f){
			SceneManager.LoadScene("MainMenu");
		}
		
	}
}
