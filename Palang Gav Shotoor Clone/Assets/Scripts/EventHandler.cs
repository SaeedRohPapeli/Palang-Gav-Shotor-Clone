using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    private static EventHandler _instance;
    public static EventHandler Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);

    }

    public delegate bool IsWinLevel();
    public event IsWinLevel onIsWinLevel;
    public void OnIsWinLevel()
    {
        if(onIsWinLevel != null)
        {
            onIsWinLevel?.Invoke();
        }
    }
}
