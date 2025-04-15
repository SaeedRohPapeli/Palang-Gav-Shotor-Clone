using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    private static EventHandler _instance;
    public static EventHandler Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }
        else
            Destroy(this);

    }

    public event Action WinLevel;
    public void OnWinLevel()
    {
        if(WinLevel != null)
        {
            WinLevel?.Invoke();
        }
    }
}
