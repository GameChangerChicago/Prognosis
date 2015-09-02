using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetLocation : MonoBehaviour
{
    public GameObject TargetMenu;
    public float STIRate,
                 TeenPregRate,
                 CommunityHealth;
    private List<TargetLocation> _otherTargetLocs = new List<TargetLocation>();
    private ProfessionalSlot[] proSlots;
    private ProfessionalsMenu PM;

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

    void Start()
    {
        PM = FindObjectOfType<ProfessionalsMenu>();
        _otherTargetLocs.AddRange(FindObjectsOfType<TargetLocation>());
        _otherTargetLocs.Remove(this);
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