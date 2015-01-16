using UnityEngine;
using System.Collections;
using System.Text;
using System.Security;

public class Exit : MonoBehaviour {


	private SpaceMarineController player;
	private FinishMenu finishMenu;
	public bool finished;
	public AudioClip exitSound;





	public string secretKey = "12345";
	public string PostScoreUrl = "http://www.tapm.cwsurf.de/postScore.php?";
	public string GetHighscoreUrl = "http://www.tapm.cwsurf.de/getHighscore.php";
	
	private string name = "Name";
	private string score = "Score";
	private string level = "Level";
	private string WindowTitel = "";
	private string Score = "";
	
	public GUISkin Skin;
	public float windowWidth = 380;
	private float windowHeight = 300;
	public Rect windowRect;
	
	public int maxNameLength = 10;
	public int getLimitScore = 15;


	// Use this for initialization
	void Start () {
		finished = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			try{player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpaceMarineController> ();}
			catch{return;}
		}
		if (finishMenu == null) {
			try{ finishMenu = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<FinishMenu> ();}
			catch{ Debug.Log("FinishMenu not found!"); return; }
		}
	}

	public void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player" && !finished) {
			finished = true;
			finishMenu.pauseGame();

			if(PlayerPrefs.HasKey(Application.loadedLevelName))
			   saveHighscore();
			else
				PlayerPrefs.SetFloat(Application.loadedLevelName, player.timeAlive);

			audio.PlayOneShot(exitSound);
		}
	}

	private void saveHighscore(){

		string levelName;
		string[] nameParts;

		levelName = Application.loadedLevelName;
		nameParts = levelName.Split ('_');
		nameParts [1] = int.Parse (nameParts [1]).ToString();
		levelName = nameParts [0] + nameParts [1];
		Debug.Log ("Saving Highscore with levelName: "+ levelName);

		if (player.timeAlive < PlayerPrefs.GetFloat (Application.loadedLevelName)) {
			PlayerPrefs.SetFloat (Application.loadedLevelName, player.timeAlive);
			StartCoroutine(PostScore("anon", levelName, player.timeAlive));
		}

	}

	IEnumerator GetScore(string level)
	{
		Score = "";
		
		WindowTitel = "Loading";
		
		WWWForm form = new WWWForm();
		form.AddField("limit",getLimitScore);
		form.AddField("level",level);
		
		WWW www = new WWW(GetHighscoreUrl,form);
		yield return www;
		
		if(www.text == "") 
		{
			print("There was an error getting the high score: " + www.error);
			WindowTitel = "There was an error getting the high score";
		}
		else 
		{
			WindowTitel = "Done";
			Score = www.text;
		}
	}
	
	IEnumerator PostScore(string name, string level, float score)
	{
		string _name = name;
		string _level = level;
		float _score = score;
		
		
		string hash = Md5Sum(_name + _level + _score + secretKey).ToLower();
		
		WWWForm form = new WWWForm();
		form.AddField("name",_name);
		form.AddField("level",_level);
		form.AddField("score",_score.ToString());
		form.AddField("hash",hash);


		Debug.Log ("Sending Highscore: " + _name + " " + _level + " " + _score.ToString() + " " + hash);


		WWW www = new WWW(PostScoreUrl,form);
		WindowTitel = "Wait";
		yield return www;
		
		if(www.text == "done") 
		{

		}
		else 
		{
			print("There was an error posting the high score: " + www.error);
			WindowTitel = "There was an error posting the high score";
		}
	}
	
	
	public string Md5Sum(string input)
	{
		System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
		byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
		byte[] hash = md5.ComputeHash(inputBytes);
		
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < hash.Length; i++)
		{
			sb.Append(hash[i].ToString("X2"));
		}
		return sb.ToString();
	}

}





	


	

