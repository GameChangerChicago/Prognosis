﻿using UnityEngine;
using System.Collections;

public class Professional : MonoBehaviour
{
    public Sprite SlotPortrait;
    public GameObject DragObject;
    public ProfessionalType MyProfessionalType;
    public int ProfessionalCount;

    private GameObject _dragObject;
    private GameManager _gameManager;
    private Vector2 mousePos;

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
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (_dragObject != null)
                Destroy(_dragObject);

            dragObjectInstantiated = false;
        }

        if (dragObjectInstantiated)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _dragObject.transform.position = mousePos;
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