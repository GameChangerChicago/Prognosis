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

    public ProfessionalStack CurrentProfesional;
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
        if (_gameManager.DragObjectInstantiated) {
			if (!_myTargetLocation.Locked) {
				if (_myBoxCollider.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition))) {
					BorderRenderer.color = new Color (0, 150, 255);
					_mousedOverWithAProfessional = true;
					Debug.Log ("Collision detected");
				} else {
					//BorderRenderer.color = new Color(0, 0, 0);
					_mousedOverWithAProfessional = false;
				}
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
            _myTargetLocation.TheProfMenu.PlaceAProfessional(_myTargetLocation.name, _gameManager.SelectedProfessional.MyProfessionalType);
            CurrentProfesional = _gameManager.SelectedProfessional;
			//_myTargetLocation.ProSlots.Add(this);
            PortraitRenderer.sprite = _gameManager.SelectedProfessional.SlotPortrait;
        }
    }

    void OnMouseDown()
    {
        if (_hasAProfessional && !_myTargetLocation.Locked)
        {
            CurrentProfesional.ProfessionalCount++;
            _myTargetLocation.TheProfMenu.RetrieveProfessional(_myTargetLocation.name, CurrentProfesional.MyProfessionalType);
		//	_myTargetLocation.ProSlots.Remove(this);
            _hasAProfessional = false;
            PortraitRenderer.sprite = null;
        }
    }
}