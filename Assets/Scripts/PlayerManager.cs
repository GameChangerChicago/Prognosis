using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

	public List<GameObject> playerCharacters = new List<GameObject>();
	private string selectedPlayer;
	private GameObject ConfirmSelectionMenuText;

	public void Awake(){

		DontDestroyOnLoad(this.gameObject);
	}

	public void SetPlayer(string name){
		selectedPlayer = name;
	}

	public void AddPlayers(GameObject obj){
		playerCharacters.Add (obj);
	}


}
