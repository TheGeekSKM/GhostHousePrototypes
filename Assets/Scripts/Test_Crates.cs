using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Crates : MonoBehaviour, IInteractable
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] MeshRenderer _meshRenderer;

    void Awake()
    {
        
    }

    void MoveHorizontal()
    {
        Quaternion turnOffset = Quaternion.Euler(0, 30f, 0);
        if (_rigidbody != null)
        {
            _rigidbody.MoveRotation(_rigidbody.rotation * turnOffset);
        }
    }

    void MoveVerticalBackwards()
    {
        Quaternion turnOffset = Quaternion.Euler(-30f, 0, -20f);
        if (_rigidbody != null)
        {
            _rigidbody.MoveRotation(_rigidbody.rotation * turnOffset);
        }
    }

    void MoveVerticalForwards()
    {
        Quaternion turnOffset = Quaternion.Euler(30f, 0, 20f);
        if (_rigidbody != null)
        {
            _rigidbody.MoveRotation(_rigidbody.rotation * turnOffset);
        }
    }

    public void OnHoverEnter()
    {
        Debug.Log("Hovering over " + gameObject.name);
        MoveHorizontal();
    }

    public void OnHoverExit()
    {
        Debug.Log("No Longer Hovering over" + gameObject.name);
    }

    public void OnLeftClick()
    {
        Debug.Log("Left Clicked On" + gameObject.name);
        MoveVerticalForwards();
    }

    public void OnRightClick()
    {
        Debug.Log("Right Clicked On" + gameObject.name);
        MoveVerticalBackwards();
    }




}
