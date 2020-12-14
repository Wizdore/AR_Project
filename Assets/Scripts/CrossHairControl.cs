using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class CrossHairControl : MonoBehaviour
{
    [SerializeField] Transform crossHairGraphic;

    bool isCrossfireActive = false;


    private ARRaycastManager arRaycastManager;
    private Vector2 raycastOrigin;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public void SetCrossFireOnUIMode(UIMode mode)
    {
        if (mode == UIMode.placement || mode == UIMode.selection)
        {
            isCrossfireActive = true;
            crossHairGraphic.gameObject.SetActive(true);
        }
        else
        {
            isCrossfireActive = false;
            crossHairGraphic.gameObject.SetActive(false);
        }
    }

    void Awake()
    {
        raycastOrigin = new Vector2(Screen.width / 2f, Screen.height / 2f);
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (!isCrossfireActive)
            return;

        if (arRaycastManager.Raycast(raycastOrigin, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            crossHairGraphic.position = hits[0].pose.position;
        }
    }
}
