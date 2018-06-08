using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SelectPlayer : MonoBehaviour {

    public bool ActiveCharacter;
	private AnimationManager animationManager;
	private GameObject ConfirmSelectionMenu, ConfirmSelectionMenuText;
	private PlayerManager playerManager;
	private AudioSource audioSource;

	// Use this for initialization
	void Awake(){
		animationManager = FindObjectOfType<AnimationManager> ();
		playerManager = FindObjectOfType<PlayerManager> ();
		ConfirmSelectionMenu = GameObject.Find ("ConfirmSelectionMenu");
		playerManager.AddPlayers(this.gameObject);
		ConfirmSelectionMenuText = GameObject.Find ("ConfirmSelectionMenuText");
		audioSource = this.GetComponent<AudioSource> ();
	}


	void Start () {
	

		ConfirmSelectionMenu.SetActive (false);

	}
	


	void OnMouseOver(){

		animationManager.CoroutineWrapper(this.gameObject, "SelectPlayer");

	}

	void OnMouseExit(){
		animationManager.CoroutineWrapper (this.gameObject, "DeselectPlayer");
	}

	void OnMouseDown(){
        if(ActiveCharacter)
        {
            audioSource.Play();
            playerManager.SetPlayer(this.name);
            ConfirmSelectionMenuText.GetComponent<Text>().text = "Are you sure you want to play as "
                + this.name + "?";

            foreach (GameObject ojb in playerManager.playerCharacters)
                ojb.GetComponent<BoxCollider2D>().enabled = false;

            ConfirmSelectionMenu.SetActive(true);
        }
	}
}
