using UnityEngine;
using System.Collections;

public class SpaceMarineController : MonoBehaviour {

	public static bool facingRight = true;
	public static bool grounded = false;
	public static int platformMode = 1;

	public float move;
	public float maxSpeed;
	public float jumpVelocity;
	
	private float groundRadius = 0.2f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	
	public AudioClip jumpSound;
	public AudioClip switchWeaponSound;



	// Use this for initialization
	void Start () {

	}
	

	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		// make sure character's x-position isnt moved by anything other than the player himself
		if (move == 0 && (rigidbody2D.velocity.x != 0)) 
			rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y);
		
	}
	// Update is called once per frame
	void Update(){
		move = Input.GetAxisRaw("Horizontal");

		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			rigidbody2D.velocity = new Vector2(0,jumpVelocity);
			audio.PlayOneShot(jumpSound);
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			platformMode = 2;
			audio.PlayOneShot (switchWeaponSound);
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			platformMode = 1;
			audio.PlayOneShot (switchWeaponSound);
		}

		
	}

	public void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
