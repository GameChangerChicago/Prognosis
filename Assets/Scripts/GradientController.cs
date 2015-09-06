using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class GradientController : MonoBehaviour {

	private SpriteRenderer[] spriteGradients;
	public float color; 
	//private Color spriteAlpha.; 


	// Use this for initialization
	void Start () {
	
		spriteGradients = this.GetComponentsInChildren<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {

		 

		foreach (SpriteRenderer sr in spriteGradients) {


			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, color);

		}
	
	}
}
