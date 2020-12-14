using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeFactory : MonoBehaviour
{
    [SerializeField] private RectTransform buttonHolder;
    [SerializeField] private GameObject shapeSelectorButton;

    [SerializeField] public Sprite[] shapeSprites;
    [SerializeField] private GameObject basePrefab;

    int selectedShapeIdx;

    public void SetselectedShapeIdx(int idx) => selectedShapeIdx = idx;

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
            obj.GetComponent<Button>().onClick.AddListener(() => SetselectedShapeIdx(btnidx));
            i++;
        }
    }

    public GameObject GetShapeObect(Vector3 pos, Quaternion rot)
    {
        GameObject obj = Instantiate(basePrefab, pos, rot);

        obj.GetComponentInChildren<SpriteRenderer>().sprite = shapeSprites[selectedShapeIdx];

        return obj;
    }
}
