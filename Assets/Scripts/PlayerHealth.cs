using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public static int health = 100;
	public Slider HealthBar;
	public Text HealthText;
	public int decreaseSpeed = 1;

	void Start () {
	}

	void Update () {
	
	}

	public void DecreaseHealth() 
	{
		if (health <= 0) {
			return;
		}
		HealthBar.value = health;
		HealthText.text = health.ToString();
		health -= decreaseSpeed;
	}


}
