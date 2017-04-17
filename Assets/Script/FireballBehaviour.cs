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

	public void enemyExplosion(string gameObjectName){
		GameObject gm = GameObject.Find(gameObjectName);
		if (gm != null)
		{
			AudioSource asource = gm.GetComponent<AudioSource> ();
			if (asource == null) {
				asource = gm.AddComponent<AudioSource> ();
			}
			asource.Play ();
		}
	}


	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.GetComponent<UFOMovement> () != null) {
			globalgo.GetComponent<GameMgr> ().AddToScore (bigScore);
			Destroy (collision.gameObject);
			//enemyExplosion ();
		} else if (collision.gameObject.GetComponent<IsACharacter> () != null && collision.gameObject.GetComponent<IsAEnemyOwned> () != null) {
			globalgo.GetComponent<GameMgr> ().AddToScore (addScore);
			Destroy (collision.gameObject);
		}
		Destroy (gameObject);
	}
}
