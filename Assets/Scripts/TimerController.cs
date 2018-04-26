using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerController : MonoBehaviour
{
    public BoxCollider2D FastForward,
                         PausePlay;
    public GameObject PPButtonHighlight,
                      FFButtonHighlight;
    public float Timer,
                 TimeLimit;
    public bool TimerActive;
    private bool warningGiven = false;
	public Image clockRenderer;
	public Text  timerText;

    private GameManager _gameManager;
    private AudioManager _audioManager;
    public SpriteRenderer _pauseRenderer, playRenderer;
	private int countDownTimer;


    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _audioManager = AudioManager.instance;
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

        //if there are less than ten seconds left & a warning hasn't been given
        if (Timer > (TimeLimit - 10) && !warningGiven)
        {
            _audioManager.PlaySound("Time Warning");
            warningGiven = true;
        }

        if (Timer > TimeLimit)
        {
            _gameManager.CurrentTurn++;
            Timer = 0;
            warningGiven = false;
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
        warningGiven = false;
    }
    
    public void HighlightPausePlayOn()
    {
        PPButtonHighlight.SetActive(true);
    }

    public void HighlightFastForwardOn()
    {
        FFButtonHighlight.SetActive(true);
    }

    public void HighlightPausePlayOff()
    {
        PPButtonHighlight.SetActive(false);
    }

    public void HighlightFastForwardOff()
    {
        FFButtonHighlight.SetActive(false);
    }
}