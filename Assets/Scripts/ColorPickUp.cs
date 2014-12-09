using UnityEngine;
using System.Collections;

public class ColorPickUp : MonoBehaviour {

	public string passedT;
	public bool passedBool;
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
						passedT = gameObject.tag;
						passedBool = true;
						GameObject.FindGameObjectWithTag ("UI").SendMessage ("colorAdd", passedT);

						Destroy (transform.gameObject);

				}

	}
}
