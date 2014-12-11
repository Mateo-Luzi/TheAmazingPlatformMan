using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
		Instantiate (playerPrefab,transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
