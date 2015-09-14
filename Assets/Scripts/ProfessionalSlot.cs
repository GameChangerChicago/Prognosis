using UnityEngine;
using System.Collections;

public class ProfessionalSlot : MonoBehaviour
{
    private GameManager _gameManager;
    private BoxCollider2D _myBoxCollider;
	private SpriteRenderer _mySpriteRenderer;
    private TargetLocation _myTargetLocation;
    private bool _mousedOverWithAProfessional,
                 _hasAProfessional;

    public Professional CurrentProfesional;
    public SpriteRenderer BorderRenderer,
                          PortraitRenderer;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _myTargetLocation = this.transform.parent.GetComponentInParent<TargetLocation>();
        _myBoxCollider = this.GetComponent<BoxCollider2D>();
		_mySpriteRenderer = this.GetComponent<SpriteRenderer> ();
		BorderRenderer.color = _mySpriteRenderer.color;
    }

    void Update()
    {
        if (_gameManager.DragObjectInstantiated)
        {
            if (_myBoxCollider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                BorderRenderer.color = new Color(0, 150, 255);
                _mousedOverWithAProfessional = true;
				Debug.Log("Collision detected");
            }
            else
            {
                //BorderRenderer.color = new Color(0, 0, 0);
                _mousedOverWithAProfessional = false;
            }
        }
//        else
//        {
//            BorderRenderer.color = new Color(0, 0, 0);
//        }

        if (_mousedOverWithAProfessional && Input.GetKeyUp(KeyCode.Mouse0))
        {
            _hasAProfessional = true;
            _mousedOverWithAProfessional = false;
            _gameManager.SelectedProfessional.ProfessionalCount--;
            CurrentProfesional = _gameManager.SelectedProfessional;
            PortraitRenderer.sprite = _gameManager.SelectedProfessional.SlotPortrait;
        }
    }

    void OnMouseDown()
    {
        if (_hasAProfessional && !_myTargetLocation.Locked)
        {
            CurrentProfesional.ProfessionalCount++;
            _hasAProfessional = false;
            PortraitRenderer.sprite = null;
        }
    }
}