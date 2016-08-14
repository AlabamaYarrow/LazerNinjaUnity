using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameoverText : MonoBehaviour {

	public Text text;

	private Color TextColor;

	void Start () {
		text.color = Color.clear;
		TextColor = new Color();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Appear () {		
		text.color = TextColor;
	}
}
		                       