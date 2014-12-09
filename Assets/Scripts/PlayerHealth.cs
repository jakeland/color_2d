using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public float totalColor;
	public float storedC1;
	public float storedC2;
	public float storedC3;
	public Color alpha = new Color (1f, 1f, 1f, 0f);
	public Color original = new Color (1f, 1f, 1f, 1f);
	public float wait = 1.00f;
	public float tempTime = .2f;

	void Update(){
		if (tempTime < wait)
						tempTime+= Time.deltaTime;
		if (tempTime >= wait)
			transform.gameObject.GetComponent<PlayerControl> ().enabled = true;

		}
	void OnTriggerEnter2D(Collider2D col)


	{
		storedC1 = GameObject.FindGameObjectWithTag ("UI").GetComponent<UI> ().c1;
		storedC2 = GameObject.FindGameObjectWithTag ("UI").GetComponent<UI> ().c2;
		storedC3 = GameObject.FindGameObjectWithTag ("UI").GetComponent<UI> ().c3;

		if (col.gameObject.tag == "Attack") {
						if (storedC1 <= 0 || storedC2 <= 0 || storedC3 <= 0) {
								GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraFollow> ().enabled = false;
								Destroy (transform.gameObject);
						}
						else
						{
						GameObject.FindGameObjectWithTag ("UI").SendMessage ("colorRemove");
						}
				}
		if (col.gameObject.tag == "Enemy") {
						col.gameObject.SendMessage ("Die");
				}

		if (col.gameObject.tag == "Wall") 
				{
			//rigidbody2D.velocity = new Vector2 (0,0);
						transform.gameObject.GetComponent<PlayerControl> ().enabled = false;
			tempTime = 0.00f;
				}
	}




}