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
                foreach (TargetLocation tl in FindObjectsOfType<TargetLocation>())
                {
                    tl.UpdateValues();
                }
            }
            _currentTurn = value;
        }
    }
    private int _currentTurn;
}