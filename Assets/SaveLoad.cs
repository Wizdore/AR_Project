using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SaveLoad : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectToSave;
    [SerializeField] private GameObject savenameInputField;

    public void Save()
    {
        string savename = savenameInputField.GetComponent<TMP_InputField>().text;
    }
}
