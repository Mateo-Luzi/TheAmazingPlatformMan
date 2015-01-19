using UnityEngine;
using System.Collections;

public class levelSelect : MonoBehaviour {

	public AudioClip selection;

	void Update()	{
		Screen.showCursor = true;
	}

	public void ChangeToScene(string sceneToChangeTo){
		BGM.playSound (selection);
		Application.LoadLevel(sceneToChangeTo);
	}

	public void BackToMainMenu(){
		BGM.playSound (selection);
		Application.LoadLevel("mainMenu");
	}
}
