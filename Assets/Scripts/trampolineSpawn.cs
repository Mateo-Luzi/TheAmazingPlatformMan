using UnityEngine;
using System.Collections;

public class trampolineSpawn : MonoBehaviour {


	private int jumpCount;
	private SpaceMarineController player;
	public float trampolineJumpVelocity;
	public AudioClip trampolineSound;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Character").GetComponent<SpaceMarineController> ();
		player.trampolineAmmo--;
		jumpCount = 2;
		Destroy (gameObject, 10.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
	
	void OnTriggerEnter2D(Collider2D  col)
	{
		if (col.gameObject.tag == "Player") {
			player.grounded = true;
			col.gameObject.rigidbody2D.velocity = new Vector2(col.gameObject.rigidbody2D.velocity.x, (0.75f * Mathf.Abs(col.gameObject.rigidbody2D.velocity.y)) + trampolineJumpVelocity);
			audio.PlayOneShot (trampolineSound);

			if (jumpCount > 0) {
					transform.localScale = new Vector3 (transform.localScale.x * 0.45f, transform.localScale.y * 0.45f, transform.localScale.z * 0.45f);
					jumpCount--;
			} else
					Destroy (gameObject, 0.25f);
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
