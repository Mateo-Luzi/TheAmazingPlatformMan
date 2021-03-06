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
private var maxCameraZoom : float = 70;


private var thisTransform : Transform;
	function Start ()
	{
		thisTransform = transform;
		 standardCameraSize = thisTransform.camera.orthographicSize;
		 
		 for (var child : Transform in transform) {
			     child.transform.localScale *= 4;
			}

	}
	function FixedUpdate ()
	{
		var cameraZoom : float;
	
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
			cameraZoom = Mathf.SmoothDamp(thisTransform.camera.orthographicSize, Mathf.Exp(Mathf.Abs(cameraTarget.transform.rigidbody2D.velocity.x)/35) + standardCameraSize, currentCameraSize, 0.66f);
			if(cameraZoom > maxCameraZoom)
				cameraZoom = maxCameraZoom;
			thisTransform.camera.orthographicSize = cameraZoom;
		}
		 
		if (cameraFollowY){
			smoothTimeY = (velocity.y)/100;		
			thisTransform.position.y = Mathf.SmoothDamp (thisTransform.position.y , cameraTarget.transform.position.y , velocity.y, smoothTimeY);
			if(velocity.y > 0){
				cameraZoom  = Mathf.SmoothDamp(thisTransform.camera.orthographicSize, Mathf.Exp(Mathf.Abs(cameraTarget.transform.rigidbody2D.velocity.y)/26) + standardCameraSize, currentCameraSize, 1.25f);
				if(cameraZoom > maxCameraZoom)
					cameraZoom = maxCameraZoom;
				thisTransform.camera.orthographicSize = cameraZoom;
			}
			else{
				cameraZoom = Mathf.SmoothDamp(thisTransform.camera.orthographicSize, Mathf.Exp(Mathf.Abs(cameraTarget.transform.rigidbody2D.velocity.y)/26) + standardCameraSize, currentCameraSize, 0.75f);
				if(cameraZoom > maxCameraZoom)
					cameraZoom = maxCameraZoom;
				thisTransform.camera.orthographicSize = cameraZoom;
			}
		}
		
		if (!cameraFollowX && cameraFollowHeight)
		{
			
			camera.transform.position.y = cameraHeight;
		}
		
		
	}
