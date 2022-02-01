using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableBase : MonoBehaviour
{
    [SerializeField] Renderer _renderer;

    protected virtual void OnMouseEnter()
    {
        _renderer.material.color = Color.red;
    }

    protected virtual void OnMouseOver()
    {
        _renderer.material.color -= new Color(0.1f, 0, 0) * Time.deltaTime;
    }

    protected virtual void OnMouseExit()
    {
        _renderer.material.color = Color.white;
    }
}
