using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {
	public Transform drop;

	public float x;
		public float y;
	public float z;
	// Use this for initialization



	void Die (){
		x = rigidbody2D.position.x;
		y = rigidbody2D.position.y;

		Instantiate (drop, new Vector2 (x, y), Quaternion.identity);
		Destroy (transform.gameObject);

		}

}
