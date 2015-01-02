using UnityEngine;
using System.Collections;

public class levelSelect : MonoBehaviour {

	void Update()	{
		Screen.showCursor = true;
	}

	public void ChangeToScene(string sceneToChangeTo){
		Application.LoadLevel(sceneToChangeTo);
	}

	public void BackToMainMenu(){
		Application.LoadLevel("mainMenu");
	}
}
