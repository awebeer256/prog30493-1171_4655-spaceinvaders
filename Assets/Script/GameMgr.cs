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
		AdvanceState ();
	}

	/// <summary>
	/// Shows the title screen
	/// </summary>
	private void SetupGame() {
		
	}

	/// <summary>
	/// Advances game to the next state, handling the associated transitions.
	/// </summary>
	/// <returns><c>true</c>, if state was advanced, <c>false</c> otherwise.</returns>
	public bool AdvanceState() {
		switch (State) {
		case GameState.INVALID:
			{
				Debug.LogError ("Attempted to advance game state while current state was " + State);
				return false;
			}
		case GameState.GAME_OVER || GameState.NONE:
			{
				SetupGame ();
				return true;
			}
		default: //temporary
			{
				Debug.LogError ("Reached incomplete section of GameMgr.AdvanceState()");
				return false;
			}
		}
	}
}
