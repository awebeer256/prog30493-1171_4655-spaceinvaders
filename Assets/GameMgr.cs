﻿using System.Collections;
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

}
