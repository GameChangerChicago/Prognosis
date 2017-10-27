using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProfessionalStack : MonoBehaviour
{
    public Sprite SlotPortrait;
    public GameObject DragObject;
    public ProfessionalType MyProfessionalType;
    public int ProfessionalCount;

    private ProfessionalsMenu _professionalMenu;
    private GameObject _dragObject;
    private GameManager _gameManager;
    private Vector2 mousePos;
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
        _professionalMenu = GetComponentInParent<ProfessionalsMenu>();
		//scrollRect = FindObjectOfType<Canvas> ().GetComponent<ScrollRect> ();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (_dragObject != null)
                Destroy(_dragObject);

            dragObjectInstantiated = false;
			scrollRect.enabled = true;

        }

        if (dragObjectInstantiated)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _dragObject.transform.position = mousePos;
			scrollRect.StopMovement();
			scrollRect.enabled = false;
			Debug.Log (scrollRect.enabled);
        }
    }

    void OnMouseDown()
    {
        if (ProfessionalCount > 0)
        {
            _dragObject = Instantiate<GameObject>(DragObject);
            dragObjectInstantiated = true;
        }
    }
}