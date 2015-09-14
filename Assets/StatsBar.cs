using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsBar : MonoBehaviour {

	public Image stiRateBar, teenPregRateBar, commhealthBar;
	private float changeOverTime = 5.0f;
	private TargetLocation location;
	private TimerController timer;


	// Use this for initialization
	void Start () {
	
		location = this.GetComponent<TargetLocation> ();
		timer = FindObjectOfType<TimerController> ();
		stiRateBar.fillAmount = location.STIRate / 100f;
		teenPregRateBar.fillAmount = location.TeenPregRate / 100f;
		commhealthBar.fillAmount = location.CommunityHealth/ 100f;
	}
	
	// Update is called once per frame
	void Update () {

		if (stiRateBar.fillAmount < (location.STIRate/100f))
				stiRateBar.fillAmount += changeOverTime/ timer.TimeLimit* Time.deltaTime ;
		if (stiRateBar.fillAmount > (location.STIRate / 100f))
			stiRateBar.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;


		if (teenPregRateBar.fillAmount < (location.TeenPregRate/ 100f))
			teenPregRateBar.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
		if (teenPregRateBar.fillAmount > (location.TeenPregRate / 100f))
			teenPregRateBar.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;



		if (commhealthBar.fillAmount < (location.CommunityHealth / 100f))
			commhealthBar.fillAmount += changeOverTime / timer.TimeLimit * Time.deltaTime;
		if (commhealthBar.fillAmount > (location.CommunityHealth / 100f))
			commhealthBar.fillAmount -= changeOverTime / timer.TimeLimit * Time.deltaTime;

		   
	}
}
