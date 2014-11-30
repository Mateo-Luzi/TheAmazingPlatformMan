using UnityEngine;
using System.Collections;

public class trampolineSpawn : MonoBehaviour {


	private int jumpCount;
	public AudioClip trampolineSound;

	// Use this for initialization
	void Start () {
		jumpCount = 2;
		Destroy (gameObject, 10.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
	
	void OnTriggerEnter2D(Collider2D  col)
	{
		if (col.gameObject.tag == "Player") {
			col.gameObject.rigidbody2D.velocity = new Vector2(col.gameObject.rigidbody2D.velocity.x,100);
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
		if (col.gameObject.tag == "Ground")
			Destroy(gameObject);
	}
}
