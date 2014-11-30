using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour {
	
	private float x;
	private Vector3 ls;
	public SpaceMarineController marine;

	// Use this for initialization
	void Start () {
		x = transform.localScale.x;
		ls = transform.localScale;

	}


	// Update is called once per frame
	void Update () {

		Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);
		float rotZ = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;

		if (!SpaceMarineController.facingRight)
			rotZ = - rotZ;

		if (dir.x >= 0) {
			transform.rotation = Quaternion.Euler (0f, 0f, rotZ);
			ls.x = x;
			transform.localScale = ls;
		} else {
			transform.rotation = Quaternion.Euler (0f, 0f, rotZ + 180);
			ls.x = x;
			transform.localScale = ls;
		}


		if (dir.x >= 0 && !SpaceMarineController.facingRight) {
			marine.Flip ();
			transform.rotation = Quaternion.LookRotation (Vector3.forward, Vector3.up);
		} 
		else {
			if(dir.x < -0 && SpaceMarineController.facingRight){
				marine.Flip ();
				transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
			}
		}




	
	}

}
