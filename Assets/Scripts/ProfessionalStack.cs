using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProfessionalStack : MonoBehaviour
{
    public Sprite SlotPortrait;
    public GameObject DragObject,
                      ButtonMask;
    public ProfessionalType MyProfessionalType;
    public Text CountText;
    public int ProfessionalCount;
    public OnHover OnHoverTool;

    private ProfessionalsMenu _professionalMenu;
    private GameObject _dragObject;
    private GameManager _gameManager;
    private AudioManager _audioManager;
    private Vector2 mousePos;
    private int _professionalCount;
	public ScrollRect scrollRect;

    protected bool dragObjectInstantiated
    {
        get
        {
            return _dragObjectInstantiated;
        }

        set
        {
            if (value)
            {
                _gameManager.SelectedProfessional = this;
            }

            _gameManager.DragObjectInstantiated = value;
            _dragObjectInstantiated = value;
        }
    }
    private bool _dragObjectInstantiated;
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _audioManager = AudioManager.instance;
        _professionalMenu = GetComponentInParent<ProfessionalsMenu>();
        _professionalCount = ProfessionalCount;
		//scrollRect = FindObjectOfType<Canvas>().GetComponent<ScrollRect> ();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (_dragObject != null)
            {
                Destroy(_dragObject);
                _audioManager.PlaySound("Professional Poof");
            }

            dragObjectInstantiated = false;
			scrollRect.enabled = true;

        }

        if (dragObjectInstantiated)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _dragObject.transform.position = mousePos;
			scrollRect.StopMovement();
			scrollRect.enabled = false;
        }

        if(ProfessionalCount != _professionalCount)
        {
            CountText.text = ProfessionalCount.ToString();

            _professionalCount = ProfessionalCount;
        }
    }

    public void TakeProfessional()
    {
        if (ProfessionalCount > 0)
        {
            _dragObject = Instantiate<GameObject>(DragObject);
            dragObjectInstantiated = true;

            if (FindObjectOfType<TutorialToolTip>().name == "TryProfessional")
            {
                EventManager.TriggerEvent("Close");
            }
        }
    }
}