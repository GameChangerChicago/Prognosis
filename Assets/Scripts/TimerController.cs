using UnityEngine;
using System.Collections;

public class TimerController : MonoBehaviour
{
    public BoxCollider2D FastForward,
                         PausePlay;
    public float Timer,
                 TimeLimit;
    public bool TimerActive;

    private GameManager _gameManager;
    private SpriteRenderer _pauseRenderer;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _pauseRenderer = PausePlay.GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (TimerActive)
        {
            Timer += Time.deltaTime;
        }

        if (Timer > TimeLimit)
        {
            _gameManager.CurrentTurn++;
            Timer = 0;
        }

        if (FastForward.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) && Input.GetKeyUp(KeyCode.Mouse0))
        {
            _gameManager.CurrentTurn++;
            Timer = 0;
        }

        if (PausePlay.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) && Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (TimerActive)
            {
                _pauseRenderer.enabled = false;
            }
            else
            {
                _pauseRenderer.enabled = true;
            }

            TimerActive = !TimerActive;
        }
    }
}