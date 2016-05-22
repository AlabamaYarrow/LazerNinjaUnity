using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameoverText : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
		text.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Appear () {
		text.color = Color.red;
	}
}
		                       