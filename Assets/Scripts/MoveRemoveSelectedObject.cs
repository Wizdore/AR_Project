using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveRemoveSelectedObject : MonoBehaviour
{
    public Transform currentlySelected;
    public Transform crossHair;

    [SerializeField] private float moveDuration, removeDuration; 
    [SerializeField] private Ease moveAnim, removeAnim;
    public void SetSelectedObject(GameObject obj)
    {
        currentlySelected = obj.transform;
    }

    public void UnSelect()
    {
        currentlySelected = null;
    }

    public void MoveObject()
    {
        if(currentlySelected != null)
        {
            Vector3 newPos = currentlySelected.position;

            newPos.x = crossHair.position.x;
            newPos.z = crossHair.position.z;

            currentlySelected.DOMove(newPos, moveDuration).SetEase(moveAnim);
        }
    }

    public void RemoveObject()
    {
        if (currentlySelected != null)
        {
            currentlySelected.DOScale(Vector3.zero, removeDuration)
                .SetEase(removeAnim);

            Destroy(currentlySelected.gameObject, removeDuration + 0.1f);
            currentlySelected = null;
        }
    }
}
