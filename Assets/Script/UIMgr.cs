using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System.Web.UI.WebControls;

public class UIMgr : MonoBehaviour {

	public enum eUIMgrState
	{
		Invalid = -1,
		None = 0,
		TitleScreen,
		LevelSelect,
		HighScore,
		InGame,
		GameOver
	};

	public List<IsAUIPanel> panels;
	public eUIMgrState state;

	// Use this for initialization
	void Start () {
		
	}

	public void ShowCurrentPanel() 
	{
		foreach (IsAUIPanel iap in panels) 
		{
			if (iap.state == state) {
				iap.gameObject.SetActive (true);
			} else {
				iap.gameObject.SetActive (false);
			}

		}
	}

	private void GoTo(eUIMgrState destState) {
		state = destState;
		ShowCurrentPanel ();
	}

	public void GoToTitle() {
		GoTo (eUIMgrState.TitleScreen);
	}

	public void GoToLevelSelect() {
		GoTo (eUIMgrState.LevelSelect);
	}

	public void GoToHighScore() {
		GoTo (eUIMgrState.HighScore);
	}

	public void GoToInGame() {
		GoTo (eUIMgrState.InGame);
	}

	public void GoToGameOver() {
		GoTo (eUIMgrState.GameOver);
	}
}