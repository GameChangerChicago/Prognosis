using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour
{

	public GameObject motionBlur, mainMenuScreen,
		creditText, creditScreen, newGameButton, creditButton, howToPlayButton, 
		creditsBackButton, selectScreen;
	private GameObject selectPlayerOption;



	// Use this for initialization



	private IEnumerator rollCredits ()
	{

		motionBlur.GetComponent<Animator> ().Play ("FadeIn");
		yield return new WaitForSeconds (1);
		MenuScreenActive (false);
		CreditScreenActive (true);
		motionBlur.GetComponent<Animator> ().Play ("FadeOut");
		creditText.GetComponent<Animator> ().Play ("RollCredits", -1, 0.0f);
		yield return new WaitForSeconds (32);
		motionBlur.GetComponent<Animator> ().Play ("FadeIn");
		yield return new WaitForSeconds (1);
		MenuScreenActive (true);
		CreditScreenActive (false);
		motionBlur.GetComponent<Animator> ().Play ("FadeOut");

	}

	public IEnumerator playerSelectionScreen ()
	{
		
		motionBlur.GetComponent<Animator> ().Play ("FadeIn");
		yield return new WaitForSeconds (1);
		MenuScreenActive (false);
		creditsBackButton.SetActive (false);
		creditScreen.SetActive (true);
		selectScreen.SetActive (true);
		motionBlur.GetComponent<Animator> ().Play ("FadeOut");
		yield return new WaitForSeconds (1);
		motionBlur.GetComponent<Animator> ().Play ("FadeOut");

		
		
	}
	
	public void CoroutineWrapper (string name)
	{
		StartCoroutine (name);
	}

	public void CoroutineWrapper (GameObject obj, string coroutineName)
	{
		selectPlayerOption = obj;
		StartCoroutine (coroutineName);

	}

	public IEnumerator SelectPlayer ()
	{

		selectPlayerOption.GetComponent<Animator> ().Play ("SelectBoxExpand");
		yield return new WaitForSeconds (1);
	}

	public IEnumerator DeselectPlayer ()
	{
		selectPlayerOption.GetComponent<Animator> ().Play ("SelectBoxShrink");
		yield return new WaitForSeconds (1);
	}

	public void MenuScreenActive (bool b)
	{

		mainMenuScreen.SetActive (b);
		creditButton.SetActive (b);
		creditsBackButton.SetActive (!b);
		howToPlayButton.SetActive (b);
		newGameButton.SetActive (b);

	}

	public void CreditScreenActive (bool b)
	{
		creditScreen.SetActive (b);
		creditText.SetActive (b);

	}








}
