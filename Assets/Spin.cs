using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	public float speed = 10f;

	public Vector3 direction = new Vector3(0,0,3);
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(direction, speed * Time.deltaTime);
	}
}
