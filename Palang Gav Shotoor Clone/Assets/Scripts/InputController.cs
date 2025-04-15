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
            Vector3 mouseScreenPos = Input.mousePosition;

            mouseScreenPos.z = Mathf.Abs(Camera.main.transform.position.z); // „À·« 10

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            Vector2 mousePos2D = new Vector2(mouseWorldPos.x, mouseWorldPos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("This is");
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
