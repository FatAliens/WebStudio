using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using DG.Tweening;

[AddComponentMenu("Unity Atoms/UI/ContainerWithTransition")]
public class ContainerWithTransitions : MonoBehaviour, IAtomListener<string>
{
    [SerializeField]
    private StringVariable _currentUIState = null;

    [SerializeField]
    private FloatReference _tranditionDuration = null;

    [SerializeField]
    private List<StringReference> _visibleForStates = null;

    private CanvasGroup _container;

    private void Start()
    {
        _container = GetComponent<CanvasGroup>();
        StateNameChanged(_currentUIState.Value);
    }

    public void OnEventRaised(string stateName)
    {
        StateNameChanged(stateName);
    }

    private void StateNameChanged(string stateName)
    {
        if (_visibleForStates.Exists((state) => state.Value == stateName))
        {
            _container.DOFade(1f, _tranditionDuration.Value);
            _container.blocksRaycasts = true;
            _container.interactable = true;
        }
        else
        {
            _container.DOFade(0f, _tranditionDuration.Value);
            _container.blocksRaycasts = false;
            _container.interactable = false;
        }
    }

    private void Awake()
    {
        if (_currentUIState.Changed != null)
        {
            _currentUIState.Changed.RegisterListener(this);
        }
    }

    private void OnDestroy()
    {
        if (_currentUIState.Changed != null)
        {
            _currentUIState.Changed.UnregisterListener(this);
        }
    }
}
