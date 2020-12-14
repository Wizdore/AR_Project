using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ARTextObject : MonoBehaviour, IObjectControllable
{
    public TextMeshPro text;
    [HideInInspector] public ObjectState objectState;
    public float scaleCoeff;

    public void ChangeColor(Color color)
    {
        objectState.color = color;
        text.color = color;
    }
    public void ChangeText(string txt)
    {
        text.text = txt;
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

    public void DeSelect()
    {
        text.fontMaterial.DisableKeyword("UNDERLAY_ON");
    }

    public ObjectState GetObjectState()
    {
        return objectState;
    }

    public void Select()
    {
        text.fontMaterial.EnableKeyword("UNDERLAY_ON");
    }

    public void SetObjectState(ObjectState objstate)
    {
        objectState = objstate;
    }
}
