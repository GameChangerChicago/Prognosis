using UnityEngine;
using System.Collections;

public class ProfessionalSlot : MonoBehaviour
{
    private GameManager _gameManager;
    private BoxCollider2D _myBoxCollider;
	private SpriteRenderer _mySpriteRenderer;
    private TargetLocation _myTargetLocation;
    private TutorialToolTipManager _TTTManager;
    private GlobalStatsBar _theGSB;
    private bool _mousedOverWithAProfessional,
                 _hasAProfessional;

    public ProfessionalStack CurrentProfesional;
    public OnHover OnHoverTool;
    public SpriteRenderer BorderRenderer,
                          PortraitRenderer;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        OnHoverTool = this.GetComponent<OnHover>();
        _theGSB = FindObjectOfType<GlobalStatsBar>();
        _myTargetLocation = this.transform.parent.GetComponentInParent<TargetLocation>();
        _myBoxCollider = this.GetComponent<BoxCollider2D>();
		_mySpriteRenderer = this.GetComponent<SpriteRenderer> ();
        _TTTManager = FindObjectOfType<TutorialToolTipManager>();
		BorderRenderer.color = _mySpriteRenderer.color;
    }

    void Update()
    {
        if (_gameManager.DragObjectInstantiated) {
			if (!_myTargetLocation.Locked) {
				if (_myBoxCollider.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition))) {
					BorderRenderer.color = new Color (0, 150, 255);
					_mousedOverWithAProfessional = true;
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
            if (_theGSB.BudgetBarChange(_myTargetLocation, _gameManager.SelectedProfessional.MyProfessionalType, true))
            {
                _hasAProfessional = true;
                _mousedOverWithAProfessional = false;
                _gameManager.SelectedProfessional.ProfessionalCount--;
                if (_gameManager.SelectedProfessional.ProfessionalCount == 0)
                    _gameManager.SelectedProfessional.ButtonMask.SetActive(true);

                _myTargetLocation.TheProfMenu.PlaceAProfessional(_myTargetLocation.name, _gameManager.SelectedProfessional.MyProfessionalType);
                CurrentProfesional = _gameManager.SelectedProfessional;
                PortraitRenderer.sprite = _gameManager.SelectedProfessional.SlotPortrait;

                if(!_TTTManager.PlacedFirstProf && !FindObjectOfType<TutorialToolTip>())
                {
                    _TTTManager.ShowPopUp("PointOutBudget", 0.2f);
                    _TTTManager.PlacedFirstProf = true;
                }
            }
        }
    }

    public void RemoveProfessional()
    {
        if (_hasAProfessional && !_myTargetLocation.Locked)
        {
            if (CurrentProfesional.ProfessionalCount == 0)
                CurrentProfesional.ButtonMask.SetActive(false);

            CurrentProfesional.ProfessionalCount++;
            _myTargetLocation.TheProfMenu.RetrieveProfessional(_myTargetLocation.name, CurrentProfesional.MyProfessionalType);
            ProfessionalType removedProfType = CurrentProfesional.MyProfessionalType;
            CurrentProfesional = null;
            _hasAProfessional = false;
            PortraitRenderer.sprite = null;
            _theGSB.BudgetBarChange(_myTargetLocation, removedProfType, false);
        }
    }
}