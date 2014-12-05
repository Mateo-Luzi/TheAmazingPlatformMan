using UnityEngine;
using System.Collections;

public class ProjectileSpawn : MonoBehaviour {

	private SpaceMarineController player;
	public Rigidbody2D projectilePrefab;
	private Vector3 finalDestination;
	public AudioClip projectileShotSound;
	public AudioClip outOfAmmoSound;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Character").GetComponent<SpaceMarineController> ();

	}
	
	// Update is called once per frame
	void Update () {



		if (Input.GetButtonDown ("Fire1")) {

			if(player.platformMode == 1){
				Instantiate(projectilePrefab, transform.position, transform.rotation);
				audio.PlayOneShot (projectileShotSound);
			}
			else if(player.platformMode == 2 && player.trampolineAmmo > 0){
				Instantiate(projectilePrefab, transform.position, transform.rotation);
				audio.PlayOneShot (projectileShotSound);
			}
			else if(player.platformMode == 3 && player.boosterAmmo > 0){
				Instantiate(projectilePrefab, transform.position, transform.rotation);
				audio.PlayOneShot (projectileShotSound);
			}else
				audio.PlayOneShot (outOfAmmoSound);


		}
	}
}
