﻿using UnityEngine;
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
		BGM.playSound (selection);
		Application.LoadLevel(SceneToChangeTo);
	}

	public void ExitGame(){
		BGM.playSound(deselection);
		Invoke ("Quit", 0.2f);
	}

	//helper method to play sound
	public void Quit(){
		Application.Quit();
	}

	public void setPlayerName(){
		BGM.playSound(selectName);
		PlayerPrefs.SetString ("PlayerName", playerName.text);
	}
}
