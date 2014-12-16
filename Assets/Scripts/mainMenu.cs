using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	void Update()	{
		Screen.showCursor = true;
	}

	public void ChangeToScene(string sceneToChangeTo){
		Application.LoadLevel(sceneToChangeTo);
	}

	public void ExitGame(){
		Application.Quit();
	}
}
