﻿using UnityEngine;
using System.Collections;

public class SpaceMarineController : MonoBehaviour {

	public  bool facingRight = true;
	public  bool grounded = false;
	public  int platformMode = 1;

	public float move;
	public float maxSpeed;
	public float jumpVelocity;
	
	private float groundRadius = 0.2f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	
	public AudioClip jumpSound;
	public AudioClip switchWeaponSound;
	public AudioClip deathSound;
	public AudioClip pickupSound;

	public bool canMove = true;
	public bool canGround = true;
	private bool dying = false;

	public int trampolineAmmo;
	public int boosterAmmo;

	public int maxAmmo;

	public float timeAlive;
	public float spawnTime;

	// Use this for initialization
	void Start () {

		trampolineAmmo = 5;
		boosterAmmo = 5;
		spawnTime = Time.time;
	}
	

	void FixedUpdate () {
		if (canMove == true) 
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
	}
	// Update is called once per frame
	void Update(){

		timeAlive = Time.time - spawnTime;
		// hacks to get booster platform to work properly
		if(canGround)
			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		if (grounded)
			canMove = true;
		if(canMove)
			move = Input.GetAxisRaw("Horizontal");


		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			rigidbody2D.velocity = new Vector2(0,jumpVelocity);
			audio.PlayOneShot(jumpSound);
		}

		// platform switch
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			if(boosterAmmo > 0){
				platformMode = 3;
				audio.PlayOneShot (switchWeaponSound);
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			if(trampolineAmmo > 0){
				platformMode = 2;
				audio.PlayOneShot (switchWeaponSound);
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			platformMode = 1;
			audio.PlayOneShot (switchWeaponSound);
		}

	}

	public void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void Die(){
		if(!dying)
			StartCoroutine (killPlayer());
	}

	IEnumerator killPlayer(){

		dying = true;

		audio.PlayOneShot (deathSound);

		// make player fall through level
		BoxCollider2D[] boxColliderList = gameObject.GetComponents<BoxCollider2D> ();
		CircleCollider2D[] circleColliderList = gameObject.GetComponents<CircleCollider2D> ();
		foreach (BoxCollider2D b in boxColliderList) 
			b.isTrigger = true;		
		foreach (CircleCollider2D c in circleColliderList) 
			c.isTrigger = true;	

		// stop player, control death "animation"
		canGround = false;
		grounded = false;
		canMove = false;
		gameObject.rigidbody2D.gravityScale = 0;

		// float up
		gameObject.rigidbody2D.velocity = new Vector2 (0, 10);
		yield return new WaitForSeconds (0.5f);
		// fall down
		gameObject.rigidbody2D.velocity = new Vector2 (0, -35);
		yield return new WaitForSeconds (1.0f);

		Application.LoadLevel (Application.loadedLevelName);
	}

	public void PlayPickupSound()
	{
		audio.PlayOneShot (pickupSound);
	}


}
