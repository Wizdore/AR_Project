using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ShapeFactory : MonoBehaviour
{
    [SerializeField] private RectTransform buttonHolder;
    [SerializeField] private GameObject shapeSelectorButton;

    [SerializeField] public Sprite[] shapeSprites;
    [SerializeField] private GameObject basePrefab, baseTextPrefab;

    [SerializeField] private string newTextString;

    [SerializeField] UnityEvent<GameObject> onObjectCreated;

    public void SetNewTextString(string txt) => newTextString = txt;

    public void CreateobejctFromSprite(int spriteIdx)
    {
        GameObject obj = Instantiate(basePrefab);
        obj.GetComponentInChildren<SpriteRenderer>().sprite = shapeSprites[spriteIdx];

        onObjectCreated?.Invoke(obj);
    }

    public void CreateobjectFromText()
    {
        GameObject obj = Instantiate(baseTextPrefab);
        obj.GetComponentInChildren<ARTextObject>().ChangeText(newTextString);

        onObjectCreated?.Invoke(obj);
    }

    private void Awake()
    {
        int i = 0;
        foreach (Sprite sprite in shapeSprites)
        {
            GameObject obj = Instantiate(shapeSelectorButton);
            obj.transform.GetChild(0).GetComponent<Image>().sprite = sprite;
            obj.transform.SetParent(buttonHolder);

            obj.transform.localScale = Vector3.one;

            int btnidx = i;
            obj.GetComponent<Button>().onClick.AddListener(() => CreateobejctFromSprite(btnidx));
            i++;
        }
    }
}
