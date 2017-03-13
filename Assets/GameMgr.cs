using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {

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
		State = GameState.TITLE_MENUS;
	}

	public bool AdvanceState() {
		if (State == GameState.INVALID || State == GameState.NONE) {
			Debug.LogError ("Attempted to advance game state while current state was " + State);
			return false;
		} else if (State == GameState.GAME_OVER) {
			return false;
		}


		//state transition logic goes here


		//temporary
		Debug.LogError("Reached incomplete section of GameMgr.AdvanceState()");
		return false;
	}
}
