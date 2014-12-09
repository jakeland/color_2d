using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	public float c1 = 0.00f; //numerator of the color fraction.

	public float c2 = 0.00f; //numerator of the color fraction.
	public float c3 = 0.00f; //numerator of the color fraction.

	public float c1d = 4.00f; //denominator of the color fraction.
	public float c2d=  7.00f;
	public float c3d = 10.00f;

	public float c1f = 0.00f;
	public float c2f = 0.00f;
	public float c3f = 0.00f;


	public string recievedT;

	public Transform color1;
	public Transform color2;
	public Transform color3;



	void colorAdd(string passedC)
	{
		if (passedC == "color3") {
						c3++;
						c3f = (c1 / c3d)  * .73f;
			color3.localScale = new Vector3 (c3f,1,1);
						print (c3f);
				}
		if (passedC == "color2"){
						c2++;
						c2f = (c1 / c2d)  * .73f;
						color2.localScale = new Vector3 (c2f,1,1);
						print(c2f);
		}
		if (passedC == "color1")
		{
						c1++;
						c1f = (c1 / c1d) * .73f;
						color1.localScale = new Vector3(c1f,1,1);
						print (c1f);
		}

	}
	void colorRemove()
	{
		c3 = 0;
		c3f = (c1 / c3d)  * .73f;
		color3.localScale = new Vector3 (c3f,1,1);
		c2 =0;
		c2f = (c1 / c2d)  * .73f;
		color2.localScale = new Vector3 (c2f,1,1);
		c2= 0;
		c2f = (c1 / c2d)  * .73f;
		color2.localScale = new Vector3 (c2f,1,1);
	}
}
