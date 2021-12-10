using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityAtoms.MonoHooks;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[AddComponentMenu("Unity Atoms/Hooks/ClickHookWithInt")]
public class ClickHookWithInt : MonoHook<IntEvent, int, IntEventReference, UnityAtoms.MonoHooks.GameObjectGameObjectFunction>
{
    [SerializeField]
    private IntReference _value;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        OnHook(_value.Value);
    }

    protected override void RaiseWithGameObject(int value, GameObject gameObject)
    {
        Debug.Log("RaiseWithGameObject is impthy!");
    }
}
