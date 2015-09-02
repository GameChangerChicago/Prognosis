//using UnityEngine;
//using System.Collections;

//public class CameraController : MonoBehaviour
//{
//    private Camera _camera;
//    private Vector2 _clickLoc,
//                    _initialCamLoc,
//                    _clickScreenLoc,
//                    _currentScreenClickPos;
//    private float _targetLoc,
//                  _camMoveSpeed;

//    private bool _clickInitiated;
    
//    void Start()
//    {
//        _camera = Camera.main;
//    }

//    void Update()
//    {

//    }

//    private void InputHandler()
//    {
//        if (Input.GetKey(KeyCode.Mouse0) && !_clickInitiated)
//        {
//            _clickLoc = _camera.ScreenToWorldPoint(Input.mousePosition);
//            _initialCamLoc = this.transform.position;
//            _clickScreenLoc = Input.mousePosition;
//            _clickInitiated = true;
//        }

//        if (Input.GetKey(KeyCode.Mouse0))
//        {
//            _currentScreenClickPos = Input.mousePosition;
//        }
//        else if (_touching == true && _horizontalLock)
//        {
//            _touching = false;
//            _screenDragDistance = Mathf.Abs(_touchScreenLoc.x - _currentScreenTouchPos.x);
//            _lastTouchLoc = GetComponent<Camera>().ScreenToWorldPoint(_currentScreenTouchPos).x;

//            if (_screenDragDistance > (Screen.width / (3 / _touchTimer)))
//                _completeSlide = true;
//            else
//                _revertSlide = true;

//            _touchTimer = 0;
//            _horizontalLock = false;
//        }
//        else if (_touching == true && _verticalLock)
//        {
//            _touching = false;
//            _verticalLock = false;
//            _touchInitiated = false;
//        }
//        else if (_touching == true && !(_horizontalLock || _verticalLock))
//            _touching = false;
//    }

//    private void SlideMovement(bool advancingSlide, bool retreatingSlide, bool revertingSlide)
//    {
//        if (this.transform.position.x > _targetLoc - 2.5f)
//        {
//            _camMoveSpeed = Mathf.Clamp(this.transform.position.x - _targetLoc, 0.25f, 250);
//            this.transform.position = new Vector3(this.transform.position.x - (_camMoveSpeed * 15 * Time.deltaTime), this.transform.position.y, this.transform.position.z);

//            if (this.transform.position.x < _targetLoc - 0.001f)
//            {
//                this.transform.position = new Vector3(_targetLoc, this.transform.position.y, this.transform.position.z);
//            }
//        }
//        else if (this.transform.position.x < _targetLoc + 2.5f)
//        {
//            _camMoveSpeed = Mathf.Clamp(_targetLoc - this.transform.position.x, 0.25f, 150);
//            this.transform.position = new Vector3(this.transform.position.x + (_camMoveSpeed * 15 * Time.deltaTime), this.transform.position.y, this.transform.position.z);
//            if (this.transform.position.x > _targetLoc + 0.001f)
//            {
//                this.transform.position = new Vector3(_targetLoc, this.transform.position.y, this.transform.position.z);
//            }
//        }
//    }
//}