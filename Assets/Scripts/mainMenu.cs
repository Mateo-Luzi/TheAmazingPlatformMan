using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	public AudioClip selection;
	public AudioClip deselection;

	void Update()	{
		Screen.showCursor = true;
	}

	public void ChangeToScene(string sceneToChangeTo){
		audio.PlayOneShot (selection);
		Application.LoadLevel(sceneToChangeTo);
	}

	public void ExitGame(){
		audio.PlayOneShot (deselection);
		Application.Quit();
	}
}
