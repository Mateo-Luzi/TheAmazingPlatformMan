using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {


	private SpaceMarineController player;
	private FinishMenu finishMenu;
	public bool finished;


	// Use this for initialization
	void Start () {
		finished = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpaceMarineController> ();
			if (player == null)
				return;
		}
		if (finishMenu == null) {
			try{ finishMenu = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<FinishMenu> ();}
			catch{ Debug.Log("FinishMenu not found!"); return; }
		}
	}

	public void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player" && !finished) {
			finished = true;
			finishMenu.pauseGame();
		}
	}
}
