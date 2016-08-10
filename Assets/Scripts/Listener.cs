using UnityEngine;
using System.Collections;

public class Listener : MonoBehaviour {

	// Use this for initialization
	public BroadcastListener lstnr; 
	void Start () {
//		lstnr = new BroadcastListener ();
		lstnr.Initialize();
		lstnr.StartAsClient ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
}
