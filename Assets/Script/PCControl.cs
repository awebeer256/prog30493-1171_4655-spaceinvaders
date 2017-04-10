using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCControl : MonoBehaviour {

	private Animator anim;
	private static int animStateHashCast; //short name hash of the "Cast" animation state
	private bool hasFired; //set to true when PC fires, false when the transition ends
	public float fireballHeightOffset; //in Unity distance units, from the PC's origin
	public float fireballDelay; //in seconds after the fire button is pressed. Tweak to match animation

	public GameObject fireball;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		if (anim == null)
			Debug.LogError (string.Format("{0}: couldn't find an Animator", this.GetType ().ToString ()));
		animStateHashCast = Animator.StringToHash ("Cast");
		hasFired = false;
	}
	
	void FixedUpdate() {
		HandleInputs ();
	}

	/// <summary>
	/// Updates PC behaviour based on player input.
	/// </summary>
	private void HandleInputs() {
		anim.SetBool ("walkLeft", Input.GetAxisRaw ("Horizontal") < -0.5);
		anim.SetBool ("walkRight", Input.GetAxisRaw ("Horizontal") > 0.5);
		if (Input.GetButton ("Fire3") || Input.GetButton("Fire2"))
			anim.SetTrigger ("Attack");
		else
			anim.ResetTrigger ("Attack");
		
		if (hasFired && !anim.IsInTransition (0)) {
			hasFired = false;
		}
		if (!hasFired && anim.IsInTransition(0) &&
				anim.GetNextAnimatorStateInfo (0).shortNameHash == animStateHashCast) {
			Invoke ("Fire", fireballDelay);
			hasFired = true;
		}
	}

	/// <summary>
	/// Spawns a fireball just above the player
	/// </summary>
	private void Fire() {
		Instantiate (fireball, transform.position + Vector3.up * fireballHeightOffset, Quaternion.identity);
	}
}
