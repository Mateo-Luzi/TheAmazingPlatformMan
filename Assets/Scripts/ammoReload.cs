using UnityEngine;
using System.Collections;

public class ammoReload : MonoBehaviour {

	public GameObject platformPrefab;	
	public int reloadAmount;


	// Use this for initialization
	void Start () {
		gameObject.GetComponent<TextMesh>().text = reloadAmount.ToString()+ "x";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){

		SpaceMarineController player = col.GetComponent<SpaceMarineController>();

		// reload player ammo up until ammo limit is reached

		if (col.gameObject.tag == "Player") {
			if(platformPrefab.tag == "TrampolinePlatform"){
				player.trampolineAmmo += reloadAmount;	
				if(player.trampolineAmmo > player.maxAmmo)
					player.trampolineAmmo = player.maxAmmo;
			}
			if(platformPrefab.tag == "BoosterPlatform"){
				player.boosterAmmo += reloadAmount;	
				if(player.boosterAmmo > player.maxAmmo)
					player.boosterAmmo = player.maxAmmo;
			}

			player.PlayPickupSound();
			Destroy (gameObject);
		}
	}
}
