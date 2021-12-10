using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;

[RequireComponent(typeof(TMP_Text))]
public class SyncStringText : MonoBehaviour
{
    [SerializeField]
    private StringReference _string;

    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();

        if (_string != null)
        {
            ValueChanged(_string.Value);
        }
    }

    private void ValueChanged(string value)
    {
        _text.text = value;
    }

    private void OnDisable()
    {
        
    }
}
