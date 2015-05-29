using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptPanelSelection : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Image img =  GameObject.Find("MyPanel").GetComponent<Image>();
		img.color = UnityEngine.Color.red;
	
	}
}
