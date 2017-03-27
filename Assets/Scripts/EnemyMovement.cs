using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public GameObject Enemy; //enemy to hold the script
	public float movementSpeed; //speed at which the enemies move
	private  Transform currentPoint; //current point enemy is at
	public Transform[] movementPoints; //array to hold two points that enemies will move between
	public int pointSelection; //used to change the points enemies will move too

	void EnemyMovementUpdate(){

		Enemy.transform.position = Vector3.MoveTowards (Enemy.transform.position, currentPoint.transform.position, Time.deltaTime * movementSpeed);

		if (Enemy.transform.position == currentPoint.position) {
			pointSelection++;
			if (pointSelection == movementPoints.Length) {
				pointSelection = 0;
			}

			currentPoint = movementPoints [pointSelection];
		}
	}

	// Use this for initialization
	void Start () {
		currentPoint = movementPoints[pointSelection];
	}
	
	// Update is called once per frame
	void Update () {
		EnemyMovementUpdate ();
	}
}
