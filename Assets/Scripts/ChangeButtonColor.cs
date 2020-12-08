using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColor : MonoBehaviour
{
    private Button button;

    void Awake()
    {
        button = gameObject.GetComponent<Button>();
        Debug.Log(button.name);
    }

    public void ChangeColor(Color color)
    {
        var colors = button.colors;
        colors.normalColor = color;
        colors.selectedColor = color;
        button.colors = colors;
    }

}
