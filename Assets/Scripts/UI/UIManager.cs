using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIDisplayer createButton, editButton, assetPanel, editPanel;

    public UnityEvent<UIMode> OnUIModeChange;

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

        OnUIModeChange?.Invoke(UIMode.begin);
    }
    public void EditMode()
    {
        createButton.Hide();
        editButton.Hide();
        editPanel.Show();

        OnUIModeChange?.Invoke(UIMode.edit);
    }
    public void PlacementMode()
    {
        createButton.Hide();
        assetPanel.Show();

        OnUIModeChange?.Invoke(UIMode.placement);
    }
    public void SelectionMode()
    {
        createButton.Hide();
        assetPanel.Hide();
        editPanel.Hide();
        editButton.Show();

        OnUIModeChange?.Invoke(UIMode.selection);
    }
}

public enum UIMode { begin, edit, placement, selection};