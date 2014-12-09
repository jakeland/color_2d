using UnityEngine;
using System.Collections;


public class RollControl : MonoBehaviour
{
	
	
	
	public Transform speedster;
	[HideInInspector]
	public bool facingRight = true; //right if true, left if false;
	[HideInInspector]
	public bool jump = false;
	public bool notSpinning = false;


	public float moveForce = 365f;
	public float maxSpeed = 8f;
	public float jumpForce = 400f;

	
	[HideInInspector]
	public float tempx = 0f; //holds the x value of the player for rolling
	[HideInInspector]
	public float tempy = 0f; //holds the y value of the plaeyr for rolling
	
	private Transform spinGroundCheck;
	private bool grounded = false;
	private Animator anim;
	
	
	void Awake ()
	{
		spinGroundCheck = transform.Find("spinGroundCheck");
		//anim = GetComponenet<Animator>();


	}
	
	void Update ()
	{
		grounded = Physics2D.Linecast(transform.position, spinGroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		
		if(Input.GetButtonDown("Jump") && grounded)
			jump = true;
		if (Input.GetButtonDown("Fire1"))
			notSpinning = true;
		if(jump)
		{
			
			//anim.SetTrigger("Jump");
			
			
			//int i = Random.Range(0, jumpClips.Length);
			//AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);
			
			
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			
			jump = false;
			
			
			
		}
		
		if (notSpinning) {
			tempx = rigidbody2D.position.x;
			tempy = rigidbody2D.position.y;
			stopSpin(tempx, tempy);
			
		}

		
	}
	
	void FixedUpdate ()
	{
		
		
		float h = Input.GetAxis("Horizontal");
		
		//anim.SetFloat("Speed", Mathf.Abs(h));
		
		
		
		if(h * rigidbody2D.velocity.x < maxSpeed)
			
			rigidbody2D.AddForce(Vector2.right * h * moveForce);
		
		if (Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		
		if(h > 0 && !facingRight)
			
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			
			Flip();
		
		

	}
	
	void Flip ()
	{
		
		facingRight = !facingRight;
		
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void stopSpin(float spinx, float spiny){

		Instantiate (speedster, new Vector2 (spinx,spiny), Quaternion.identity);
		Destroy (transform.gameObject);


	}
	
	
	
}