using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour {

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
