using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class InputController
{
    private Touchables _touchable;
    private bool _isTouched;
    private Touchables _firstTouchable;
    private Touchables  _secondTouchable;


    public void Touch()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if(hit.collider != null)
            {
                Touchables touchable = hit.collider.GetComponent<Touchables>();
                if(touchable != null)
                {
                    _isTouched = true;
                    _touchable = touchable;
                }
            }
        }
    }

    public Touchables GetTouchedObjectFeature()
    {
        if(_isTouched)
        {
            _isTouched = false;
            return _touchable;
        }
        return null;
    }
}
