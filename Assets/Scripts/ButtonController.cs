using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IObjectControllable
{
    [SerializeField] private float maxLift;

    Button button;
    public void ChangeColor(Color color)
    {
        if(button == null)
            button = GetComponent<Button>();

        var colors = button.colors;
        colors.selectedColor = color;
        colors.normalColor = color;
        button.colors = colors;
    }

    public void ChangeLift(float lift)
    {
        Vector3 pos = transform.position;
        if(pos.y <= maxLift)
        {
            pos.y = (lift * maxLift);
            transform.position = pos;
        }
    }

    public void ChangeRotation(float rotation)
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rot.z = (rotation*360);
        transform.rotation = Quaternion.Euler(rot);
    }

    public void ChangeScale(float scale)
    {
        transform.localScale = Vector3.one * scale * 2f;
    }
}
