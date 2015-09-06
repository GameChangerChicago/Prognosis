using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SelectPlayer : MonoBehaviour {

	private AnimationManager animationManager;
	private GameObject ConfirmSelectionMenu, ConfirmSelectionMenuText;
	private PlayerManager playerManager;

	// Use this for initialization
	void Awake(){
		animationManager = FindObjectOfType<AnimationManager> ();
		playerManager = FindObjectOfType<PlayerManager> ();
		ConfirmSelectionMenu = GameObject.Find ("ConfirmSelectionMenu");
		playerManager.AddPlayers(this.gameObject);
		ConfirmSelectionMenuText = GameObject.Find ("ConfirmSelectionMenuText");
	}


	void Start () {
	

		ConfirmSelectionMenu.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){

		Debug.Log ("Hovering");
		animationManager.CoroutineWrapper(this.gameObject, "SelectPlayer");

	}

	void OnMouseExit(){
		Debug.Log ("No longer hovering!");
		animationManager.CoroutineWrapper (this.gameObject, "DeselectPlayer");
	}

	void OnMouseDown(){

		Debug.Log ("Are you sure you want to play as " + this.name + "?");
		playerManager.SetPlayer (this.name);

		ConfirmSelectionMenuText.GetComponent<Text>().text =  "Are you sure you want to play as " 
			+ this.name + "?";
		
		foreach (GameObject ojb in playerManager.playerCharacters)
			ojb.GetComponent<BoxCollider2D> ().enabled = false;

		ConfirmSelectionMenu.SetActive (true);
	}
}
