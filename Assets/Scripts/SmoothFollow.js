var cameraTarget : GameObject;
var player : GameObject;

var cameraFollowX : boolean = true;
var cameraFollowY : boolean = true;
var cameraFollowHeight : boolean = false;
var cameraHeight : float = 2.5;
var velocity : Vector2;

private var smoothTimeX : float = 0.3;
private var smoothTimeY : float = 0.3;


private var thisTransform : Transform;
	function Start ()
	{
		thisTransform = transform;

	}
	function FixedUpdate ()
	{
		if (player == null || cameraTarget == null) {
			try{
				player = GameObject.FindGameObjectWithTag("Player");
				cameraTarget = player;
			}catch(err){
				return;
			}	
		}
	
	
		if (cameraFollowX){

			thisTransform.position.x = Mathf.SmoothDamp (thisTransform.position.x , cameraTarget.transform.position.x, velocity.x, smoothTimeX);
		}
		 
		if (cameraFollowY){
			smoothTimeY = (velocity.y)/100;		
			thisTransform.position.y = Mathf.SmoothDamp (thisTransform.position.y , cameraTarget.transform.position.y , velocity.y, smoothTimeY);
		}
		if (!cameraFollowX && cameraFollowHeight)
		{
			
			camera.transform.position.y = cameraHeight;
		}
		
		
	}
