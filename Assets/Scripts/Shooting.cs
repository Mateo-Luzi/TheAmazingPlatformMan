using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	private float x;
	private Vector3 ls;
	private Vector3 destination;
	private Vector3 finalDestination;
	public Rigidbody2D platformPrefab;
	public Rigidbody2D trampolinePrefab;


	



	void Start () {
		// make the laser rotate to the cursor
		x = transform.localScale.x;
		ls = transform.localScale;
		Vector3 dir2 = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);
		float rotZ = Mathf.Atan2 (dir2.y, dir2.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ);
		ls.x = x;
		transform.localScale = ls;

		finalDestination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		finalDestination.z = 0;

		Destroy (gameObject, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.MoveTowards (transform.position, finalDestination,1.5f);

		if (finalDestination == transform.position) {

			switch(SpaceMarineController.platformMode){
			case 1:
				Instantiate(platformPrefab, transform.position, Quaternion.identity);	
				break;
			case 2:
				Instantiate(trampolinePrefab, transform.position, Quaternion.identity);	
				break;

			}
			Destroy(gameObject);		
		}

	}
	
	void OnCollisionEnter2D(Collision2D  col){
		if (col.gameObject.tag != "Projectile" && col.gameObject.tag != "Player")
			Destroy(gameObject);	
	}

}
