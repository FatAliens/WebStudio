using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorSwitcher : MonoBehaviour
{
    [SerializeField]
    private BoolReference _checked;
    [SerializeField]
    private Color _checkedColor;
    [SerializeField]
    private Color _uncheckedColor;

    private Image _imageBox;

    private void Awake()
    {
        _imageBox = GetComponent<Image>();
    }

    private void Start()
    {
        OnValueChanged();
    }

    public void OnValueChanged()
    {
        if (_checked.Value)
        {
            _imageBox.color = _checkedColor;
        }
        else
        {
            _imageBox.color = _uncheckedColor;
        }
    }
}
