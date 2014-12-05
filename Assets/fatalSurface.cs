using UnityEngine;
using System.Collections;

public class fatalSurface : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<SpaceMarineController>().Die ();
		}
	}
}
