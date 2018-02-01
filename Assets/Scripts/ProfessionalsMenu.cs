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

        AdvLoc1 = GameObject.Find("SW Locations/Location 1").GetComponent<Text>();
        AdvLoc2 = GameObject.Find("SW Locations/Location 2").GetComponent<Text>();
        AdvLoc3 = GameObject.Find("SW Locations/Location 3").GetComponent<Text>();
        AdvLoc4 = GameObject.Find("SW Locations/Location 4").GetComponent<Text>();
        AdvLoc5 = GameObject.Find("SW Locations/Location 5").GetComponent<Text>();

        _initialLoc = this.transform.position.y;
        _targetLoc = _initialLoc;
        _partialViewLoc = _initialLoc + 1.8f;
        _fullViewLoc = _partialViewLoc + 3.6f;

        #region Professional Location Label Initialization
        ProfessionalStack[] allProfStacks = this.GetComponentsInChildren<ProfessionalStack>();

        foreach (ProfessionalStack ps in allProfStacks)
        {
            int locationLeblesToHide = 5 - ps.ProfessionalCount;

            switch (ps.MyProfessionalType)
            {
                case ProfessionalType.Doctor:
                    for (int i = 0; i < locationLeblesToHide; i++)
                    {
                        if(i == 0)
                        {
                            DocLoc5.enabled = false;
                        }
                        else if(i == 1)
                        {
                            DocLoc4.enabled = false;
                        }
                        else if (i == 2)
                        {
                            DocLoc3.enabled = false;
                        }
                        else if (i == 3)
                        {
                            DocLoc2.enabled = false;
                        }
                        else if (i == 4)
                        {
                            DocLoc1.enabled = false;
                        }
                    }
                    break;
                case ProfessionalType.Nurse:
                    for (int i = 0; i < locationLeblesToHide; i++)
                    {
                        if (i == 0)
                        {
                            NurseLoc5.enabled = false;
                        }
                        else if (i == 1)
                        {
                            NurseLoc4.enabled = false;
                        }
                        else if (i == 2)
                        {
                            NurseLoc3.enabled = false;
                        }
                        else if (i == 3)
                        {
                            NurseLoc2.enabled = false;
                        }
                        else if (i == 4)
                        {
                            NurseLoc1.enabled = false;
                        }
                    }
                    break;
                case ProfessionalType.CommOrg:
                    for (int i = 0; i < locationLeblesToHide; i++)
                    {
                        if (i == 0)
                        {
                            COLoc5.enabled = false;
                        }
                        else if (i == 1)
                        {
                            COLoc4.enabled = false;
                        }
                        else if (i == 2)
                        {
                            COLoc3.enabled = false;
                        }
                        else if (i == 3)
                        {
                            COLoc2.enabled = false;
                        }
                        else if (i == 4)
                        {
                            COLoc1.enabled = false;
                        }
                    }
                    break;
                case ProfessionalType.Politician:
                    for (int i = 0; i < locationLeblesToHide; i++)
                    {
                        if (i == 0)
                        {
                            PolLoc5.enabled = false;
                        }
                        else if (i == 1)
                        {
                            PolLoc4.enabled = false;
                        }
                        else if (i == 2)
                        {
                            PolLoc3.enabled = false;
                        }
                        else if (i == 3)
                        {
                            PolLoc2.enabled = false;
                        }
                        else if (i == 4)
                        {
                            PolLoc1.enabled = false;
                        }
                    }
                    break;
                case ProfessionalType.SocialWorker:
                    for (int i = 0; i < locationLeblesToHide; i++)
                    {
                        if (i == 0)
                        {
                            AdvLoc5.enabled = false;
                        }
                        else if (i == 1)
                        {
                            AdvLoc4.enabled = false;
                        }
                        else if (i == 2)
                        {
                            AdvLoc3.enabled = false;
                        }
                        else if (i == 3)
                        {
                            AdvLoc2.enabled = false;
                        }
                        else if (i == 4)
                        {
                            AdvLoc1.enabled = false;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion
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

#region Highlight Methods
    public void UpButtonHighlightToggle(bool on)
    {

    }

    public void DownButtonHighlightToggle(bool on)
    {

    }
#endregion

    public void PlaceAProfessional(string targetLoc, ProfessionalType profType)
    {
        switch(profType)
        {
            case ProfessionalType.Doctor:
                if(DocLoc1.text == "Unassigned")
                {
                    DocLoc1.text = targetLoc;
                    DocLoc1.color = Color.white;
                }
                else if(DocLoc2.text == "Unassigned")
                {
                    DocLoc2.text = targetLoc;
                    DocLoc2.color = Color.white;
                }
                else if(DocLoc3.text == "Unassigned")
                {
                    DocLoc3.text = targetLoc;
                    DocLoc3.color = Color.white;
                }
                else if (DocLoc4.text == "Unassigned")
                {
                    DocLoc4.text = targetLoc;
                    DocLoc4.color = Color.white;
                }
                else if (DocLoc5.text == "Unassigned")
                {
                    DocLoc5.text = targetLoc;
                    DocLoc5.color = Color.white;
                }
                break;
            case ProfessionalType.Nurse:
                if (NurseLoc1.text == "Unassigned")
                {
                    NurseLoc1.text = targetLoc;
                    NurseLoc1.color = Color.white;
                }
                else if (NurseLoc2.text == "Unassigned")
                {
                    NurseLoc2.text = targetLoc;
                    NurseLoc2.color = Color.white;
                }
                else if (NurseLoc3.text == "Unassigned")
                {
                    NurseLoc3.text = targetLoc;
                    NurseLoc3.color = Color.white;
                }
                else if (NurseLoc4.text == "Unassigned")
                {
                    NurseLoc4.text = targetLoc;
                    NurseLoc4.color = Color.white;
                }
                else if (NurseLoc5.text == "Unassigned")
                {
                    NurseLoc5.text = targetLoc;
                    NurseLoc5.color = Color.white;
                }
                break;
            case ProfessionalType.CommOrg:
                if (COLoc1.text == "Unassigned")
                {
                    COLoc1.text = targetLoc;
                    COLoc1.color = Color.white;
                }
                else if (COLoc2.text == "Unassigned")
                {
                    COLoc2.text = targetLoc;
                    COLoc2.color = Color.white;
                }
                else if (COLoc3.text == "Unassigned")
                {
                    COLoc3.text = targetLoc;
                    COLoc3.color = Color.white;
                }
                else if (COLoc4.text == "Unassigned")
                {
                    COLoc4.text = targetLoc;
                    COLoc4.color = Color.white;
                }
                else if (COLoc5.text == "Unassigned")
                {
                    COLoc5.text = targetLoc;
                    COLoc5.color = Color.white;
                }
                break;
            case ProfessionalType.Politician:
                if (PolLoc1.text == "Unassigned")
                {
                    PolLoc1.text = targetLoc;
                    PolLoc1.color = Color.white;
                }
                else if (PolLoc2.text == "Unassigned")
                {
                    PolLoc2.text = targetLoc;
                    PolLoc2.color = Color.white;
                }
                else if (PolLoc3.text == "Unassigned")
                {
                    PolLoc3.text = targetLoc;
                    PolLoc3.color = Color.white;
                }
                else if (PolLoc4.text == "Unassigned")
                {
                    PolLoc4.text = targetLoc;
                    PolLoc4.color = Color.white;
                }
                else if (PolLoc5.text == "Unassigned")
                {
                    PolLoc5.text = targetLoc;
                    PolLoc5.color = Color.white;
                }
                break;
            case ProfessionalType.SocialWorker:
                if (AdvLoc1.text == "Unassigned")
                {
                    AdvLoc1.text = targetLoc;
                    AdvLoc1.color = Color.white;
                }
                else if (AdvLoc2.text == "Unassigned")
                {
                    AdvLoc2.text = targetLoc;
                    AdvLoc2.color = Color.white;
                }
                else if (AdvLoc3.text == "Unassigned")
                {
                    AdvLoc3.text = targetLoc;
                    AdvLoc3.color = Color.white;
                }
                else if (AdvLoc4.text == "Unassigned")
                {
                    AdvLoc4.text = targetLoc;
                    AdvLoc4.color = Color.white;
                }
                else if (AdvLoc5.text == "Unassigned")
                {
                    AdvLoc5.text = targetLoc;
                    AdvLoc5.color = Color.white;
                }
                break;
            default:
                Debug.Log("??????");
                break;
        }
    }

    public void RetrieveProfessional(string targetLoc, ProfessionalType profType)
    {
        switch (profType)
        {
            case ProfessionalType.Doctor:
                if (DocLoc5.enabled && DocLoc5.text == targetLoc)
                {
                    DocLoc5.text = "Unassigned";
                    DocLoc5.color = Color.gray;
                }
                else if (DocLoc4.enabled && DocLoc4.text == targetLoc)
                {
                    DocLoc4.text = "Unassigned";
                    DocLoc4.color = Color.gray;
                }//Finish the enabled bit
                else if (DocLoc3.text == targetLoc)
                {
                    DocLoc3.text = "Unassigned";
                    DocLoc3.color = Color.gray;
                }
                else if (DocLoc2.text == targetLoc)
                {
                    DocLoc2.text = "Unassigned";
                    DocLoc2.color = Color.gray;
                }
                else if (DocLoc1.text == targetLoc)
                {
                    DocLoc1.text = "Unassigned";
                    DocLoc1.color = Color.gray;
                }
                break;
            case ProfessionalType.Nurse:
                if (NurseLoc5.text == targetLoc)
                {
                    NurseLoc5.text = "Unassigned";
                    NurseLoc5.color = Color.gray;
                }
                else if (NurseLoc4.text == targetLoc)
                {
                    NurseLoc4.text = "Unassigned";
                    NurseLoc4.color = Color.gray;
                }
                else if (NurseLoc3.text == targetLoc)
                {
                    NurseLoc3.text = "Unassigned";
                    NurseLoc3.color = Color.gray;
                }
                else if (NurseLoc2.text == targetLoc)
                {
                    NurseLoc2.text = "Unassigned";
                    NurseLoc2.color = Color.gray;
                }
                else if (NurseLoc1.text == targetLoc)
                {
                    NurseLoc1.text = "Unassigned";
                    NurseLoc1.color = Color.gray;
                }
                break;
            case ProfessionalType.CommOrg:
                if (COLoc5.text == targetLoc)
                {
                    COLoc5.text = "Unassigned";
                    COLoc5.color = Color.gray;
                }
                else if (COLoc4.text == targetLoc)
                {
                    COLoc4.text = "Unassigned";
                    COLoc4.color = Color.gray;
                }
                else if (COLoc3.text == targetLoc)
                {
                    COLoc3.text = "Unassigned";
                    COLoc3.color = Color.gray;
                }
                else if (COLoc2.text == targetLoc)
                {
                    COLoc2.text = "Unassigned";
                    COLoc2.color = Color.gray;
                }
                else if (COLoc1.text == targetLoc)
                {
                    COLoc1.text = "Unassigned";
                    COLoc1.color = Color.gray;
                }
                break;
            case ProfessionalType.Politician:
                if (PolLoc5.text == targetLoc)
                {
                    PolLoc5.text = "Unassigned";
                    PolLoc5.color = Color.gray;
                }
                else if (PolLoc4.text == targetLoc)
                {
                    PolLoc4.text = "Unassigned";
                    PolLoc4.color = Color.gray;
                }
                else if (PolLoc3.text == targetLoc)
                {
                    PolLoc3.text = "Unassigned";
                    PolLoc3.color = Color.gray;
                }
                else if (PolLoc2.text == targetLoc)
                {
                    PolLoc2.text = "Unassigned";
                    PolLoc2.color = Color.gray;
                }
                else if (PolLoc1.text == targetLoc)
                {
                    PolLoc1.text = "Unassigned";
                    PolLoc1.color = Color.gray;
                }
                break;
            case ProfessionalType.SocialWorker:
                if (AdvLoc5.text == targetLoc)
                {
                    AdvLoc5.text = "Unassigned";
                    AdvLoc5.color = Color.gray;
                }
                else if (AdvLoc4.text == targetLoc)
                {
                    AdvLoc4.text = "Unassigned";
                    AdvLoc4.color = Color.gray;
                }
                else if (AdvLoc3.text == targetLoc)
                {
                    AdvLoc3.text = "Unassigned";
                    AdvLoc3.color = Color.gray;
                }
                else if (AdvLoc2.text == targetLoc)
                {
                    AdvLoc2.text = "Unassigned";
                    AdvLoc2.color = Color.gray;
                }
                else if (AdvLoc1.text == targetLoc)
                {
                    AdvLoc1.text = "Unassigned";
                    AdvLoc1.color = Color.gray;
                }
                break;
            default:
                Debug.Log("??????");
                break;
        }
    }
}