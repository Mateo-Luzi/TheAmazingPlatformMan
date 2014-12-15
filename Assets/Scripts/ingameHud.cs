using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ingameHud : MonoBehaviour {

	private SpaceMarineController player;
	public Text trampolineAmmoDisplay;
	public Text boosterAmmoDisplay;
	public Text timeDisplay;
	public float timeElapsed;

	// Use this for initialization
	void Start () {
		timeElapsed = 0;
	}
	
	// Update is called once per frame
	void Update () {

		timeElapsed = Time.time;
		timeDisplay.text = timeElapsed.ToString("F2");

		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpaceMarineController> ();
			if (player == null)
				return;
		}

		trampolineAmmoDisplay.text = player.trampolineAmmo + "/" + player.maxAmmo;
		boosterAmmoDisplay.text = player.boosterAmmo + "/" + player.maxAmmo;


	}
	
}
