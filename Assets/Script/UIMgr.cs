using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System.Web.UI.WebControls;

public class UIMgr : MonoBehaviour {


	public Canvas quitMenu;
	//public Button playAgain;

	public enum eUIMgrState
	{
		Invalid = -1,
		None = 0,
		TitleScreen,
		LevelSelect,
		InGame,

		FirstState = TitleScreen,
		LastState = InGame
			//NumStates = ((LastState - FirstState) + 1)
	};

	public List<isaUIPanel> panels;
	public eUIMgrState state;
	private eUIMgrState prevState;




	// Use this for initialization
	void Start () {
		
	}

	public void IncState()
	{
		state++;
		if (state > eUIMgrState.LastState) {
			state = eUIMgrState.LastState;
		}

	}

	public void DecState()
	{
		state--;
		if (state < eUIMgrState.FirstState) {
			state = eUIMgrState.FirstState;
		}

	}
	public void ShowCurrentPanel() 
	{
		foreach (isaUIPanel iap in panels) 
		{
			if (iap.state == state) {
				iap.gameObject.SetActive (true);
			} else {
				iap.gameObject.SetActive (false);
			}

		}
	}

	public void QuitGame()
	{

		quitMenu.enabled = false;
		//quitPanel.Enabled = false;
		Time.timeScale = 0;
		//playAgain.enabled = true;
		//Application.Quit ();
	}

	public void ContinueGame()
	{
		quitMenu.enabled = false;
		//SceneManager.LoadScene ("Global");
	}

	public void UIMgrUpdate()
	{
		if (state != prevState)
		{
			ShowCurrentPanel ();
		}

		prevState = state;
	}

	// Update is called once per frame
	void Update () {

		UIMgrUpdate ();
	}
}
