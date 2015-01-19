using UnityEngine;
using System.Collections;

public class levelSelect : MonoBehaviour {

	public AudioClip selection;

	void Update()	{
		Screen.showCursor = true;
	}

	public void ChangeToScene(string sceneToChangeTo){
		Application.LoadLevel(sceneToChangeTo);
	}

	public void BackToMainMenu(){
		audio.PlayOneShot (selection);
		//delay method call for changing scene so audio clip finishes playing
		Invoke ("ChangeToMainMenu", 0.2f);
	}
	
	public void ChangeToMainMenu(){
		Application.LoadLevel("mainMenu");
	}
}
