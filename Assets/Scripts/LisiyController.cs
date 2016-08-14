using UnityEngine;
using System.Collections;

public class LisiyController : MonoBehaviour {	
	void Start () {
	
	}
	
	void Update () {		
		if (transform.position.y > 1.0f) {
			transform.position = new Vector3 (transform.position.x, 0.9f, transform.position.z);
		}
	}
}
