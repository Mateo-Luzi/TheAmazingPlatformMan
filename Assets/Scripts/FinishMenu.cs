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
			try{exit = GameObject.FindGameObjectWithTag ("ExitDoor").GetComponent<Exit> ();}
			catch{return;}
		}

	}

	void OnGUI () {


		if (exit.finished == true) {
			windowRect = GUI.Window (0, windowRect, windowFunc, "Level " + getLevelName() + " Complete!");
			pause = true;
		}
	}
	
	void windowFunc(int id){
		if (GUILayout.Button ("Restart Level")) {
			Application.LoadLevel (Application.loadedLevelName);
			Time.timeScale = 1;
		}
		if (GUILayout.Button ("Next Level")) {
			switch (Application.loadedLevelName){
			case "alpha_demo":
				Application.LoadLevel("level_001");
				Time.timeScale = 1;
				break;
			case "level_001":
				Application.LoadLevel("level_002");
				Time.timeScale = 1;
				break;
			case "level_002":
				Application.LoadLevel("level_003");
				Time.timeScale = 1;
				break;
			case "level_003":
				Application.LoadLevel("level_004");
				Time.timeScale = 1;
				break;
			case "level_004":
				Application.LoadLevel("level_005");
				Time.timeScale = 1;
				break;
			case "level_005":
				Application.LoadLevel("level_006");
				Time.timeScale = 1;
				break;
			case "level_006":
				Application.LoadLevel("level_007");
				Time.timeScale = 1;
				break;
			case "level_007":
				Application.LoadLevel("level_008");
				Time.timeScale = 1;
				break;
			case "level_008":
				Application.LoadLevel("level_009");
				Time.timeScale = 1;
				break;
			case "level_009":
				Application.LoadLevel("highScores");
				Time.timeScale = 1;
				break;
			default:
				break;
			}
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

	private string getLevelName(){
		string levelName = Application.loadedLevelName;
		if (levelName.Equals ("alpha_demo"))
			return "Demo";
		else {
			//returns only the real level number
			return int.Parse (levelName.Substring (levelName.Length - 3)).ToString ();
		}
	}
	
}
