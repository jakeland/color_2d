using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true; //right if true, left if false;
	[HideInInspector]
	public bool jump = false;
	
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 400f;
	
	
	private Transform groundCheck;
	private bool grounded = false;
	private Animator anim;
	
	
	void Awake ()
	{
		groundCheck = transform.Find("groundCheck");
		//anim = GetComponenet<Animator>();
	}
	
	void Update ()
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		
		if(Input.GetButtonDown("Jump") && grounded)
			jump = true;
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
		
		
		if(jump)
		{
			
			//anim.SetTrigger("Jump");
			
			
			//int i = Random.Range(0, jumpClips.Length);
			//AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);
			
			
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			
			jump = false;


		
		}
	}
	
	void Flip ()
	{
		
		facingRight = !facingRight;
		
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	
	
}