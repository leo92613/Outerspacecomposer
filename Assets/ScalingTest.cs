using UnityEngine;
using System.Collections;

public class ScalingTest : MonoBehaviour {
	public Vector3 scaler;
	public float speed;

	// Use this for initialization
	void Start () {
		speed = 5f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//scaler = (new Vector3 (Mathf.Sin (Time.time*speed), Mathf.Sin (Time.time*speed), Mathf.Sin (Time.time*speed))*0.1f + new Vector3 (1, 1, 1)) ;
		transform.localScale = scaler;
	}
}
