using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SphereCollider))]
[RequireComponent (typeof (AudioSource))]

public class PlanetInteraction : MonoBehaviour {
	SphereCollider collider;
	AudioSource music;
	public AudioClip[] source;
	bool playnow;
	public bool isupdate;
	public int number;
	bool istouch;
	float touchtime;
	private float time;
	private Renderer render;
	private Shader normal;
	private Shader active;
	// Use this for initialization
	void Start () {
		render = GetComponent<Renderer> ();
		active = render.material.shader;
		normal = Shader.Find ("Standard");
		render.material.shader = normal;
		collider = GetComponent<SphereCollider>();
		collider.isTrigger = true;
		music = GetComponent<AudioSource> ();
		isupdate = false;
		music.clip = source [0];
		music.Pause ();
		GetComponent<ScalingTest> ().enabled = false;
		time = 0;
		istouch = true;
	}
	IEnumerator change(int number){
		if (isupdate) {
			if (this.gameObject.name == "havay") {
				GameObject manager = GameObject.Find ("Planet_Manager");

				yield return new WaitForSeconds (music.clip.length - time);
				manager.GetComponent<AniManager> ().needupdate = true;
			}
			bool next = music.isPlaying;
			music.clip = source [number];
			if (next) {
				music.Play ();
			}
			isupdate = false;

		}

	}
	// Update is called once per frame
	void FixedUpdate () {
		time = time + Time.deltaTime;
		if (!istouch)
		touchtime += Time.deltaTime;
		if (touchtime > 1f)
			istouch = true;
		if (time >= music.clip.length)
			time = 0;
		StartCoroutine (change (number));
	}
	public bool IsHand(Collider other)
	{
		if (other.transform.parent && other.transform.parent.parent && other.transform.parent.parent.GetComponent<HandModel>())
			return true;
		else
			return false;
	}
	void Update(){
		if (music.isPlaying) {
			GetComponent<ScalingTest> ().enabled = true;
		} else {
			GetComponent<ScalingTest> ().enabled = false;
		}
	}

	void OnTriggerExit(Collider other) 
	{
		if (IsHand(other) && istouch )
		{
			istouch = false;
			touchtime = 0;
			if (music.isPlaying) {
				music.Pause ();
				music.clip = source [0];
				render.material.shader = normal;
				GetComponent<ScalingTest> ().enabled = false;
			} else {
				music.Play ();
				render.material.shader = active;
				GetComponent<ScalingTest> ().enabled = true;
			}
		}  
	}

}
