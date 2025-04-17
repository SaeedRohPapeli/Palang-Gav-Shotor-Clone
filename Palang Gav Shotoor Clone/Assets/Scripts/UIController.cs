using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject winUI;
    [SerializeField]
    private GameObject startLevelUI;

    public void SetWinUI()
    {
        winUI.SetActive(true);
    }

    public void SetStartLevelUI(bool isActive, string levelName)
    {
        if(winUI.activeInHierarchy)
        {
            winUI.SetActive (false);
        }

        startLevelUI.SetActive (isActive);
    }
}
