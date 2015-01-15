using UnityEngine;
using System.Collections;

public class PlatformGunMovement : MonoBehaviour {

	private SpaceMarineController player;

	private float x;
	private Exit exit;
	private Vector3 ls;
	private Vector3 direction;
	private float rotationZ;

	// Use this for initialization
	void Start () {
		x = transform.localScale.x;
		ls = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		if (player == null) {
			try{player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpaceMarineController> ();}
			catch{return;}
		}

		if (exit == null) {
			try{exit = GameObject.FindGameObjectWithTag ("ExitDoor").GetComponent<Exit> ();}
			catch{return;}
		}

		if(Time.timeScale > 0 && !exit.finished){
			direction = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);
			rotationZ = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;

			if (!player.facingRight)
				rotationZ = - rotationZ;
			if (direction.x >= 0) 
				transform.rotation = Quaternion.Euler (0f, 0f, rotationZ);
			else 
				transform.rotation = Quaternion.Euler (0f, 0f, rotationZ + 180);
		
			ls.x = x;
			transform.localScale = ls;

			if (direction.x >= 0 && !player.facingRight) {
				player.Flip ();
				transform.rotation = Quaternion.LookRotation (Vector3.forward, Vector3.up);
			} 
			else {
				if(direction.x < -0 && player.facingRight){
					player.Flip ();
					transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
				}
			}
		}
	}

}
