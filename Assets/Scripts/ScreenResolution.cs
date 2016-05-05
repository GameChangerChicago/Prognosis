using UnityEngine;
using System.Collections;

public class ScreenResolution : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		Screen.SetResolution (Screen.currentResolution.width, Screen.currentResolution.height, false);

	}
	
	// Update is called once per frame
	void Update () {

		
	
	}
}
