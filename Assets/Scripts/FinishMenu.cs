using UnityEngine;
using System.Collections;
using System;

public class FinishMenu : MonoBehaviour {

	private Exit exit;
	private Rect windowRect;
	private SpaceMarineController player;
	public bool pause;

	// Use this for initialization
	void Start () {
		windowRect = new Rect (Screen.width/2 - 100, Screen.height/2 - 100, 200, 200);
		pause = false;
	}

	void Update () {
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpaceMarineController> ();
			if (player == null)
				return;
		}

		if (exit == null) {
			exit = GameObject.FindGameObjectWithTag ("ExitDoor").GetComponent<Exit> ();
			if (exit == null)
				return;
		}

	}

	void OnGUI () {


		if (exit.finished == true) {
			windowRect = GUI.Window (0, windowRect, windowFunc, "Level Complete!");
			Debug.Log(windowRect);
			pause = true;
			Debug.Log(pause);
		}
	}
	
	void windowFunc(int id){
		if (GUILayout.Button ("Restart Level")) {
			Application.LoadLevel (Application.loadedLevelName);
			Time.timeScale = 1;
		}
		if (GUILayout.Button ("Exit to Main Menu")) {
			Application.LoadLevel ("mainMenu");
			Time.timeScale = 1;
		}
		if (GUILayout.Button ("Exit Game"))
			Application.Quit ();
	}

	public void pauseGame(){
		player.canGround = false;
		player.grounded = false;
		player.canMove = false;	
		Time.timeScale = 0;
	}
	
}
