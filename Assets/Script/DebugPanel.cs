using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Attached to the debug panel; drives its behaviour.
/// </summary>
public class DebugPanel : MonoBehaviour {

	public Text timeDisp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PanelUpdate ();
	}

	private void PanelUpdate() {
		timeDisp.text = string.Format ("{0:N2}", Time.time);
	}
}
