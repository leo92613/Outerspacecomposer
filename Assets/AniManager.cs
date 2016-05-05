﻿using UnityEngine;
using System.Collections;

public class AniManager : MonoBehaviour {
	public GameObject[] planets;
	public Vector3 scaler;
	public float speed;
	public bool needupdate;
	public float time;
	private float[] size = {1.8f,2f,1f,1.6f,2f};
	// Use this for initialization
	void Start () {
		speed = 5f;
		time = 0;
		needupdate = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		time += Time.deltaTime;
		if (needupdate) {
			time = 0;
			needupdate = false;
		}
		scaler = (new Vector3 (Mathf.Sin (time*speed), Mathf.Sin (time*speed), Mathf.Sin (time*speed))*0.1f + new Vector3 (1, 1, 1));
		for (int i =0;i<5;i++)
			//if (planets [i].GetComponent<ScalingTest> ().enabled == true)
			planets [i].GetComponent<ScalingTest> ().scaler = scaler*5*size[i];
		
	}
}