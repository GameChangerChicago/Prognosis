using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Professional SelectedProfessional;
    public float Finance,
                 Education;
    public bool DragObjectInstantiated;


    public int CurrentTurn
    {
        get
        {
            return _currentTurn;
        }

        set
        {
            if (_currentTurn != value)
            {
                //Call ever update values
            }
            _currentTurn = value;
        }
    }
    private int _currentTurn;
}