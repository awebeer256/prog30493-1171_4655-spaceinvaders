using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : MonoBehaviour {

	private int addScore = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.GetComponent<IsACharacter> () != null && collision.gameObject.GetComponent<IsAEnemyOwned> () != null) {
			GameMgr.playerScore += addScore;
		}
		Destroy (gameObject);
	}
}
