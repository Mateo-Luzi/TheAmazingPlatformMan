using UnityEngine;
using System.Collections;

public class OnlineHighScore : MonoBehaviour {

	public AudioClip selection;

	private bool showList = false;
	private int listEntry = 0;
	private GUIContent[] list;
	public GUIStyle listStyle;
	public GUIStyle labelStyle;
	public GUIStyle buttonStyle;
	public GUIStyle boxStyle;
	public GUIStyle windowStyle;
	private bool picked = true;

	public int popupListHash = "PopupList".GetHashCode();
	public string levelName;

	public string GetHighscoreUrl = "http://www.tapm.cwsurf.de/getHighscore.php";

	public string score = "Score";
	public string windowTitel = "";

	public Rect windowRect;
	public float windowWidth = 600;
	public float windowHeight = 300;

	// Use this for initialization
	void Start () {
		list = new GUIContent[9];

		for(int i = 0; i < list.Length; i++)
			list [i] = new GUIContent ("Level " + (i+1));

		listStyle.normal.textColor = Color.white;
		Texture2D tex = Texture2D.whiteTexture;

		tex.Apply();
		listStyle.hover.background = tex;
		listStyle.onHover.background = tex;
		listStyle.padding.left = listStyle.padding.right = 4;
		listStyle.padding.top = listStyle.padding.bottom = 4;


		windowRect = new Rect (300, 200, windowWidth, windowHeight);
		StartCoroutine (GetScore ("level1",15));
	}

	void OnGUI(){
		if (List (new Rect (Screen.width / 8 - 50, 120, 175, 60), ref showList, ref listEntry, 
		               new GUIContent ("Click!"), list, buttonStyle, boxStyle, listStyle)) {
						picked = true;
				}
		if (picked) {
			GUI.Label(new Rect(Screen.width / 2 - 100,120,250,20), list[listEntry].text, labelStyle);

		}

		windowRect = GUI.Window(0, windowRect, DoMyWindow, windowTitel, windowStyle);

	}


	// Update is called once per frame
	void Update () {
		windowRect = new Rect (Screen.width / 2 - 200, 175, windowWidth, Screen.height - 320);
		windowHeight = Screen.height - 100;
	}

	public IEnumerator GetScore(string level, int limit)
	{
		WWWForm form = new WWWForm();
		form.AddField("limit",limit);
		form.AddField("level",level);

		WWW www = new WWW(GetHighscoreUrl,form);
		yield return www;
		
		if (www.text == "") {
			score = "No Scores yet or no internet connection";
			print ("There was an error getting the high score: " + www.error);
		}
		else {
			score = www.text;
		}
	}

	void DoMyWindow(int windowID) 
	{
		GUI.Label (new Rect (windowWidth / 2 - windowWidth / 2, 30, windowWidth, windowHeight), score, windowStyle);      
	}

	public void BackToMainMenu(){
		audio.PlayOneShot (selection);
		//delay method call for changing scene so audio clip finishes playing
		Invoke ("ChangeToMainMenu", 0.2f);
	}
	
	public void ChangeToMainMenu(){
		Application.LoadLevel("mainMenu");
	}


	
	private bool List (Rect position, ref bool showList, ref int listEntry, GUIContent buttonContent, GUIContent[] listContent,
	                         GUIStyle listStyle) {
		return List(position, ref showList, ref listEntry, buttonContent, listContent, "button", "box", listStyle);
	}
	
	private bool List (Rect position, ref bool showList, ref int listEntry, GUIContent buttonContent, GUIContent[] listContent,
	                         GUIStyle buttonStyle, GUIStyle boxStyle, GUIStyle listStyle) {
		int controlID = GUIUtility.GetControlID(popupListHash, FocusType.Passive);
		bool done = false;
		switch (Event.current.GetTypeForControl(controlID)) {
		case EventType.mouseDown:
			if (position.Contains(Event.current.mousePosition)) {
				GUIUtility.hotControl = controlID;
				showList = true;
			}
			break;
		case EventType.mouseUp:
			if (showList) {
				done = true;
			}
			break;
		}
		
		GUI.Label(position, buttonContent, buttonStyle);
		if (showList) {
			Rect listRect = new Rect(position.x, position.y, position.width, listStyle.CalcHeight(listContent[0], 1.0f)*listContent.Length);
			GUI.Box(listRect, "", boxStyle);
			listEntry = GUI.SelectionGrid(listRect, listEntry, listContent, 1, listStyle);
		}
		if (done) {
			showList = false;
			levelName = listContent[listEntry].text;
			//convert levelName to string that matches database table name
			StartCoroutine (GetScore(levelName.ToLower().Replace(" ", ""), 15));
		}
		return done;
	}
}
