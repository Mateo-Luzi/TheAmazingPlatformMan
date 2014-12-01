using UnityEngine;
using System.Collections;

public class ProjectileSpawn : MonoBehaviour {

	public Rigidbody2D projectilePrefab;
	private Vector3 finalDestination;
	public AudioClip projectileShotSound;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			var go = Instantiate(projectilePrefab, transform.position, transform.rotation);
			audio.PlayOneShot (projectileShotSound);
		}
	}
}
