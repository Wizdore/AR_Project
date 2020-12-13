using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARShapeObject : MonoBehaviour, IObjectControllable
{
    public float scaleCoeff;

    [SerializeField] private GameObject selectionMarker;
    [SerializeField] private SpriteRenderer shapeObject;

    [HideInInspector] public ObjectState objectState;

    void Awake()
    {
        objectState.scale = 0.5f;
    }

    private void Start()
    {
        objectState.startingPosition = transform.position;
    }

    public ObjectState GetObjectState()
    {
        return objectState;
    }

    public void Select()
    {
        selectionMarker.SetActive(true);
    }

    public void DeSelect()
    {
        selectionMarker.SetActive(false);
    }

    public void ChangeColor(Color color)
    {
        shapeObject.color = color;
        objectState.color = color;
    }

    public void ChangeLift(float lift)
    {
        objectState.lift = lift;

        Vector3 pos = transform.position;
        pos.y = objectState.startingPosition.y + lift;
        transform.position = pos;

    }

    public void ChangeRotation(float rotation)
    {
        objectState.rotation = rotation;

        Vector3 rot = transform.rotation.eulerAngles;
        rot.y = 360 * rotation;
        transform.rotation = Quaternion.Euler(rot);
    }

    public void ChangeScale(float scale)
    {
        objectState.scale = scale;
        Vector3 scl = Vector3.one * scale * scaleCoeff;
        scl.z = 1f;
        transform.localScale = scl;
    }

}

[System.Serializable]
public struct ObjectState {
    public Vector3 startingPosition;
    public Color color;
    public float scale, rotation, lift;
}
