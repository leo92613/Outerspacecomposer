using UnityEngine;
using System.Collections;

public class Welcome : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 5f)
			Application.LoadLevel ("planet");
	}
}
