using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {
	public GameObject center;
	private Vector3 center_;
	public int rotatemode;
	// Use this for initialization
	void Start () {
		center_ = center.GetComponent<Transform> ().position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rotate;
		if (rotatemode == 1)
			rotate = new Vector3 (0, 1, 0);
		else if (rotatemode == 2)
			rotate = new Vector3 (1, 0, 0);
		else
			rotate = new Vector3 (0, 0, 1);
		
		transform.RotateAround(center_, rotate, 20 * Time.deltaTime);
	
	}
}
