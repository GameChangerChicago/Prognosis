using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip winning;
	public float fadeTime;
	public AudioSource audioSource, sourceWinning;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
	
		gameManager = FindObjectOfType<GameManager> ();
		//audioSource = this.GetComponent<AudioSource> ();

	}
	
	void Update() {

		if (gameManager.winning) {
			gameManager.winning = !gameManager.winning;
			sourceWinning.PlayOneShot(winning, .7f);
			StartCoroutine(FadeSoundOut(audioSource));

			StartCoroutine(FadeSoundIn(audioSource));
		}
	}

	IEnumerator FadeSoundOut(AudioSource audio){
		float t = fadeTime;


		while (t > 0) {
			yield return null;
			t -= Time.deltaTime;
			audio.volume = (t / fadeTime);
		}yield return new WaitForSeconds (5);

		//yield return new WaitForSeconds(2f);
	}

	IEnumerator FadeSoundIn(AudioSource audio){
		float t = 0f;

		while (t < fadeTime) {
			yield return null;

			t+=Time.deltaTime;

			audio.volume = t/fadeTime;
		}yield return new WaitForSeconds (5);

		//yield return new WaitForSeconds (2f);

	}
}
