using UnityEngine;
using System.Collections;

public class SaberCollideHanlder : MonoBehaviour {

	public AudioSource HitSound;

	bool triggered;
	
	void Start () {
	}
		
	void OnCollisionEnter(Collision collision) 
	{
		if (triggered)
		{
			return;
		}
		triggered = true;
		Debug.Log ("Saber Collision Enter");
		HitSound.Play ();
	}

	void OnCollisionExit(Collision collision) 
	{
		if (!triggered)
		{
			return;
		}
		triggered = false;
		Debug.Log ("Saber Collision Exit");
	}
}