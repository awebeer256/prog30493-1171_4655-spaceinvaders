﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Adam: I feel that having separate "manager" classes (e.g. ScoreManager, UIManager, etc.) is more trouble than it's
/// worth, so for now, I'd like to try doing everything in this one class.
/// </summary>
public class GameMgr : MonoBehaviour {

	public static int playerScore;
	Text scoreText;

	void Awake(){
		scoreText = GetComponent<Text> ();
		playerScore = 0;
	}

	void Update(){
		scoreText.text = "Score: " + playerScore;
	}

	public enum GameState {
		INVALID = -1,
		NONE = 0,

		TITLE_MENUS,
		IN_GAME,
		GAME_OVER
	}

	private GameState state;
	public GameState State {
		private set { state = value; }
		get { return state; }
	}

	void Start() {
		AdvanceState ();
	}

	/// <summary>
	/// Advances game to the next state, handling the associated transitions.
	/// </summary>
	/// <returns><c>true</c>, if state was advanced, <c>false</c> otherwise.</returns>
	public bool AdvanceState() { //Not sure whether we need a return value, but it's there in case
		switch (State) {
		case GameState.INVALID:
			{
				Debug.LogError ("Attempted to advance game state while current state was " + State);
				return false;
			}
		case GameState.GAME_OVER:
		case GameState.NONE:
			{
				//TODO show the title screen
				return false; //switch to true once this is implemented
			}
		case GameState.TITLE_MENUS:
			{
				//TODO show main game screen in game-start configuration
				return false; //switch to true once this is implemented
			}
		case GameState.IN_GAME:
			{
				//TODO show game-over screen
				return false; //switch to true once this is implemented
			}
		default:
			{
				Debug.LogError ("GameMgr.AdvanceState() encountered unhandled current state: " + State);
				return false;
			}
		}
	}
}
