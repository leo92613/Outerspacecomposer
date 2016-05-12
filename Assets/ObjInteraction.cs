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
	public bool ischosen;
	private Vector3 scalerfactor;
	public GameObject[] peer;
	//private Renderer render;
	//private Shader normal;
	//private Shader active;
	// Use this for initializationß
	void Start () {
		//render = GetComponent<Renderer> ();
		//active = render.material.shader;
		//normal = Shader.Find ("Almgp/two_side_shader");
		//render.material.shader = normal;
		collider = GetComponent<BoxCollider> ();
		collider.isTrigger = true;
		Planet = GetComponent<RotateAround> ().center;
		if (gameObject.tag == "Cat")
			FX = GetComponent<AudioSource> ();
		ischosen = false;
		scalerfactor = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (!Planet.GetComponent<AudioSource> ().isPlaying)
			ischosen = false;
		if (!istouch)
			touchtime += Time.deltaTime;
		if (touchtime > 1f)
			istouch = true;
		if (ischosen) {
			//render.material.shader = active;
			transform.localScale = scalerfactor * Mathf.Sin (Time.time * 5f)*0.15f + scalerfactor;//new Vector3 (Mathf.Sin (Time.time * 5f), Mathf.Sin (Time.time * 5f), Mathf.Sin (Time.time * 5f)) * 0.3f  + scalerfactor;
		}
		if (!ischosen) {
			//render.material.shader = normal;
		}
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
			ischosen = true;
			for (int i = 0; i < peer.Length; i++)
				peer [i].GetComponent<ObjInteraction> ().ischosen = false;
		}  
	}
}
