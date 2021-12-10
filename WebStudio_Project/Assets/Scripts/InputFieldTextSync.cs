using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using TMPro;

[RequireComponent(typeof(TMP_InputField))]
public class InputFieldTextSync : MonoBehaviour
{
    [SerializeField]
    private StringReference _atom;

    private TMP_InputField _inputField;

    private void Awake()
    {
        _inputField = GetComponent<TMP_InputField>();
        _inputField.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(string value)
    {
        _atom.Value = value;
    }
}
