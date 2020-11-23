using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class ObjectChooser : MonoBehaviour
{
    [SerializeField] private ARPlacementInteractable placementInteractable;
    [SerializeField] private List<GameObject> placeableObjects;

    public void SelectObjectByIdx(int idx)
    {
        placementInteractable.placementPrefab = placeableObjects[idx];
    }
}
