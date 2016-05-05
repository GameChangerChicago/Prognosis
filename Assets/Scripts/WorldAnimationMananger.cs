using UnityEngine;
using System.Collections;

public class WorldAnimationMananger : MonoBehaviour {

	public GameObject motionBlur;

	void OnAwake(){

		StartCoroutine("MotionBlur");
	}

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator MotionBlur(){

		motionBlur.GetComponent<Animator> ().Play("Fade In");
		yield return new WaitForSeconds (3);
		motionBlur.GetComponent<Animator>().Play("Fade Out");
		yield return new WaitForSeconds (1);
		motionBlur.SetActive (false);

	}
}
