using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ControlPanelManager : MonoBehaviour
{
    [SerializeField] private RectTransform controlsPanel;
    [SerializeField] private float duration, delay;
    [SerializeField] private Ease animEase;

    public void ShowPanel(int panelNo)
    {
        controlsPanel.DOAnchorPosX(-(panelNo-1)*1100f, duration, snapping: true)
            .SetDelay(delay)
            .SetEase(animEase);
    }
}
