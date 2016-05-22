using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public static int health = 100;
	public Slider HealthBar;
	public Text HealthText;
	public int decreaseSpeed = 1;

	GameObject GameoverTextLeft;
	GameObject GameoverTextRight;

	void Start () {
		GameoverTextLeft = GameObject.Find("GameOverTextLeft");
		GameoverTextRight = GameObject.Find("GameOverTextRight");
	}

	void Update () {}

	void SetHealth() {
		HealthBar.value = health;
		HealthText.text = health.ToString();
	}

	public void DecreaseHealth() 
	{
		if (health <= 0) {
			var gameoverText = GameoverTextLeft.GetComponent<GameoverText> ();
			gameoverText.Appear();
			gameoverText = GameoverTextRight.GetComponent<GameoverText> ();
			gameoverText.Appear();
			health = 0;
			SetHealth ();
			return;
		}
		SetHealth ();
		health -= decreaseSpeed;
	}


}




