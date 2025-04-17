using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FEATURE
{
    None,
    R_WALK,
    L_WALK,
    U_WALK,
    D_WALK,
    LASER,
    LAMP,   
    NOTTOUCHED
}

public class TouchController : MonoBehaviour
{
    private Features _features;
    private InputController _inputController;
    private bool _isSwitched;

    public FEATURE _firstTouchableFeature = FEATURE.NOTTOUCHED;
    public FEATURE _lastTouchableFeature = FEATURE.NOTTOUCHED;

    public Touchables _firstTouchable;
    public Touchables _lastTouchable;

    private void Awake()
    {
        _features = new Features();
        _inputController = new InputController();
    }

    private void Start()
    {
        _firstTouchableFeature = FEATURE.NOTTOUCHED;
        _lastTouchableFeature = FEATURE.NOTTOUCHED;
    }

    public void Switch()
    {
        if (!_isSwitched)
            SwitchFeatures();
    }

    public void DoActOfObjects()
    {
        foreach (var item in GameManager.touchables)
        {
            DoJob(item);
        }
    }

    public void Touch()
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
            case FEATURE.U_WALK:
                _features.Move(t.gameObject.transform, Vector3.up, t.speed);
                break;
            case FEATURE.D_WALK:
                _features.Move(t.gameObject.transform, Vector3.down, t.speed);
                break;
            case FEATURE.LASER:
                break;
        }
    }
}
