var cameraTarget : GameObject;
var player : GameObject;

var cameraFollowX : boolean = true;
var cameraFollowY : boolean = true;
var cameraFollowHeight : boolean = false;
var cameraHeight : float = 2.5;
var velocity : Vector2;

private var smoothTimeX : float = 0.3;
private var smoothTimeY : float = 0.3;

private var standardCameraSize : float;
private var currentCameraSize : float;


private var thisTransform : Transform;
	function Start ()
	{
		thisTransform = transform;
		 standardCameraSize = thisTransform.camera.orthographicSize;
		 
		 for (var child : Transform in transform) {
			     child.transform.localScale.x = child.transform.localScale.x * 1.4;
			     child.transform.localScale.y = child.transform.localScale.y * 1.4;
			}

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
			thisTransform.camera.orthographicSize = Mathf.SmoothDamp(thisTransform.camera.orthographicSize, Mathf.Exp(Mathf.Abs(cameraTarget.transform.rigidbody2D.velocity.x)/35) + standardCameraSize, currentCameraSize, 0.66f);
		}
		 
		if (cameraFollowY){
			smoothTimeY = (velocity.y)/100;		
			thisTransform.position.y = Mathf.SmoothDamp (thisTransform.position.y , cameraTarget.transform.position.y , velocity.y, smoothTimeY);
			thisTransform.camera.orthographicSize = Mathf.SmoothDamp(thisTransform.camera.orthographicSize, Mathf.Exp(Mathf.Abs(cameraTarget.transform.rigidbody2D.velocity.y)/25) + standardCameraSize, currentCameraSize, 1.5f);
		}
		if (!cameraFollowX && cameraFollowHeight)
		{
			
			camera.transform.position.y = cameraHeight;
		}
		
		
	}
