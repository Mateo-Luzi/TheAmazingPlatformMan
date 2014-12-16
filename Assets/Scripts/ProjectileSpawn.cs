using UnityEngine;
using System.Collections;

public class ProjectileSpawn : MonoBehaviour {

	private SpaceMarineController player;
	private PauseMenu pauseMenu;

	private Vector3 finalDestination;
	private bool cooldown = false;


	public Rigidbody2D projectilePrefab;
	public AudioClip projectileShotSound;
	public AudioClip outOfAmmoSound;


	// Use this for initialization
	void Start () {
		try{player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpaceMarineController> ();}
		catch{Start ();}

		
	}
	
	// Update is called once per frame
	void Update () {

		if (player == null) {
			try{player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpaceMarineController> ();}
			catch{return;}
		}
		if (pauseMenu == null) {
			try{pauseMenu = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<PauseMenu>();}
			catch{return;}
		}

		if(!pauseMenu.pause)
			if (Input.GetButtonDown ("Fire1")) {
				if(player.platformMode == 1){
					if(!cooldown){
						cooldown = true;
						Instantiate(projectilePrefab, transform.position, transform.rotation);
						audio.PlayOneShot (projectileShotSound);
						StartCoroutine(resetCooldown ());
					}
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

	IEnumerator resetCooldown(){
		yield return new WaitForSeconds(0.33f);
		cooldown = false;
	}
}
