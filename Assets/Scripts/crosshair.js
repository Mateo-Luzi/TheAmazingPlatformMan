#pragma strict
var cursor : Texture2D;
function Start () {
	Screen.showCursor = false;
}

function OnGUI(){
	GUI.DrawTexture(Rect(Input.mousePosition.x - 18,(Screen.height - Input.mousePosition.y) - 19, cursor.width/8, cursor.height/8), cursor);
}
function Update () {
	Screen.showCursor = false;
}