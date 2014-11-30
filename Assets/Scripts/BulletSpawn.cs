using UnityEngine;
using System.Collections;

public class BulletSpawn : MonoBehaviour {

	public Rigidbody2D bulletPrefab;
	private Vector3 finalDestination;
	public AudioClip laserShotSound;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			var go = Instantiate(bulletPrefab, transform.position, transform.rotation);
			audio.PlayOneShot (laserShotSound);
		}


	}
}
