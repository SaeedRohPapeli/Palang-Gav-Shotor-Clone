using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Touchables : MonoBehaviour
{
    public Vector2 direction;
    public FEATURE feature;
    public float speed;
    private bool isColliderEnter = false;

    private void OnEnable()
    {
        if(this != null && !GameManager.touchables.Contains(this))
            GameManager.touchables.Add(this);
    }

    private void OnDestroy()
    {
        if(this != null && GameManager.touchables.Contains(this))
            GameManager.touchables.Remove(this);
    }

    public FEATURE GetFeatureType()
    {
        return feature;
    }

    public void SetFeatureType(FEATURE f)
    {
        feature = f;
    }

    public void ChangeActOnCollision(Collider2D collision)
    {
        if (feature == FEATURE.R_WALK)
        {
            feature = FEATURE.L_WALK;
        }
        else if (feature == FEATURE.L_WALK)
        {
            feature = FEATURE.R_WALK;
        }
        else if (feature == FEATURE.U_WALK)
        {
            feature = FEATURE.D_WALK;

        }
        else if (feature == FEATURE.D_WALK)
        {
            feature = FEATURE.U_WALK;
        }
        Debug.Log("feature is " + feature.ToString());
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Destroyer" && collision.tag != "Green" && !isColliderEnter)
        {
            ChangeActOnCollision(collision);
            isColliderEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliderEnter = false;
    }

}
