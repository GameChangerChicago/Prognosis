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
                if (value)
                    _targetLoc = this.transform.position.y + 1.8f;
                else
                    _targetLoc = this.transform.position.y - 1.8f;

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

    private float _targetLoc;
    private bool _finishedMoving;
    
    void Start()
    {
        DocLoc1 = GameObject.Find("Doctor Locations/Location1").GetComponent<Text>();
        DocLoc2 = GameObject.Find("Doctor Locations/Location2").GetComponent<Text>();
        DocLoc3 = GameObject.Find("Doctor Locations/Location3").GetComponent<Text>();
        DocLoc4 = GameObject.Find("Doctor Locations/Location4").GetComponent<Text>();
        DocLoc5 = GameObject.Find("Doctor Locations/Location5").GetComponent<Text>();

        NurseLoc1 = GameObject.Find("Nurse Locations/Location1").GetComponent<Text>();
        NurseLoc2 = GameObject.Find("Nurse Locations/Location2").GetComponent<Text>();
        NurseLoc3 = GameObject.Find("Nurse Locations/Location3").GetComponent<Text>();
        NurseLoc4 = GameObject.Find("Nurse Locations/Location4").GetComponent<Text>();
        NurseLoc5 = GameObject.Find("Nurse Locations/Location5").GetComponent<Text>();

        COLoc1 = GameObject.Find("CO Locations/Location1").GetComponent<Text>();
        COLoc2 = GameObject.Find("CO Locations/Location2").GetComponent<Text>();
        COLoc3 = GameObject.Find("CO Locations/Location3").GetComponent<Text>();
        COLoc4 = GameObject.Find("CO Locations/Location4").GetComponent<Text>();
        COLoc5 = GameObject.Find("CO Locations/Location5").GetComponent<Text>();

        PolLoc1 = GameObject.Find("Politician Locations/Location1").GetComponent<Text>();
        PolLoc2 = GameObject.Find("Politician Locations/Location2").GetComponent<Text>();
        PolLoc3 = GameObject.Find("Politician Locations/Location3").GetComponent<Text>();
        PolLoc4 = GameObject.Find("Politician Locations/Location4").GetComponent<Text>();
        PolLoc5 = GameObject.Find("Politician Locations/Location5").GetComponent<Text>();

        AdvLoc1 = GameObject.Find("Advocate Locations/Location1").GetComponent<Text>();
        AdvLoc2 = GameObject.Find("Advocate Locations/Location2").GetComponent<Text>();
        AdvLoc3 = GameObject.Find("Advocate Locations/Location3").GetComponent<Text>();
        AdvLoc4 = GameObject.Find("Advocate Locations/Location4").GetComponent<Text>();
        AdvLoc5 = GameObject.Find("Advocate Locations/Location5").GetComponent<Text>();
    }

    void Update()
    {
        if (!_finishedMoving)
            PMMovement();
    }

    private void PMMovement()
    {
        if (Active && this.transform.position.y < _targetLoc)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Time.deltaTime * 5, this.transform.position.z);

            if (this.transform.position.y > _targetLoc)
            {
                this.transform.position = new Vector3(this.transform.position.x, _targetLoc, this.transform.position.z);
                _finishedMoving = true;
            }
        }
        else if (!Active && this.transform.position.y > _targetLoc)
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

    }

    public void MoveDown()
    {

    }
}