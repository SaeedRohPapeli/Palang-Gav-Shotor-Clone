using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCube : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Green")
        {
            EventHandler.Instance.OnWinLevel();
        }
    }
}
