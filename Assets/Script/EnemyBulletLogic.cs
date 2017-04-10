using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLogic : MonoBehaviour {

	/*
	 * This class is designed to destory the enemybullet when it collides with anything
	 * will check to see if bullet hits: shields or Player
	 * if shield - destory whichever cube was hit in the shield
	 * if player - reduce live, respawn player 
	 */

	public GameObject enemyBullet;

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.GetComponent<isAShield> () != null) {
			//destory one block per sheild
		} else if (collision.gameObject.GetComponent<isCharacter> () != null 
			&& collision.gameObject.GetComponent<isPlayerOwned>() != null) {
			//check game manager for player lives,
			//reduce number of lives for player,
			//respawn player in middle of screen 
		}
		Destroy (gameObject); //gameobject is destroyed when it collides with anything 
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
