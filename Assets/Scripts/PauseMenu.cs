using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private SpaceMarineController player;
	private Rect windowRect;
	private Exit exit;
	private float savedTimeScale;
	public bool pause;

	// Use this for initialization
	void Start () {
		pause = false;
		windowRect = new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200);
	}
	
	// Update is called once per frame
	void Update () {

		if (player == null) {
			try{player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpaceMarineController> ();}
			catch{return;}
		}
		if (exit == null) {
			exit = GameObject.FindGameObjectWithTag ("ExitDoor").GetComponent<Exit> ();
			if (exit == null)
				return;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(exit.finished == true)
				return;
			if(pause == true){
				pause = false;
				runGame ();
			}
			else{
				pause = true;
				pauseGame ();
			}
	
		}						
	}

	void OnGUI(){
		if (pause == true)
			windowRect = GUI.Window (0, windowRect, windowFunc, "Level " + getLevelName());
	}

	void windowFunc(int id){
		if (GUILayout.Button ("Resume")) {
						pause = false;
						runGame();
				}
		if (GUILayout.Button ("Restart Level")) {
						Application.LoadLevel (Application.loadedLevelName);
						pause = false;
						runGame();
				}
		if (GUILayout.Button ("Exit to Main Menu")) {
			Application.LoadLevel ("mainMenu");
			Time.timeScale = 1;		
		}
		if (GUILayout.Button ("Exit Game"))
						Application.Quit ();

	}

	private void runGame(){
		player.canGround = true;
		player.grounded = true;
		player.canMove = true;
		Time.timeScale = savedTimeScale;
	}

	private void pauseGame(){
		player.canGround = false;
		player.grounded = false;
		player.canMove = false;	
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0;
	}

	private string getLevelName(){
		string levelName;
		string[] nameParts;
		
		levelName = Application.loadedLevelName;


		if (levelName.Equals ("alpha_demo"))
			return "Demo";
		else {
			//returns only the real level number
			return int.Parse(levelName.Substring(levelName.Length - 3)).ToString();
		}
	}
}
