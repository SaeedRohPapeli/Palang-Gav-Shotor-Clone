using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYMODES
{
    START,
    PLAY,
    PAUSE,
    WIN,
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private InputController controller;
    [SerializeField]
    private UIController uiController;

    private PLAYMODES playMode;

    private void OnEnable()
    {
        if (EventHandler.Instance != null)
            EventHandler.Instance.onIsWinLevel += IsWinLevel;
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        switch (playMode)
        {
            case PLAYMODES.START:         //For Change Levels and Go to next LEVEL
                break;
            case PLAYMODES.PLAY:          //For Inputs and Gameplay
                break;
            case PLAYMODES.PAUSE:         //In Gameplay when gameplay Stopped
                break;
            case PLAYMODES.WIN:           //Win Level
                break;
            default:
                break;
        }
    }

    private void LateUpdate()
    {
        
    }

    private void OnDisable()
    {
        if (EventHandler.Instance != null)
            EventHandler.Instance.onIsWinLevel -= IsWinLevel;
    }

    public bool IsWinLevel()
    {
        Debug.Log("Horraaaaa!!");
        return true;
    }
}
