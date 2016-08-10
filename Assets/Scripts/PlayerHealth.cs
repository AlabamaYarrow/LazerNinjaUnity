using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public static int health = 100;
	public Slider HealthBar;
	public Text HealthText;
	public Text TimerText;	
	public AudioSource GameOverSound;
	public int decreaseSpeed = 1;
	public int GameOverDelay = 2;

	private float time;
	private Color TimerEndColor;

	private bool TimerCountAllowed = true;
	private bool finishing = false;

	GameObject GameoverTextLeft;
	GameObject GameoverTextRight;

	void Start () {
		health = 100;
		GameoverTextLeft = GameObject.Find("GameOverTextLeft");

		TimerEndColor = new Color();
		Color.TryParseHexString("#E8A000FF", out TimerEndColor);

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
		if (health <= 0 && ! finishing) {
			finishing = true;

			var gameoverText = GameoverTextLeft.GetComponent<GameoverText> ();
			gameoverText.Appear ();

			health = 0;
			SetHealth ();
			TimerCountAllowed = false;
			TimerText.color = TimerEndColor;
			GameOverSound.Play();
			StartCoroutine("WaitAndLoadLevel");
		} else {
			SetHealth ();
			health -= decreaseSpeed;
		}
	}


}




