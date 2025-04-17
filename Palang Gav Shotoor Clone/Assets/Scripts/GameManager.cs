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
    public static List<Touchables> touchables = new List<Touchables>();

    [SerializeField]
    private TouchController touchController;
    [SerializeField]
    private UIController uiController;

    private PLAYMODES playMode;
    public float delay = 0;
    private int levelCnt;
    private bool isWinLevel;

    private void OnEnable()
    {
        if (EventHandler.Instance != null)
            EventHandler.Instance.WinLevel += IsLevelWin;
    }

    private void OnDisable()
    {
        if (EventHandler.Instance != null)
            EventHandler.Instance.WinLevel -= IsLevelWin;
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        playMode = PLAYMODES.START;
    }

    private void Update()
    {
        switch (playMode)
        {
            case PLAYMODES.START:         //For Change Levels and Go to next LEVEL
                StartGame();
                break;
            case PLAYMODES.PLAY:          //For Inputs and Gameplay
                PlayGame();
                break;
            case PLAYMODES.PAUSE:         //In Gameplay when gameplay Stopped
                break;
            case PLAYMODES.WIN:           //Win Level
                WinGame();
                break;
            default:
                break;
        }
    }

    private void StartGame()
    {
        uiController.SetStartLevelUI(true, "LEVEL" + levelCnt);
        if (DelayToPlay(1f))
        {
            playMode = PLAYMODES.PLAY;
        }
    }

    private void PlayGame()
    {
        touchController.Touch();
        touchController.Switch();
        touchController.DoActOfObjects();
        uiController.SetStartLevelUI(false, "LEVEL" + levelCnt);

        if (isWinLevel)
        {
            Debug.Log("Ok");
            playMode = PLAYMODES.WIN;
            isWinLevel = false;
        }
    }

    private void PauseGame()
    {

    }   
    
    private void WinGame()
    {
        Debug.Log("Horraaaaa!!");
        levelCnt++;
        uiController.SetWinUI();
        playMode = PLAYMODES.START;
    }

    public void IsLevelWin()
    {
        isWinLevel = true;
    }

    private bool DelayToPlay(float timeToDo)
    {
        delay += Time.deltaTime;
        if (delay >= timeToDo)
        {
            delay = 0f;
            return true;
        }
        return false;
    }
}
