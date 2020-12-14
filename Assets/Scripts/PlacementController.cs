using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(ARRaycastManager))]
public class PlacementController : MonoBehaviour
{
    [SerializeField] private float placementAnimDuration;
    [SerializeField] private Ease placementAnimEase;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    [SerializeField] private ShapeFactory shapeFactory;
    [SerializeField] private GameObject arObjectsRoot;

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

            
            placedPrefab.transform.localScale = Vector3.zero;
            placedPrefab.transform.DOMoveY(hitPose.position.y + 0.2f, placementAnimDuration)
                .SetEase(placementAnimEase).SetDelay(placementAnimDuration/3f);
            placedPrefab.transform.DOScale(Vector3.one, placementAnimDuration)
                .SetEase(placementAnimEase);

            placedPrefab.transform.SetParent(arObjectsRoot.transform);
            onObjectPlaced?.Invoke(placedPrefab);
        }
    }

}
