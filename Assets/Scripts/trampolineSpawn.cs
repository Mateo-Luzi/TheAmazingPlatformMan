using UnityEngine;
using System.Collections;

public class trampolineSpawn : MonoBehaviour {


	private int jumpCount;
	private SpaceMarineController player;
	public float trampolineJumpVelocity;
	public AudioClip trampolineSound;

	// Use this for initialization
	void Start () {
		try{player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpaceMarineController> ();}
		catch{Start ();}
		player.trampolineAmmo--;
		jumpCount = 0;
		Destroy (gameObject, 10.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (player == null) {
			try{player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpaceMarineController> ();}
			catch{return;}
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D  col)
	{
		if (col.gameObject.tag == "Player") {
			player.grounded = true;

			switch(jumpCount){ // this code still supports 3 jumps but only 1 is used
				case 2:
					trampolineJumpVelocity = 40;
					break;
				case 1:
					trampolineJumpVelocity = 60;
					break;
				case 0:
					trampolineJumpVelocity = 120;
					break;
			}

			// final jump velocity = ( y-AxisInitialPlayerSpeed / 2 ) + trampolineJumpVelocity
			col.gameObject.rigidbody2D.velocity = new Vector2(col.gameObject.rigidbody2D.velocity.x, (0.5f * Mathf.Abs(col.gameObject.rigidbody2D.velocity.y)) + trampolineJumpVelocity );
			audio.PlayOneShot (trampolineSound);

			if (jumpCount > 0) { // make trampoline smaller after every jump (only works when multiple jumps are used)
					transform.localScale = new Vector3 (transform.localScale.x * 0.45f, transform.localScale.y * 0.45f, transform.localScale.z * 0.45f);
					jumpCount--;
			} else
					Destroy (gameObject, 0.75f);
		}

		if (col.gameObject.tag == "Ground")
			Destroy(gameObject);


	}

	void OnCollisionEnter2D(Collision2D  col)
	{
		if (col.gameObject.tag == "Ground") {
			player.trampolineAmmo++;
			Destroy (gameObject);
		}
	}
}
