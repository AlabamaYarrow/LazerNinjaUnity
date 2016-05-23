using UnityEngine;
using System.Collections;

public class OnStartScreen : MonoBehaviour {

	// Use this for initialization
	public InstantGuiInputText IP;
	void Start () {
		NetworkMngr.IP = IP.text;
		Application.LoadLevel (2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
