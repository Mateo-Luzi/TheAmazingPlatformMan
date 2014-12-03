using UnityEngine;
using System.Collections;

public class boosterPlatformSpawn : MonoBehaviour {
	
	private bool canCollide = true;
	public float trampolineJumpVelocity;
	public AudioClip trampolineSound;
	
	// Use this for initialization
	void Start () {

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
		col.gameObject.GetComponent<SpaceMarineController>().canMove = false;


		col.gameObject.GetComponent<SpaceMarineController> ().canGround = false;
		SpaceMarineController.grounded = false;
		col.gameObject.GetComponent<SpaceMarineController> ().move = 0;
		col.gameObject.rigidbody2D.velocity = new Vector2(0,0);


		if(SpaceMarineController.facingRight)
			col.gameObject.rigidbody2D.velocity = new Vector2(150.0f,50.0f);
		else
			col.gameObject.rigidbody2D.velocity = new Vector2(-150.0f,50.0f);
		canCollide = false;

		col.gameObject.GetComponent<SpaceMarineController> ().canGround = true;
		Destroy (gameObject,1.0f);
		audio.PlayOneShot (trampolineSound);


	}
}
