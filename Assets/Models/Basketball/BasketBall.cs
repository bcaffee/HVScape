using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBall : MonoBehaviour {
	public Transform BBall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("r")){
			 Instantiate(BBall, new Vector3(0, 1, 0), Quaternion.identity);
			 Debug.Log("Ball Added.");		
		}
	}
}
