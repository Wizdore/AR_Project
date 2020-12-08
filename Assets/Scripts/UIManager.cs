using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIDisplayer createButton, editButton, assetPanel, editPanel;

    private void Start()
    {
        BeginMode();
    }
    public void BeginMode()
    {
        editButton.Hide();
        assetPanel.Hide();
        editPanel.Hide();
        createButton.Show();
    }
    public void EditMode()
    {
        createButton.Hide();
        editButton.Hide();
        editPanel.Show();
    }
    public void PlacementMode()
    {
        createButton.Hide();
        assetPanel.Show();
    }
    public void SelectionMode()
    {
        createButton.Hide();
        assetPanel.Hide();
        editPanel.Hide();
        editButton.Show();
    }
}
