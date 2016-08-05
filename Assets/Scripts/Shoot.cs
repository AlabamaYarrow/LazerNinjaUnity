using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public Rigidbody Bullet;
	public float ShootForce;
	public Transform ShootPosition;
	public float verticalOffset;
	public GameObject GunShot;
	public AudioSource ShootSound;

	private float delay = 6.0f; 

	void Start () {
		InvokeRepeating("ShootBullet", 1, 1);

	}
	
	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			ShootBullet();
		}
	}

	WaitForSeconds Wait() {
		return new WaitForSeconds(1);
	}

	void ShootBullet() {
		Vector3 position = transform.position;
		position.y = position.y + verticalOffset;
		Rigidbody instanceBullet = (Rigidbody) Instantiate (Bullet, position, ShootPosition.rotation);
		instanceBullet.GetComponent<Rigidbody> ().AddForce (ShootPosition.forward * ShootForce);
		ShootSound.Play ();

		Object.Destroy(instanceBullet, delay);

	}	
}
