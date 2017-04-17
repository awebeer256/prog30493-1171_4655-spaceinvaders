using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCControl : MonoBehaviour {

	private Vector3 startPos;
	private Quaternion startRot;
	private bool visible; //for flashing
	private Animator anim;
	private Collider coll;
	private SkinnedMeshRenderer[] renderers;
	private static int animStateHashCast; //short name hash of the "Cast" animation state
	private static int animStateHashDeath;
	private bool hasFired; //set to true when PC fires, false when the transition ends

	public float spawnGrace; //invincibility upon respawning
	public float fireballHeightOffset; //in Unity distance units, from the PC's origin
	public float fireballDelay; //in seconds after the fire button is pressed. Tweak to match animation

	public GameObject fireball;

	private enum PlayerState {
		INVALID = -1,
		NONE = 0,
		SPAWNING,
		ALIVE,
		DYING
	}
	private PlayerState state;
	private PlayerState State {
		get { return state; }
		set {
			switch (value) {
			case PlayerState.DYING:
				{
					anim.SetTrigger ("Death");
					coll.enabled = false;
					state = PlayerState.DYING;
					break;
				}
			case PlayerState.SPAWNING:
				{
					transform.position = startPos;
					transform.rotation = startRot;
					Invoke ("EndInvFrames", spawnGrace);
					state = PlayerState.SPAWNING;
					break;
				}
			case PlayerState.ALIVE:
				{
					visible = true;
					UpdateVisibility ();
					coll.enabled = true;
					state = PlayerState.ALIVE;
					break;
				}
			default:
				{
					state = value;
					break;
				}
			}
		}
	}

	private void EndInvFrames() {
		State = PlayerState.ALIVE;
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		if (anim == null)
			Debug.LogError (string.Format("{0}: couldn't find an Animator", this.GetType ().ToString ()));
		coll = GetComponent<CapsuleCollider> ();
		if (coll == null)
			Debug.LogError (string.Format("{0}: couldn't find a Collider", this.GetType ().ToString ()));
		renderers = GetComponentsInChildren<SkinnedMeshRenderer> ();
		animStateHashCast = Animator.StringToHash ("Cast");
		animStateHashDeath = Animator.StringToHash ("Death");
		startPos = transform.position;
		startRot = transform.rotation;
		hasFired = false;
		State = PlayerState.ALIVE;
	}
	
	void FixedUpdate() {
		HandleInputs ();
		ListenForRespawn ();
	}

	void Update() {
		HandleFlashing ();
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

	void OnCollisionEnter(Collision collision) {
		GameObject go = collision.gameObject;
		if (go.GetComponent<IsAProjectile> () != null && go.GetComponent<IsAEnemyOwned> () != null) {
			State = PlayerState.DYING;
		}
	}

	private void HandleFlashing() {
		if (State != PlayerState.SPAWNING)
			return;

		visible = !visible;
		UpdateVisibility ();
	}

	private void ListenForRespawn() {
		if (anim.GetCurrentAnimatorStateInfo (0).shortNameHash == animStateHashDeath &&
		    anim.IsInTransition (0))
			State = PlayerState.SPAWNING;
	}

	private void UpdateVisibility() {
		foreach (SkinnedMeshRenderer r in renderers) {
			r.enabled = visible;
		}
	}
}
