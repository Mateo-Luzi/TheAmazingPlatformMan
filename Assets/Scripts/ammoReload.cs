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

		if (col.gameObject.tag == "Player") {
			if(platformPrefab.tag == "TrampolinePlatform"){
				col.GetComponent<SpaceMarineController>().trampolineAmmo += reloadAmount;	
				if(col.GetComponent<SpaceMarineController>().trampolineAmmo > col.GetComponent<SpaceMarineController>().maxAmmo)
					col.GetComponent<SpaceMarineController>().trampolineAmmo = col.GetComponent<SpaceMarineController>().maxAmmo;
			}
			if(platformPrefab.tag == "BoosterPlatform"){
				col.GetComponent<SpaceMarineController>().boosterAmmo += reloadAmount;	
				if(col.GetComponent<SpaceMarineController>().boosterAmmo > col.GetComponent<SpaceMarineController>().maxAmmo)
					col.GetComponent<SpaceMarineController>().boosterAmmo = col.GetComponent<SpaceMarineController>().maxAmmo;
			}

			col.GetComponent<SpaceMarineController>().PlayPickupSound();
			Destroy (gameObject);
		}
	}
}
