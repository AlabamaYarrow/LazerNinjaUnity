using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public static int health = 100;
	public Slider HealthBar;
	public Text HealthText;
	public Text TimerText;
	public int decreaseSpeed = 1;
	public int GameOverDelay = 2;

	private float time;
	private Color TimerEndColor;

	private bool TimerCountAllowed = true;

	GameObject GameoverTextLeft;
	GameObject GameoverTextRight;

	void Start () {
		health = 100;
		GameoverTextLeft = GameObject.Find("GameOverTextLeft");

		TimerEndColor = new Color(0.9f, 0.625f, 0f, 1f);
//		Color.TryParseHexString("#E8A000FF", out TimerEndColor);

	}

	void Update () {
		if (TimerCountAllowed) {
			time += Time.deltaTime;
		
			var seconds = (int)time;
			var fraction = time - (int)time;
		
			TimerText.text = string.Format ("{0} sec", time.ToString ("0.000"));
		}
	}

	void SetHealth() {
		HealthBar.value = health;
		HealthText.text = health.ToString();
	}

	IEnumerator WaitAndLoadLevel() {		
		yield return new WaitForSeconds (GameOverDelay);
		Debug.Log ("Waited.");
		Application.LoadLevel (2);
	}

	public void DecreaseHealth() 
	{
		if (health <= 0) {
			var gameoverText = GameoverTextLeft.GetComponent<GameoverText> ();
			gameoverText.Appear ();

			health = 0;
			SetHealth ();
			TimerCountAllowed = false;
			TimerText.color = TimerEndColor;
			StartCoroutine("WaitAndLoadLevel");
		} else {
			SetHealth ();
			health -= decreaseSpeed;
		}
	}


}




