using UnityEngine;
using System.Collections;

public class fatalSurface : MonoBehaviour {

	public string sceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<SpaceMarineController>().Die ();
			StartCoroutine (SceneChange());

		}
	}

	private IEnumerator SceneChange(){

		yield return new WaitForSeconds (1.0f);
		Application.LoadLevel (sceneName);

	}
}
