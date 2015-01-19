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

	public void ChangeToScene(string SceneToChangeTo)
	{
		audio.PlayOneShot (selection);
		switch (SceneToChangeTo) {
		case "levelSelection": 
			Invoke ("ChangeToLevelSelection", 0.2f);
			break;
		case "personalHighScores": 
			Invoke ("ChangeToPersonalHighScores", 0.2f);
			break;
		case "onlineHighScores": 
			Invoke ("ChangeToOnlineHighScores", 0.2f);
			break;
		default:
			break;
		}
	}

	//helper method to play sound
	public void ChangeToLevelSelection(){
		Application.LoadLevel("levelSelection");
	}

	//helper method to play sound
	public void ChangeToPersonalHighScores(){
		Application.LoadLevel("personalHighScores");
	}

	//helper method to play sound
	public void ChangeToOnlineHighScores(){
		Application.LoadLevel("onlineHighScores");
	}



	public void ExitGame(){
		audio.PlayOneShot (deselection);
		Invoke ("Quit", 0.2f);
	}

	//helper method to play sound
	public void Quit(){
		Application.Quit();
	}

	public void setPlayerName(){
		audio.PlayOneShot (selectName);
		PlayerPrefs.SetString ("PlayerName", playerName.text);
	}
}
