using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Checkbox : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private BoolReference _checked;
    [SerializeField]
    private Sprite _checkedSprite;
    [SerializeField]
    private Sprite _uncheckedSprite;

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
            _imageBox.sprite = _checkedSprite;
        }
        else
        {
            _imageBox.sprite = _uncheckedSprite;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _checked.Value = !_checked.Value;
    }
}
