using UnityEngine;
using System.Collections;

public class FalconCollideHanlder : MonoBehaviour {

	public GameObject PlayerManager;

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
