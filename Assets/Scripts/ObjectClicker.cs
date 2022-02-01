using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{

    [SerializeField] private float _clickDistance = 100f;
    [SerializeField] private LayerMask _clickableLayerMask;

    private IInteractable _previousInteractable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region OnHoverScopeRayCasts
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f, _clickableLayerMask))
        {
            IInteractable interactable = hit.transform.GetComponent<IInteractable>();
            if (interactable != _previousInteractable)
            {
                if (interactable != null) interactable.OnHoverEnter();
                if (_previousInteractable != null) _previousInteractable.OnHoverExit();
                _previousInteractable = interactable;
            }
        }
        else
        {
            if (_previousInteractable != null) _previousInteractable.OnHoverExit();
            _previousInteractable = null;
            
        }
        #endregion

        


        #region OnClickScope
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitClick;
            Ray rayClick = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayClick, out hitClick, 100f, _clickableLayerMask))
            {
                IInteractable interactable = hitClick.transform.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.OnLeftClick();
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitClick;
            Ray rayClick = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayClick, out hitClick, 100f, _clickableLayerMask))
            {
                IInteractable interactable = hitClick.transform.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.OnRightClick();
                }
            }
        }
        #endregion


        #region TestCode
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit, 100f, _clickableLayerMask))
        //    {
        //        IInteractable interactable = hit.transform.GetComponent<IInteractable>();
        //        if (interactable != null)
        //        {
        //            interactable.ClickedOnAction();
        //        }
        //    }
        //}
        //else
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit, 100f, _clickableLayerMask))
        //    {
        //        IInteractable interactable = hit.transform.GetComponent<IInteractable>();
        //        if (interactable != null)
        //        {
        //            interactable.HoverHighlight();
        //        }
        //    }
        //}
        #endregion
    }
}
