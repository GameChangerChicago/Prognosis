using UnityEngine;
using System.Collections;

public class SelectPlayer : MonoBehaviour {

	private AnimationManager manager;
	private GameObject ConfirmSelectionMenu;

	// Use this for initialization
	void Awake(){
		manager = FindObjectOfType<AnimationManager> ();
		ConfirmSelectionMenu = GameObject.Find ("ConfirmSelectionMenu");
	}


	void Start () {
	

		ConfirmSelectionMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){

		Debug.Log ("Hovering");
		manager.CoroutineWrapper(this.gameObject, "SelectPlayer");

	}

	void OnMouseExit(){
		Debug.Log ("No longer hovering!");
		manager.CoroutineWrapper (this.gameObject, "DeselectPlayer");
	}

	void OnMouseDown(){

		Debug.Log ("Are you sure you want to play as " + this.name + "?");
		ConfirmSelectionMenu.SetActive (true);
	}
}
