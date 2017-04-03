using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCControl : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		if (anim == null)
			Debug.LogError (string.Format("{0}: couldn't find an Animator", this.GetType ().ToString ()));
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
	}
}
