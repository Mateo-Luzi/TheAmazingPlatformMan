using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ingameHud : MonoBehaviour {

	private SpaceMarineController player;
	public Image standard;
	public Image trampoline;
	public Image booster;
	public Color standardColor;
	public Color trampolineColor;
	public Color boosterColor;
	public Text trampolineAmmoDisplay;
	public Text boosterAmmoDisplay;
	public Text timeDisplay;

	// Use this for initialization
	void Start () {
		standardColor = standard.color;
		trampolineColor = trampoline.color;
		boosterColor = booster.color;
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


		switch (player.platformMode) {
		case 1:
			standard.color = standardColor;
			trampoline.color = Color.grey;
			booster.color = Color.grey;
			break;
		case 2:
			standard.color = Color.grey;
			trampoline.color = trampolineColor;
			booster.color = Color.grey;
			break;
		case 3:
			standard.color = Color.grey;
			trampoline.color = Color.grey;
			booster.color = boosterColor;
			break;
		default:
			break;
		}


	}
	
}
