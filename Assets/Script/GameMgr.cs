using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Adam: I feel that having separate "manager" classes (e.g. ScoreManager, UIManager, etc.) is more trouble than it's
/// worth, so for now, I'd like to try doing everything in this one class.
/// </summary>
public class GameMgr : MonoBehaviour {

	private int playerScore;
	
	private UIMgr uiMgr;
	
	public Text scoreText;

	public void AddToScore(int score){
		playerScore += score;
	}

	void Awake(){
		playerScore = 0;
	}

	void Update(){
		scoreText.text = "SCORE: " + playerScore;
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
		uiMgr = GetComponent<UIMgr> ();
		if (uiMgr == null)
			Debug.LogError ("GameMgr couldn't find UIMgr.");
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
				Time.timeScale = 0;
				uiMgr.GoToTitle ();
				state = GameState.TITLE_MENUS;
				break;
			}
		case GameState.TITLE_MENUS:
			{
				Time.timeScale = 1;
				uiMgr.GoToInGame ();
				state = GameState.IN_GAME;
				break;
			}
		case GameState.IN_GAME:
			{
				Time.timeScale = 0;
				uiMgr.GoToGameOver ();
				state = GameState.GAME_OVER;
				break;
			}
		default:
			{
				Debug.LogError ("GameMgr.AdvanceState() encountered unhandled current state: " + State);
				break;
			}
		}
	}

	public void GoToLevel(int level) {
		if (State != GameState.TITLE_MENUS) {
			Debug.LogError ("Attempted to load a level from somewhere other than the title menus.");
			return;
		}

		AdvanceState ();
		//TODO load a particular level
	}
}
