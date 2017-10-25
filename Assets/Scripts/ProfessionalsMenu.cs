using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProfessionalsMenu : MonoBehaviour
{
    public bool Active
    {
        get
        {
            return active;
        }

        set
        {
            if (active != value)
            {
                if (_targetLoc != _partialViewLoc || _targetLoc != _fullViewLoc)
                {
                    if (value)
                        _targetLoc = _partialViewLoc;
                    else
                        _targetLoc = _partialViewLoc;
                }

                _finishedMoving = false;
                active = value;
            }
        }
    }
    protected bool active;

    private Text DocLoc1, DocLoc2, DocLoc3, DocLoc4, DocLoc5,
                 NurseLoc1, NurseLoc2, NurseLoc3, NurseLoc4, NurseLoc5,
                 COLoc1, COLoc2, COLoc3, COLoc4, COLoc5,
                 PolLoc1, PolLoc2, PolLoc3, PolLoc4, PolLoc5,
                 AdvLoc1, AdvLoc2, AdvLoc3, AdvLoc4, AdvLoc5;

    private float _targetLoc,
                  _initialLoc,
                  _partialViewLoc,
                  _fullViewLoc;
    private bool _finishedMoving;
    
    void Start()
    {
        DocLoc1 = GameObject.Find("Doctor Locations/Location 1").GetComponent<Text>();
        DocLoc2 = GameObject.Find("Doctor Locations/Location 2").GetComponent<Text>();
        DocLoc3 = GameObject.Find("Doctor Locations/Location 3").GetComponent<Text>();
        DocLoc4 = GameObject.Find("Doctor Locations/Location 4").GetComponent<Text>();
        DocLoc5 = GameObject.Find("Doctor Locations/Location 5").GetComponent<Text>();

        NurseLoc1 = GameObject.Find("Nurse Locations/Location 1").GetComponent<Text>();
        NurseLoc2 = GameObject.Find("Nurse Locations/Location 2").GetComponent<Text>();
        NurseLoc3 = GameObject.Find("Nurse Locations/Location 3").GetComponent<Text>();
        NurseLoc4 = GameObject.Find("Nurse Locations/Location 4").GetComponent<Text>();
        NurseLoc5 = GameObject.Find("Nurse Locations/Location 5").GetComponent<Text>();

        COLoc1 = GameObject.Find("CO Locations/Location 1").GetComponent<Text>();
        COLoc2 = GameObject.Find("CO Locations/Location 2").GetComponent<Text>();
        COLoc3 = GameObject.Find("CO Locations/Location 3").GetComponent<Text>();
        COLoc4 = GameObject.Find("CO Locations/Location 4").GetComponent<Text>();
        COLoc5 = GameObject.Find("CO Locations/Location 5").GetComponent<Text>();

        PolLoc1 = GameObject.Find("Politician Locations/Location 1").GetComponent<Text>();
        PolLoc2 = GameObject.Find("Politician Locations/Location 2").GetComponent<Text>();
        PolLoc3 = GameObject.Find("Politician Locations/Location 3").GetComponent<Text>();
        PolLoc4 = GameObject.Find("Politician Locations/Location 4").GetComponent<Text>();
        PolLoc5 = GameObject.Find("Politician Locations/Location 5").GetComponent<Text>();

        AdvLoc1 = GameObject.Find("Advocate Locations/Location 1").GetComponent<Text>();
        AdvLoc2 = GameObject.Find("Advocate Locations/Location 2").GetComponent<Text>();
        AdvLoc3 = GameObject.Find("Advocate Locations/Location 3").GetComponent<Text>();
        AdvLoc4 = GameObject.Find("Advocate Locations/Location 4").GetComponent<Text>();
        AdvLoc5 = GameObject.Find("Advocate Locations/Location 5").GetComponent<Text>();

        _initialLoc = this.transform.position.y;
        _targetLoc = _initialLoc;
        _partialViewLoc = _initialLoc + 1.8f;
        _fullViewLoc = _partialViewLoc + 3.6f;
    }

    void Update()
    {
        if (!_finishedMoving)
            PMMovement();
    }

    private void PMMovement()
    {
        if (this.transform.position.y < _targetLoc)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Time.deltaTime * 5, this.transform.position.z);

            if (this.transform.position.y > _targetLoc)
            {
                this.transform.position = new Vector3(this.transform.position.x, _targetLoc, this.transform.position.z);
                _finishedMoving = true;
            }
        }
        else if (this.transform.position.y > _targetLoc)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - Time.deltaTime * 5, this.transform.position.z);

            if (this.transform.position.y < _targetLoc)
            {
                this.transform.position = new Vector3(this.transform.position.x, _targetLoc, this.transform.position.z);
                _finishedMoving = true;
            }
        }
    }

    public void MoveUp()
    {
        if (_targetLoc == _initialLoc)
        {
            _targetLoc = _partialViewLoc;
            _finishedMoving = false;
        }
        else if (_targetLoc == _partialViewLoc)
        {
            _targetLoc = _fullViewLoc;
            _finishedMoving = false;
        }
        else
        {
            Debug.Log("No go");
        }
    }

    public void MoveDown()
    {
        if (_targetLoc == _fullViewLoc)
        {
            _targetLoc = _partialViewLoc;
            _finishedMoving = false;
        }
        else if (_targetLoc == _partialViewLoc)
        {
            _targetLoc = _initialLoc;
            _finishedMoving = false;
        }
        else
        {
            Debug.Log("No go");
        }
    }
}