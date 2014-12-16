using UnityEngine;
using System.Collections;

public class FinishMenu : MonoBehaviour {

	private Exit exit;
	private Rect windowRect;

	// Use this for initialization
	void Start () {
		windowRect = new Rect (Screen.width - 100, Screen.height - 100, 200, 200);
	}

	void OnGUI () {
		if (exit == null) {
			try{exit = GameObject.FindGameObjectWithTag ("ExitDoor").GetComponent<Exit> ();}
			catch{return;}
		}

		if(exit.finished == true)
			windowRect = GUI.Window (0, windowRect, windowFunc, "Level Complete!");
	}
	
	void windowFunc(int id){
		if(GUILayout.Button ("Restart Level"))
			Application.LoadLevel (Application.loadedLevelName);
		if (GUILayout.Button ("Exit to Main Menu"))
			Application.LoadLevel ("mainMenu");
		if (GUILayout.Button ("Exit Game"))
			Application.Quit ();
		
	}

}
