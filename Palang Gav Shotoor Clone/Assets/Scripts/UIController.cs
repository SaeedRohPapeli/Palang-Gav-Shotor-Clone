using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject winUI;
    [SerializeField]
    private GameObject startLevelUI;
    [SerializeField]
    private Text levelText;

    public void SetWinUI()
    {
        winUI.SetActive(true);
    }

    public void SetStartLevelUI(bool isActive, string levelName)
    {
        if(winUI.activeInHierarchy)
            winUI.SetActive (false);
        levelText.text = levelName;
        startLevelUI.SetActive (isActive);
    }
}
