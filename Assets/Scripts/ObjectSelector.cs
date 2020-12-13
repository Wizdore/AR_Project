using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ObjectSelector : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> onObjectSelected;
    [SerializeField] private UnityEvent onObjectUnSelected;

    bool GetTouchPosition(out Vector2 _touchedPos)
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                _touchedPos = Input.GetTouch(0).position;
                return true;
            }
        }
        _touchedPos = default;
        return false;
    }

    void Update()
    {
        if (!GetTouchPosition(out Vector2 touchPosition))
            return;

        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.GetComponent<IObjectControllable>() != null && hit.collider != null)
            {
                onObjectSelected?.Invoke(hit.collider.gameObject);
            }
            else onObjectUnSelected?.Invoke();
        }
    }
}
