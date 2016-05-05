using UnityEngine;
using System.Collections;

[RequireComponent(typeof (BoxCollider))]

public class ObjInteraction : MonoBehaviour {
	BoxCollider collider;
	AudioSource FX;
	public int number;
	public GameObject Planet;
	float touchtime;
	bool istouch;
	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider> ();
		collider.isTrigger = true;
		Planet = GetComponent<RotateAround> ().center;
		if (gameObject.tag == "Cat")
			FX = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!istouch)
			touchtime += Time.deltaTime;
		if (touchtime > 1f)
			istouch = true;
	}
	public bool IsHand(Collider other)
	{
		if (other.transform.parent && other.transform.parent.parent && other.transform.parent.parent.GetComponent<HandModel>())
			return true;
		else
			return false;
	}
	void OnTriggerExit(Collider other) 
	{
		if (IsHand(other) && istouch )
		{
			istouch = false;
			touchtime = 0;
			if (gameObject.tag == "Cat")
				FX.Play ();
			Planet.GetComponent<PlanetInteraction> ().number = number;
			Planet.GetComponent<PlanetInteraction> ().isupdate = true;
		}  
	}
}
