using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayInstructions : MonoBehaviour {

	public GameObject[] instructionList;
	public Button nextButton, previousButton;
	//private RectTransform content;

	private int currentIndex, previousIndex;



	void Awake(){

		//this.GetComponent<ScrollRect>().content = this.GetComponent<ScrollRect> ().content;

		currentIndex = previousIndex = 0;
		foreach (GameObject g in instructionList)
			g.SetActive (false);

		instructionList[currentIndex].SetActive(true);
	}
	// Use this for initialization
	void Start () {
	






	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void showInstructions(int i){

		this.GetComponent<ScrollRect>().content = instructionList [i].GetComponent<RectTransform>();
		instructionList [i].SetActive (true);
		instructionList [previousIndex].SetActive (false);

	}

	public void showNext(){

		previousIndex = currentIndex;

		if (currentIndex >= (instructionList.Length - 1)) {

			currentIndex = instructionList.Length - 1;
			nextButton.interactable = false;

		} else {

			if(nextButton.interactable == false)
				nextButton.interactable = true;

			currentIndex++;
			showInstructions(currentIndex);
		}
	}

	public void showPrevious(){

		previousIndex = currentIndex;

		if (currentIndex <= 0) {

			currentIndex = 0;
			previousButton.interactable = false;
		}
		else {
			if(previousButton.interactable == false)
				previousButton.interactable = true;

			currentIndex--;
			showInstructions (currentIndex);
		}

	}



	}

