using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FEATURE
{
    None,
    R_WALK,
    L_WALK,
    LASER,
    NOTTOUCHED
}

public class TouchController : MonoBehaviour
{
    public static List<Touchables> touchables = new List<Touchables>();

    private Features _features;
    private InputController _inputController;
    private bool _isSwitched;

    public FEATURE _firstTouchableFeature = FEATURE.NOTTOUCHED;
    public FEATURE _lastTouchableFeature = FEATURE.NOTTOUCHED;

    public ITouchable _firstTouchable;
    public ITouchable _lastTouchable;

    private void Awake()
    {
        _features = new Features();
        _inputController = new InputController();
    }

    private void Update()
    {
        Touch();

        if (!_isSwitched)
            SwitchFeatures();
    }

    private void LateUpdate()
    {
        foreach (var item in touchables)
        {
            DoJob(item);
        }
    }

    private void Touch()
    {
        _inputController.Touch();
        if (_firstTouchableFeature == FEATURE.NOTTOUCHED)
        {
            _isSwitched = false;

            _firstTouchable = _inputController.GetTouchedObjectFeature();
            if (_firstTouchable != null)
                _firstTouchableFeature = _firstTouchable.GetFeatureType();
        }
        else if (_lastTouchableFeature == FEATURE.NOTTOUCHED)
        {
            _lastTouchable = _inputController.GetTouchedObjectFeature();
            if (_lastTouchable != null)
                _lastTouchableFeature = _lastTouchable.GetFeatureType();
        }
    }

    private void SwitchFeatures()
    {
        if (_firstTouchable != null && _lastTouchable != null && !_isSwitched)
        {
            Debug.Log("Switch Switch");
           _firstTouchable.SetFeatureType(_lastTouchableFeature);
           _lastTouchable.SetFeatureType(_firstTouchableFeature);

            _firstTouchable = null;
            _lastTouchable = null;

            _firstTouchableFeature = FEATURE.NOTTOUCHED;
            _lastTouchableFeature = FEATURE.NOTTOUCHED;
            
            _isSwitched = true;
        }

    }

    private void DoJob(Touchables t)
    {
        switch(t.feature)
        {
            case FEATURE.R_WALK:
                _features.Move(t.gameObject.transform, Vector3.right, t.speed);
                break;
            case FEATURE.L_WALK:
                _features.Move(t.gameObject.transform, Vector3.left, t.speed);
                break;
            case FEATURE.LASER:
                break;
        }
    }
}
