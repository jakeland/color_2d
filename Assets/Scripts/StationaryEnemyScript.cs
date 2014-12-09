using UnityEngine;
using System.Collections;

public class StationaryEnemyScript : MonoBehaviour {
	public float waitTime = 1.00f;
	public float attackTime = 0.00f;
	public float totalAttackTime = 2.00f;

	private float sx;

	public Transform Tongue;

	  void Update (){
		if (waitTime > 0){
			waitTime -= Time.deltaTime;
		}
		if(waitTime <= 0){
			attackTime+= Time.deltaTime;
			Attack();
		}
	}

	void Attack(){
		if (attackTime <= totalAttackTime/2)
			Tongue.localPosition = new Vector3 (attackTime/2,0,0);

		if (attackTime > totalAttackTime/2)
			Tongue.localPosition = new Vector3 (totalAttackTime/2 -(attackTime/2), 0, 0);
		
		if ((totalAttackTime - attackTime) <= 0) {
			waitTime = 2.00f;
			attackTime = 0.00f;
		}
		
		
	}
}
