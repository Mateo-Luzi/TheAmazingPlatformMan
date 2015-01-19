using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	public AudioClip selection;
	public AudioClip deselection;
	public AudioClip selectName;

	public UnityEngine.UI.InputField playerName;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("PlayerName")) {
			playerName.text = PlayerPrefs.GetString("PlayerName");
		}
	}

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

	public void setPlayerName(){
		audio.PlayOneShot (selectName);
		PlayerPrefs.SetString ("PlayerName", playerName.text);
	}
}
