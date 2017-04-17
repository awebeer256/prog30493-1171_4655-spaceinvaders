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
	private GameObject globalgo;
	private int reduceLife = 1;

	// Use this for initialization
	void Start () {
		globalgo = GameObject.Find ("GLOBAL");
		if (globalgo == null)
			Debug.LogError ("Unable to find GLOBAL game object");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.GetComponent<IsAShield> () != null) {
			//destory one block per sheild
		} else if (collision.gameObject.GetComponent<IsACharacter> () != null 
			&& collision.gameObject.GetComponent<IsAPlayerOwned>() != null) {
			//reduce number of lives for player
			//respawn player in middle of screen 
		}
		Destroy (gameObject); //gameobject is destroyed when it collides with anything 
	}
}
