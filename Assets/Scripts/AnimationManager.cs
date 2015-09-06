using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {

	public GameObject CreditsSky, CreditCityExtraLarge, CreditTreeMedium_1, 
					  CreditCityMedium_2, MotionBlur, MainMenuScreen, PrognosisTitle,
					  CreditText, CreditScreen, NewGameButton, CreditButton, HowToPlayButton, 
					  CreditsBackButton;
	private GameObject selectPlayerOption;



	// Use this for initialization



	private IEnumerator rollCredits (){

		MotionBlur.GetComponent<Animator>().Play ("FadeIn");
		yield return new WaitForSeconds(1);
		MenuScreenActive (false);
		CreditScreenActive (true);
		MotionBlur.GetComponent<Animator> ().Play ("FadeOut");
		CreditText.GetComponent<Animator> ().Play ("RollCredits", -1, 0.0f);
		yield return new WaitForSeconds(32);
		MotionBlur.GetComponent<Animator> ().Play ("FadeIn");
		yield return new WaitForSeconds (1);
		MenuScreenActive (true);
		CreditScreenActive (false);
		MotionBlur.GetComponent<Animator> ().Play ("FadeOut");

	}

	
	public void CoroutineWrapper(string name){
		StartCoroutine (name);
	}

	public void CoroutineWrapper(GameObject obj, string coroutineName){
		selectPlayerOption = obj;
		StartCoroutine (coroutineName);

	}

	public IEnumerator SelectPlayer(){

		selectPlayerOption.GetComponent<Animator> ().Play("SelectBoxExpand");
		yield return new WaitForSeconds (1);
	}

	public IEnumerator DeselectPlayer(){
		selectPlayerOption.GetComponent<Animator> ().Play ("SelectBoxShrink");
		yield return new WaitForSeconds (1);
	}


	public void MenuScreenActive(bool b){

		MainMenuScreen.SetActive (b);
		CreditButton.SetActive (b);
		CreditsBackButton.SetActive (!b);
		HowToPlayButton.SetActive (b);
		NewGameButton.SetActive (b);

	}

	public void CreditScreenActive(bool b){
		CreditScreen.SetActive (b);
		CreditText.SetActive (b);

	}






}
