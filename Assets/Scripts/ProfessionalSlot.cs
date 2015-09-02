using UnityEngine;
using System.Collections;

public class ProfessionalSlot : MonoBehaviour
{
    public Professionals CurrentProfessional
    {
        get
        {
            return currentProfessional;
        }

        set
        {
            switch(value)
            {
                case Professionals.None:
                    //Change portrait
                    break;
                case Professionals.Doctor:
                    //Change portrait
                    break;
                case Professionals.Nurse:
                    //Change portrait
                    break;
                case Professionals.Advocate:
                    //Change portrait
                    break;
                case Professionals.CommOrg:
                    //Change portrait
                    break;
            }

            currentProfessional = value;
        }
    }
    protected Professionals currentProfessional = Professionals.None;
    private GameManager _gameManager;
    private BoxCollider2D _myBoxCollider;
    private SpriteRenderer _mySpriteRenderer;

    public SpriteRenderer BorderSprite;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _myBoxCollider = this.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (_gameManager.DragObjectInstantiated)
        {
            if (_myBoxCollider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                BorderSprite.color = new Color(0, 150, 255);
            }
            else
            {
                BorderSprite.color = new Color(0, 0, 0);
            }
        }
        else
        {
            BorderSprite.color = new Color(0, 0, 0);
        }
    }
}