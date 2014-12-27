using UnityEngine;
using System.Collections;

public class boosterPlatformSpawn : MonoBehaviour {
	
	private bool canCollide = true;
	private SpaceMarineController player;
	public float trampolineJumpVelocity;
	public AudioClip boosterSound;

	// directional booster test code
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
		if (player.facingRight)
						transform.rotation = Quaternion.Euler (0, 0, -270f);
		else
			transform.rotation = Quaternion.Euler (0, 0, -90f);
		
		// directional booster test code
//		pos = Camera.main.WorldToScreenPoint(transform.position);
//		dir = Input.mousePosition - pos;
//		angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
//		angle += 90f;
//		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
		
	}
	
	void OnTriggerEnter2D(Collider2D  col)
	{
		if (col.gameObject.tag == "Player" && canCollide) {
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

		// wait for at least 1 frame
		yield return new WaitForSeconds(0.05f);


		// make sure player cannot move character
		player.canMove = false;
		player.canGround = false;
		player.grounded = false;
		player.move = 0;

		if(player.facingRight)
			col.gameObject.rigidbody2D.velocity = new Vector2(150.0f,50.0f);
		else
			col.gameObject.rigidbody2D.velocity = new Vector2(-150.0f,50.0f);

		// directional booster test code
		//col.gameObject.rigidbody2D.velocity = dir.normalized * 150.0f;

		canCollide = false;

		audio.PlayOneShot (boosterSound);
		yield return new WaitForSeconds (0.25f);

		player.canGround = true;
		Destroy (gameObject,0.5f);



	}
}
