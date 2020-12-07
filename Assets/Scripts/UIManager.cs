using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform assetPanel, createButton;
    [SerializeField] private RectTransform controlsPanel, editPanel;

    public void ShowControlPanel(int panelNumber)
    {
        controlsPanel.DOAnchorPosX(-(panelNumber-1) * 1132f, 0.5f, snapping:true)
            .SetEase(Ease.InOutSine);
    }
    
    public void ShowCreateButton()
    {
        createButton
            .DOAnchorPosX(-50f, 0.3f)
            .SetEase(Ease.OutElastic);
    }
    
    public void HideCreateButton()
    {
        createButton
            .DOAnchorPosX(160f, 0.3f)
            .SetEase(Ease.InElastic);
    }
    
    public void ShowAssetPanel()
    {
        assetPanel
            .DOAnchorPosY(-130f, 0.6f)
            .SetEase(Ease.OutElastic);
    }
    public void HideAssetPanel()
    {
        assetPanel
            .DOAnchorPosY(-550f, 0.6f)
            .SetEase(Ease.InElastic);
    }
    public void ShowEditPanel()
    {
        editPanel
            .DOAnchorPosY(-130f, 0.6f)
            .SetEase(Ease.OutElastic);
    }
    public void HideEditPanel()
    {
        editPanel
            .DOAnchorPosY(-550f, 0.6f)
            .SetEase(Ease.InElastic);
        
    }
}
