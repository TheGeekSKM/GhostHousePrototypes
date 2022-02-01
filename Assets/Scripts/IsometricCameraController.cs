using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCameraController : MonoBehaviour
{
    [Header("Camera Connections")]
    [SerializeField] Camera _mainCamera;

    [Header("Camera Values")]
    [SerializeField] private float _cameraMoveSpeed = 10f;
    [SerializeField] private float _cameraZoomSpeed = 5f;
    [SerializeField] private float _maxZoomInValue = 0.7f;
    [SerializeField] private float _maxZoomOutValue = 6.37f;

    [Header("Camera Sprint")]
    [SerializeField] private bool _enableSprintSpeed = true;
    [SerializeField] private float _cameraSprintSpeed = 20f;
    
    
    private Vector3 forward, right;

    private void Start()
    {
        if (_mainCamera != null)
        {
            forward = _mainCamera.transform.forward;
        }
        else
        {
            forward = Camera.main.transform.forward;
        }
        forward.y = 0f;
        forward = Vector3.Normalize(forward);

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void HandleInput()
    {
        Vector3 rightMovement;
        Vector3 upMovement;

        if (_enableSprintSpeed && Input.GetKey(KeyCode.LeftShift))
        {
            rightMovement = right * _cameraSprintSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
            upMovement = forward * _cameraSprintSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        }
        else
        {
            rightMovement = right * _cameraMoveSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
            upMovement = forward * _cameraMoveSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        }

        if (_mainCamera != null)
        {
            _mainCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * _cameraZoomSpeed;

            if (_mainCamera.orthographicSize > _maxZoomOutValue)
            {
                _mainCamera.orthographicSize = _maxZoomOutValue;
            }
            if (_mainCamera.orthographicSize < _maxZoomInValue)
            {
                _mainCamera.orthographicSize = _maxZoomInValue;
            }
        }
        else
        {
            Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * _cameraZoomSpeed;
            if (Camera.main.orthographicSize > _maxZoomOutValue)
            {
                Camera.main.orthographicSize = _maxZoomOutValue;
            }
            if (Camera.main.orthographicSize < _maxZoomInValue)
            {
                Camera.main.orthographicSize = _maxZoomInValue;
            }
        }


        transform.position += rightMovement;
        //Debug.Log(rightMovement);

        transform.position += upMovement;
        //Debug.Log(upMovement);

    }


    private void Update()
    {
        HandleInput();
    }
}
