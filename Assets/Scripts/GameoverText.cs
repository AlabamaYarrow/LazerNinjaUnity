using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameoverText : MonoBehaviour {

	public Text text;

	private Color TextColor;

	// Use this for initialization
	void Start () {
		text.color = Color.clear;
		TextColor = new Color();
		Color.TryParseHexString("#C2C2C2FF", out TextColor);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Appear () {		
		text.color = TextColor;
	}
}
		                       