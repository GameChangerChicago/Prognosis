using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetLocation : MonoBehaviour
{
    public GameObject TargetMenu;
    public BoxCollider2D LockRecallButton;
    public float STIRate,
                 TeenPregRate,
                 CommunityHealth;
    public bool Locked;

    public bool Active
    {
        get
        {
            return _active;
        }

        set
        {
            if (_active != value)
            {
                if (value)
                {
                    TargetMenu.SetActive(value);
                    PM.Active = true;
                }
                else
                {
                    TargetMenu.SetActive(value);
                }

                _active = value;
            }
        }
    }
    private bool _active;

    private List<TargetLocation> _otherTargetLocs = new List<TargetLocation>();
    private ProfessionalSlot[] proSlots;
    private ProfessionalsMenu PM;
    private GameManager _gameManager;
    private int _currentTurn;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        PM = FindObjectOfType<ProfessionalsMenu>();
        _otherTargetLocs.AddRange(FindObjectsOfType<TargetLocation>());
        _otherTargetLocs.Remove(this);
    }

    void Update()
    {
        if (LockRecallButton.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Possibly show butten being pressed
        }
        if (LockRecallButton.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) && Input.GetKeyUp(KeyCode.Mouse0) && _currentTurn != _gameManager.CurrentTurn)
        {
            if (!Locked)
                _currentTurn = _gameManager.CurrentTurn;

            Locked = !Locked;
        }
    }

    void OnMouseDown()
    {
        Active = true;
        foreach (TargetLocation tl in _otherTargetLocs)
        {
            tl.Active = false;
        }
    }
}