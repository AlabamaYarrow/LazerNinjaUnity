using UnityEngine;
using System.Collections;

public class FalconCollideHanlder : MonoBehaviour {

	GameObject PlayerManager;

	void Start () {
		PlayerManager = GameObject.Find("PlayerManager");
	}

	void Update () {}

	void OnCollisionEnter(Collision collision) 
	{
		var health = PlayerManager.GetComponent<PlayerHealth> ();
		health.DecreaseHealth ();
	}
}
