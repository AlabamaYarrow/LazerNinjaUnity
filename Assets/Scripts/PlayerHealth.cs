using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public static int health = 100;
	public Slider HealthBar;
	public Text HealthText;
	public Text TimerText;
	public Text GameoverText;
	public AudioSource GameOverSound;
	public Text VictoryText;
	public AudioSource VictorySound;
	public int decreaseSpeed = 1;
	public int GameOverDelay = 2;

	private float time;
	private bool finishing = false;
	private Color TimerEndColor;
	private float VictoryTimeoutMins;

	private bool TimerCountAllowed = true;

	void Start () {		
		// Debug.Log (ApplicationModel.CurrentDifficultyLevel);
		TimerEndColor = new Color(0.9f, 0.625f, 0f, 1f);
		GameoverText.enabled = false;
		VictoryText.enabled = false;

		health = 100;
		ApplicationModel.ShootingAllowed = true;

		if (ApplicationModel.CurrentDifficultyLevel ==
			ApplicationModel.DiffictultyLevel.TURBO) {
			VictoryTimeoutMins = 0.33f;
		} else {
			VictoryTimeoutMins = (float)ApplicationModel.CurrentDifficultyLevel + 1;
		}



		StartCoroutine("WaitForVictory");
	}

	void Update () {
		if (TimerCountAllowed) {
			time += Time.deltaTime;

			int minutes = (int)(time / 60);
			float seconds = (int)time % 60;
			var fraction = time - (int)time;
			seconds += fraction;

						
			// TimerText.text = string.Format ("{0} m {1} sec {2}", minutes, seconds, fraction.ToString("0.000"));
			TimerText.text = string.Format ("{0} m {1} s", minutes, seconds.ToString("0.00"));
		}
	}

	void SetHealth() {
		HealthBar.value = health;
		HealthText.text = health.ToString();
	}

	IEnumerator WaitAndLoadLevel() {		
		yield return new WaitForSeconds (GameOverDelay);
		Application.LoadLevel (2);
	}

	IEnumerator WaitForVictory() {		
		float WaitTime = 60 * VictoryTimeoutMins;
		yield return new WaitForSeconds (WaitTime);
		if (!finishing) {			
			finishing = true;
			ApplicationModel.ShootingAllowed = false;
			VictoryText.enabled = true;
			VictoryText.GetComponent<CanvasRenderer> ().SetAlpha (0);
			VictoryText.CrossFadeAlpha (1, 1f, false);

			if (VictorySound != null) {
				VictorySound.Play ();
			}
			StartCoroutine ("WaitAndLoadLevel");
		}
	}

	public void DecreaseHealth() 
	{
		if (health <= 0 && ! finishing) {		
			finishing = true;
			ApplicationModel.ShootingAllowed = false;
			health = 0;
			SetHealth ();
			TimerCountAllowed = false;
			TimerText.color = TimerEndColor;

			GameoverText.enabled = true;
			GameoverText.GetComponent<CanvasRenderer>().SetAlpha (0);
			GameoverText.CrossFadeAlpha (1, 1f, false);

			if (GameOverSound != null) {
				GameOverSound.Play ();
			}
			StartCoroutine("WaitAndLoadLevel");
		} else {
			SetHealth ();
			health -= decreaseSpeed;
		}
	}


}




