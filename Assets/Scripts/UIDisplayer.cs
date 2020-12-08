using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class UIDisplayer : MonoBehaviour
{
    [SerializeField] private float showingPos, hidingPos, duration = 1f, delay = 0f;
    [SerializeField] private Ease animShow, animHide;
    enum Direction {vertical, horizontal};
    [SerializeField] private Direction moveDirection;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Show()
    {
        if(moveDirection == Direction.horizontal)
            rectTransform.DOAnchorPosX(showingPos, duration, snapping: true)
                .SetDelay(delay)
                .SetEase(animShow);
        else
            rectTransform.DOAnchorPosY(showingPos, duration, snapping: true)
                .SetDelay(delay)
                .SetEase(animShow);
    }
    public void Hide()
    {
        if (moveDirection == Direction.horizontal)
            rectTransform.DOAnchorPosX(hidingPos, duration, snapping: true)
                .SetDelay(delay)
                .SetEase(animHide);
        else
            rectTransform.DOAnchorPosY(hidingPos, duration, snapping: true)
                .SetDelay(delay)
                .SetEase(animHide);
    }

}
