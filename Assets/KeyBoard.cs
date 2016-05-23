using UnityEngine;
using System.Collections;

public class KeyBoard : MonoBehaviour {

	// Use this for initialization
	public InstantGuiInputText input;
	private TouchScreenKeyboard keyboard;
	void Start () {

	}
	void OnGUI (){
		if (input.pressed) {
			keyboard = TouchScreenKeyboard.Open("");
		}
		if(keyboard!=null) input.text = keyboard.text.Trim();
	}
	// Update is called once per frame
	void Update () {
	}
}
