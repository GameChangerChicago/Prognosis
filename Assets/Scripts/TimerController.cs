using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerController : MonoBehaviour
{
    public BoxCollider2D FastForward,
                         PausePlay;
    public float Timer,
                 TimeLimit;
    public bool TimerActive;
	public Image clockRenderer;
	public Text  timerText;

    private GameManager _gameManager;
    public SpriteRenderer _pauseRenderer, playRenderer;
	private int countDownTimer;


    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
		//playRenderer.enabled = false;
       // _pauseRenderer = PausePlay.GetComponentInChildren<SpriteRenderer>();
		//playRenderer = PausePlay.GetComponentInChildren<SpriteRenderer> ();

    }

    void Update()
    {
        if (TimerActive)
        {
            Timer += Time.deltaTime;
			clockRenderer.fillAmount = 1 - Timer / TimeLimit;
			//countDownTimer = Mathf.CeilToInt(TimeLimit - Timer);
			//timerText.text = countDownTimer.ToString();

			timerText.text = (_gameManager.CurrentTurn + 1).ToString();
        }

        if (Timer > TimeLimit)
        {
            _gameManager.CurrentTurn++;
            Timer = 0;
        }
    }

    public void ToggglePauseTimer()
    {
        if (TimerActive)
        {
            playRenderer.enabled = true;
            _pauseRenderer.enabled = false;
        }
        else
        {
            playRenderer.enabled = false;
            _pauseRenderer.enabled = true;
        }

        TimerActive = !TimerActive;
    }

    public void SkipToNextDay()
    {
        _gameManager.CurrentTurn++;
        Timer = 0;
    }
}