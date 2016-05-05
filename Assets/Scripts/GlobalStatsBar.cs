using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalStatsBar : MonoBehaviour {

	public Image worldTeenPregRate, worldSTIRate, worldCommHealthRate, financeBar, educationBar;
	private GameManager gameManager;
	private float changeOverTime = 5.0f;
	private TimerController timer;


	// Use this for initialization
	void Start () {

		gameManager = this.gameObject.GetComponent<GameManager> ();
		timer = FindObjectOfType <TimerController>();
		worldSTIRate.fillAmount = gameManager.WorldSTIRate / 100f;
		worldTeenPregRate.fillAmount = gameManager.WorldTeenPregRate / 100f;
		worldCommHealthRate.fillAmount = gameManager.WorldCommHealthRate / 100f;
		financeBar.fillAmount = gameManager.Finance / 100f;
		educationBar.fillAmount = gameManager.Education / 100f;

	
	}
	
	// Update is called once per frame
	void Update () {

		if (worldSTIRate.fillAmount < (gameManager.WorldSTIRate/100f))
		worldSTIRate.fillAmount += changeOverTime/ timer.TimeLimit* Time.deltaTime ;
		if (worldSTIRate.fillAmount > (gameManager.WorldSTIRate/100f))
			worldSTIRate.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
		
		
		if (worldCommHealthRate.fillAmount < (gameManager.WorldCommHealthRate/100f))
			worldCommHealthRate.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
		if (worldCommHealthRate.fillAmount > (gameManager.WorldCommHealthRate / 100f))
			worldCommHealthRate.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;

		
		if (worldTeenPregRate.fillAmount < (gameManager.WorldTeenPregRate / 100f))
			worldTeenPregRate.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
		if (worldTeenPregRate.fillAmount > (gameManager.WorldTeenPregRate / 100f))
			worldTeenPregRate.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;

		if (financeBar.fillAmount < (gameManager.Finance / 100f))
			financeBar.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
		if (financeBar.fillAmount > (gameManager.Finance / 100f))
			financeBar.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;

		if (educationBar.fillAmount < (gameManager.Education / 100f))
			educationBar.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
		if (educationBar.fillAmount > (gameManager.Education / 100f))
			educationBar.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;
	
	}
}
