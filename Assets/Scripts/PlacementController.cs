using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Events;

[RequireComponent(typeof(ARRaycastManager))]
public class PlacementController : MonoBehaviour
{
    [HideInInspector] public bool inPlacementMode = false;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    [SerializeField] private ShapeFactory shapeFactory;
    [SerializeField] private GameObject placementCrossHair;

    private ARRaycastManager arRaycastManager;
    private Vector2 raycastOrigin;

    [SerializeField] UnityEvent<GameObject> onObjectPlaced;
    void Awake() 
    {
        raycastOrigin = new Vector2(Screen.width / 2f, Screen.height / 2f);
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    public void PlaceObject()
    {
        if (arRaycastManager.Raycast(raycastOrigin, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            GameObject placedPrefab = shapeFactory.GetShapeObect(hitPose.position, hitPose.rotation);
            onObjectPlaced?.Invoke(placedPrefab);
        }
    }

    public void SetPlacementMode(bool inplacement)
    {
        inPlacementMode = inplacement;
        placementCrossHair.SetActive(inPlacementMode);
    }

    void Update()
    {
        if(!inPlacementMode)
            return;

        if(arRaycastManager.Raycast(raycastOrigin, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            placementCrossHair.transform.position = hits[0].pose.position;
        }
    }

}
