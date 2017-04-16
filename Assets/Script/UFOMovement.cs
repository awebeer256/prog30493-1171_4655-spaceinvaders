using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMovement : MonoBehaviour {


	public int rot = 1; //changes direction of enemies
	private float movementSpeed = 3.0f; //controls the speed of the enemies

	void UFOMovementUpdate() {

		transform.Translate (Vector3.up * rot * movementSpeed * Time.deltaTime); //moves enemies based on direction and speed of enemies

		if (transform.position.x <= -30) {
			rot = -1;
			transform.Rotate (90, 90, 0);
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		} else if (transform.position.x >= 30) {
			rot = 1;
			transform.Rotate (90, 270, 0);
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		UFOMovementUpdate ();
	}
}
