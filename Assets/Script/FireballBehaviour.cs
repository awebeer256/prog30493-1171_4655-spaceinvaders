using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : MonoBehaviour {

	private int addScore = 10;
	private int bigScore = 75;
	private GameObject globalgo;

	// Use this for initialization
	void Start () {
		globalgo = GameObject.Find ("GLOBAL");
		if (globalgo == null)
			Debug.LogError ("Fireball couldn't find GLOBAL.");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.GetComponent<UFOMovement> () != null) {
			globalgo.GetComponent<GameMgr> ().AddToScore (bigScore);
			Destroy (collision.gameObject);
		} else if (collision.gameObject.GetComponent<IsACharacter> () != null && collision.gameObject.GetComponent<IsAEnemyOwned> () != null) {
			globalgo.GetComponent<GameMgr> ().AddToScore (addScore);
			Destroy (collision.gameObject);
		}
		Destroy (gameObject);
	}
}
