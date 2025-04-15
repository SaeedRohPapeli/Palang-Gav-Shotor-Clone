using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchable
{
    public void OnClick();

    public FEATURE GetFeatureType();
    public void SetFeatureType(FEATURE f);
}
