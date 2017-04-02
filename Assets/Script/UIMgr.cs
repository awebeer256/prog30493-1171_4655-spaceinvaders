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
		InGame
	};

	public List<isaUIPanel> panels;
	public eUIMgrState state;
	private eUIMgrState prevState;




	// Use this for initialization
	void Start () {
		
	}

	public void UIMgrUpdate()
	{
		prevState = state;
	}
	
	// Update is called once per frame
	void Update () {

		UIMgrUpdate ();
	}
}
