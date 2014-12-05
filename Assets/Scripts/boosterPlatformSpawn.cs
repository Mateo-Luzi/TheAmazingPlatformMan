using UnityEngine;
using System.Collections;

public class boosterPlatformSpawn : MonoBehaviour {
	
	private bool canCollide = true;
	private SpaceMarineController player;
	public float trampolineJumpVelocity;
	public AudioClip trampolineSound;


	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Character").GetComponent<SpaceMarineController> ();
		Destroy (gameObject, 10.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
	
	void OnTriggerEnter2D(Collider2D  col)
	{
		if (col.gameObject.tag == "Player" && canCollide) {
			StartCoroutine(boostPlayer(col));
		}
		
		if (col.gameObject.tag == "Ground")
			Destroy(gameObject);	
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
		col.gameObject.rigidbody2D.velocity = new Vector2(0,0);


		if(player.facingRight)
			col.gameObject.rigidbody2D.velocity = new Vector2(150.0f,50.0f);
		else
			col.gameObject.rigidbody2D.velocity = new Vector2(-150.0f,50.0f);
		canCollide = false;

		player.canGround = true;
		Destroy (gameObject,1.0f);
		audio.PlayOneShot (trampolineSound);


	}
}
