using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMarkerController : MonoBehaviour
{
    [SerializeField] GameObject previousSelection;

    private void Awake()
    {
        previousSelection = null;
    }

    public void SetUnSelection()
    {
        previousSelection?.GetComponent<IObjectControllable>()?.DeSelect();
        previousSelection = null;
    }

    public void SetSelectionMarker(GameObject newSelection)
    {
        IObjectControllable nc = newSelection.GetComponent<IObjectControllable>();
        nc?.Select();

        if (previousSelection != null)
        {
            IObjectControllable pc = previousSelection.GetComponent<IObjectControllable>();
            pc?.DeSelect();
        }

        previousSelection = newSelection;
    }
}
