using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class highScores : MonoBehaviour {

	public Text demoHighScore;
	public Text level1HighScore;
	public Text level2HighScore;
	public Text level3HighScore;
	public Text level4HighScore;
	public Text level5HighScore;
	public Text level6HighScore;
	public Text level7HighScore;
	public Text level8HighScore;
	public Text level9HighScore;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("alpha_demo"))
			this.demoHighScore.text = PlayerPrefs.GetFloat("alpha_demo").ToString();
		else
			this.demoHighScore.text = "-";

		if(PlayerPrefs.HasKey("level_001"))
			this.level1HighScore.text = PlayerPrefs.GetFloat("level_001").ToString();
		else
			this.level1HighScore.text = "-";
		
		if (PlayerPrefs.HasKey ("level_002")) 
			this.level2HighScore.text = PlayerPrefs.GetFloat("level_002").ToString();
		else
			this.level2HighScore.text = "-";
		
		if (PlayerPrefs.HasKey ("level_003")) 
			this.level3HighScore.text = PlayerPrefs.GetFloat ("level_003").ToString ();
		else
			this.level3HighScore.text = "-";
		
		if(PlayerPrefs.HasKey("level_004"))
			this.level4HighScore.text = PlayerPrefs.GetFloat("level_004").ToString();
		else
			this.level4HighScore.text = "-";
						
		if(PlayerPrefs.HasKey("level_005"))
			this.level5HighScore.text = PlayerPrefs.GetFloat("level_005").ToString();
		else
			this.level5HighScore.text = "-";
							
		if(PlayerPrefs.HasKey("level_006"))
			this.level6HighScore.text = PlayerPrefs.GetFloat("level_006").ToString();
		else
			this.level6HighScore.text = "-";

		if(PlayerPrefs.HasKey("level_007"))
			this.level7HighScore.text = PlayerPrefs.GetFloat("level_007").ToString();
		else
			this.level7HighScore.text = "-";
									
		if(PlayerPrefs.HasKey("level_008"))
			this.level8HighScore.text = PlayerPrefs.GetFloat("level_008").ToString();
		else
			this.level8HighScore.text = "-";
										
		if(PlayerPrefs.HasKey("level_009"))
			this.level9HighScore.text = PlayerPrefs.GetFloat("level_009").ToString();
		else
			this.level9HighScore.text = "-";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
