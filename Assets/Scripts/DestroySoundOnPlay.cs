using UnityEngine;
using System.Collections;

public class DestroySoundOnPlay : MonoBehaviour {

	private float totalTimeBeforeDestroy;

	void Start () {
		var sound = this.GetComponent<AudioSource> ();
		totalTimeBeforeDestroy = sound.clip.length;
	}

	void Update () {
		totalTimeBeforeDestroy -= Time.deltaTime;
		if (totalTimeBeforeDestroy < 0f) {
			Destroy (this.gameObject);
		}
	}
}
