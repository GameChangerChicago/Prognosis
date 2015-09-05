using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {

	public GameObject CreditsSky, CreditCityExtraLarge, CreditTreeMedium_1, 
					  CreditCityMedium_2, MotionBlur, MainMenuScreen, PrognosisTitle, CreditText, CreditScreen;



	// Use this for initialization



	private IEnumerator rollCredits (){


		MotionBlur.SetActive(true);
		MotionBlur.GetComponent<Animator>().Play ("FadeIn");
		yield return new WaitForSeconds(1);
		MainMenuScreen.SetActive (false);
		CreditScreen.SetActive (true);
		MotionBlur.GetComponent<Animator> ().Play ("FadeOut");
		yield return new WaitForSeconds(1);
		//MotionBlur.SetActive (false);
		CreditText.SetActive (true);
		CreditText.GetComponent<Animator> ().Play ("RollCredits");
		yield return new WaitForSeconds(25);
		MotionBlur.GetComponent<Animator> ().Play ("MotionBlurReverse");
		CreditsSky.GetComponent<Animator> ().Play ("MoveLeft");
	}

	
	public void CoroutineWrapper(string name){
		StartCoroutine (name);
	}



}
