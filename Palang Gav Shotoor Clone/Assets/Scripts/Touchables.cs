using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Touchables : MonoBehaviour, ITouchable
{
    public FEATURE feature;
    public float speed;

    private void OnEnable()
    {
        if(this != null && !TouchController.touchables.Contains(this))
            TouchController.touchables.Add(this);
    }

    private void OnDestroy()
    {
        if(this != null && TouchController.touchables.Contains(this))
            TouchController.touchables.Remove(this);
    }

    public FEATURE GetFeatureType()
    {
        return feature;
    }

    public void SetFeatureType(FEATURE f)
    {
        feature = f;
    }

    public void OnClick()
    {
        Debug.Log("Clicked on " + this.gameObject.name);
    }

}
