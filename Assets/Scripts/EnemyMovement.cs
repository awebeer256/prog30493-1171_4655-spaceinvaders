using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public int dir = 1; //changes direction of enemies
	private int movementSpeed = 2; //controls the speed of the enemies 


	void EnemyMovementUpdate(){

		transform.Translate (Vector3.right * dir * movementSpeed * Time.deltaTime);

		if (transform.position.x >= 3.5) {
			dir = -1;
			//transform.position.y = transform.position.y - 1;
		} else if (transform.position.x <= -3.5) {
			dir = 1;
			//transform.position.y = transform.position.y - 1;
		}
	}

	// Use this for initialization
	void Start () {
		//currentPoint = movementPoints[pointSelection];
	}
	
	// Update is called once per frame
	void Update () {
		EnemyMovementUpdate ();
	}
}
