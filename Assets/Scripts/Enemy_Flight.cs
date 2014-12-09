using UnityEngine;
using System.Collections;

public class Enemy_Flight : MonoBehaviour {

	public float maxSpeed = 5f;
	public float flap;

	void Awake() {
		flap = rigidbody2D.position.y;
		}
	void FixedUpdate () {



				if (rigidbody2D.position.y < flap)
			rigidbody2D.AddForce (new Vector2 (0f,210f));
		if (Mathf.Abs (rigidbody2D.velocity.y) > maxSpeed)
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Mathf.Sign(rigidbody2D.velocity.y) * maxSpeed);
		
		
		
		}
						

}
