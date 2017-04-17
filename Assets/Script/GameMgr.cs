using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adam: I feel that having separate "manager" classes (e.g. ScoreManager, UIManager, etc.) is more trouble than it's
/// worth, so for now, I'd like to try doing everything in this one class.
/// </summary>
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
	/// Advances game to the next state, handling the associated transitions.
	/// </summary>
	public void AdvanceState() { //Removed bool return so it could be bound to button click
		switch (State) {
		case GameState.INVALID:
			{
				Debug.LogError ("Attempted to advance game state while current state was " + State);
				break;
			}
		case GameState.GAME_OVER:
		case GameState.NONE:
			{
				//TODO show the title screen
				break;
			}
		case GameState.TITLE_MENUS:
			{
				//TODO show main game screen in game-start configuration
				break;
			}
		case GameState.IN_GAME:
			{
				//TODO show game-over screen
				break;
			}
		default:
			{
				Debug.LogError ("GameMgr.AdvanceState() encountered unhandled current state: " + State);
				break;
			}
		}
	}
}
