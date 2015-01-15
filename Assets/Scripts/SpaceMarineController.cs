using UnityEngine;
using System;
using System.Collections;

public class SpaceMarineController : MonoBehaviour {

	public  bool facingRight = true;
	public  bool grounded = false;
	public  int platformMode = 1;

	public float move;
	public float maxSpeed;
	public float jumpVelocity;
	
	private float groundRadius = 1.05f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	
	public AudioClip jumpSound;
	public AudioClip switchWeaponSound;
	public AudioClip deathSound;
	public AudioClip pickupSound;

	public bool canMove = true;
	public bool canGround = true;
	public bool dying = false;

	public int trampolineAmmo = 0;
	public int boosterAmmo = 0;

	public int maxAmmo;

	public float timeAlive;
	public float spawnTime;

	public float amplitude;
	public float tempAmplitude;
	private float originalRange;

	private Vector3 originalScale;
	private float tempVelocity;


	// Use this for initialization
	void Start () {

		Time.timeScale = 0;
		canGround = false;
		canMove = false;
		grounded = false;

		spawnTime = Time.time;
		originalRange = gameObject.light.range;
		originalScale = transform.localScale;

	}
	

	void FixedUpdate () {
		if (canMove && !dying) 
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		if (gameObject.rigidbody2D.velocity.y >= 0) {
			float newYVelocity = Mathf.SmoothDamp (originalScale.y, (originalScale.y - (Mathf.Abs (gameObject.rigidbody2D.velocity.y) / 3)), ref tempVelocity, 0.01875f);
			if(newYVelocity < 0.2f)
				newYVelocity = 0.3f;
			transform.localScale = new Vector3 (originalScale.x, newYVelocity, originalScale.z);
		}


	}
	// Update is called once per frame
	void Update(){

		// freeze game on spawn
		if (timeAlive < 0.05f && Input.anyKey) {
			Time.timeScale = 1;
			canGround = true;
			canMove = true;
			grounded = true;
		}
		if(Time.timeScale > 0)
			timeAlive = (float)Math.Round((double)(Time.time - spawnTime),3);

		// hacks to get booster platform to work properly
		if (canGround) {
			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		}
		if (grounded)
			canMove = true;
		if(canMove)
			move = Input.GetAxisRaw("Horizontal");


		if (canMove && !dying && grounded && Input.GetKeyDown (KeyCode.Space)) {
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


		amplitude = Mathf.PingPong(Time.time * 2.0f, 3.5f);
		gameObject.light.range = originalRange - amplitude;
	}

	public void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		originalScale.x *= -1;
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
			b.enabled = false;	
		foreach (CircleCollider2D c in circleColliderList) 
			c.enabled = true;	

		// stop player, control death "animation"
		canMove = false;
		canGround = false;
		grounded = false;

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
