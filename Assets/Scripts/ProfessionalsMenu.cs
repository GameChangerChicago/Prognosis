using UnityEngine;
using System.Collections;

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

    private float _targetLoc;
    private bool _finishedMoving;
    
    void Start()
    {

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
}