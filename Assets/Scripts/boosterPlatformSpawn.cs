using UnityEngine;
using System.Collections;

public class boosterPlatformSpawn : MonoBehaviour {

	private SpaceMarineController player;
	public float trampolineJumpVelocity;
	public AudioClip boosterSound;
	private bool directionalBoosterEnabled = true;

	// needed for directional booster
	Vector3 pos;
	Vector3 dir;
	float angle;
	

	// Use this for initialization
	void Start () {
		try{player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpaceMarineController> ();}
		catch{Start ();}
		player.boosterAmmo--;
		Destroy (gameObject, 10.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (player == null) {
			try{player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpaceMarineController> ();}
			catch{return;}
		}

		// make platform turn to the direction it is going to boost the player to
		if (player.facingRight)
			transform.rotation = Quaternion.Euler (0, 0, -270f);
		else
			transform.rotation = Quaternion.Euler (0, 0, -90f);

		// this experimental code makes the boost direction dependend on the position of the crosshair in relation to the player, the platform direction is adjusted accordingly
		// this type of booster platform could be used as an advanced upgrade to the standard booster
		if (directionalBoosterEnabled) {
			pos = Camera.main.WorldToScreenPoint(transform.position);
			dir = Input.mousePosition - pos;
			angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			angle += 90f;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D  col)
	{
		if (col.gameObject.tag == "Player") {
			StartCoroutine(boostPlayer(col));
		}
		
		if (col.gameObject.tag == "Ground") {
			player.boosterAmmo++;
			Destroy (gameObject);	
		}
	}
	
	void OnCollisionEnter2D(Collision2D  col)
	{
		if (col.gameObject.tag == "Ground")
			Destroy(gameObject);
	}


	IEnumerator boostPlayer(Collider2D  col) {

		// wait for a few frames [this makes the boost mechanics (especially directional boosting) less buggy, no idea why]
		yield return new WaitForSeconds (0.05f);

		// make sure player cannot move during boost
		player.canMove = false;
		player.canGround = false;
		player.grounded = false;
		player.move = 0;

		// determine boost direction
		if(player.facingRight)
			col.gameObject.rigidbody2D.velocity = new Vector2(150.0f,50.0f);
		else
			col.gameObject.rigidbody2D.velocity = new Vector2(-150.0f,50.0f);

		// this experimental code makes the boost direction dependend on the position of the crosshair in relation to the player
		// this type of booster platform could be used as an advanced upgrade to the standard booster
		if (directionalBoosterEnabled) {
			col.gameObject.rigidbody2D.velocity = dir.normalized * 150.0f;
		}

		// prevent multiple boosts from the same booster
		gameObject.collider2D.enabled = false;

		audio.PlayOneShot (boosterSound);

		// player cannot control the character for 0.25 sec, no matter what
		yield return new WaitForSeconds (0.25f);

		// give player player control back upon touching any ground object
		player.canGround = true;

		Destroy (gameObject,0.5f);

	}
}
