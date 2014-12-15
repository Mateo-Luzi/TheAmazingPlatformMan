using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ingameHud : MonoBehaviour {

	private SpaceMarineController player;
	public Text trampolineAmmoDisplay;
	public Text boosterAmmoDisplay;
	public Text timeDisplay;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpaceMarineController> ();
			if (player == null)
				return;
		}

		timeDisplay.text = player.timeAlive.ToString("F2");

		trampolineAmmoDisplay.text = player.trampolineAmmo + "/" + player.maxAmmo;
		boosterAmmoDisplay.text = player.boosterAmmo + "/" + player.maxAmmo;


	}
	
}
