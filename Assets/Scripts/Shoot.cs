using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public Rigidbody Bullet;
	public float ShootForce;
	public Transform ShootPosition;
	public float verticalOffset;
	public float horizontalOffset;
	public float forwardOffset;
	public float playerHeight;
	public GameObject GunShot;
	public AudioSource ShootSound;

	public float RateDecreaseSpeed;
	public float repeatRate;

	public float StartDelay;

	private float delay = 6.0f; 



	void Start () {
		StartCoroutine ("WaitAndStartShooting");
		InvokeRepeating ("DecreaseRate", 1, 1);
		//Debug.Log("Started!");

	}

	void DecreaseRate() {
		repeatRate -= RateDecreaseSpeed;
	}

	IEnumerator WaitAndStartShooting() {
		yield return new WaitForSeconds (StartDelay);
		while (true) {
			yield return new WaitForSeconds (repeatRate);
			ShootBullet();
		}
	}

	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			ShootBullet();
		}
	}

	void ShootBullet() {
		Vector3 position = transform.position;
		position.y = position.y + verticalOffset;
		position.z = position.z + horizontalOffset;
		position.x = position.x + forwardOffset;
		Rigidbody instanceBullet = (Rigidbody) Instantiate (Bullet, position, ShootPosition.rotation);

		Vector3 direction = new Vector3 ();
		Vector3 zero = new Vector3 (0, playerHeight, 0);

		Vector3 fluctuation = new Vector3 (Random.Range (-0.15f, 0.15f),
		                                   Random.Range (0, 0.5f),
		                                   Random.Range (-0.15f, 0.15f));

		zero += fluctuation;

		//Debug.Log ("Zero" + zero.ToString ());
		//Debug.Log ("Position" + position.ToString());
		direction = zero - position;
		//Debug.Log ("Direction" + direction.ToString());

		direction = direction.normalized;
		//Debug.Log ("Normalized" + direction.ToString());

		instanceBullet.GetComponent<Rigidbody> ().AddForce (direction * ShootForce);
		ShootSound.Play ();

		Object.Destroy(instanceBullet, delay);

	}	
}
