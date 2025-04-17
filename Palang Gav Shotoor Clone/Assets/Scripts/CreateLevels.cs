using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevels : MonoBehaviour
{
    [SerializeField]
    List<LevelSO> levels;

    [SerializeField]
    GameObject wallPrefab;
    [SerializeField]
    GameObject waterPrefab;
    [SerializeField]
    GameObject floor;

    [SerializeField]
    Dictionary<Vector2, GameObject> touchableGOs;

    private bool isCreated;
    private bool isWallsCreated;
    private bool isRiverCreated;
    private int i;

    public void CreateCurrentLevel(int currentLevel)
    {
        if (isCreated)
            return;

        if(!isWallsCreated)
        {
            CreateWalls(currentLevel);
        }
        else if (!isRiverCreated)
        {
            CreateWaters(currentLevel);
        }

        if(isRiverCreated)
            isCreated = true;  
    }

    public void CreateWalls(int currentLevel)
    {
        for (i = 0; i < levels[currentLevel].walls.Length; i++)
        {
            var wall = levels[currentLevel].walls[i];
            Instantiate(wallPrefab, wall, Quaternion.identity);
        }
        if (i >= levels[currentLevel].walls.Length)
        {
            isWallsCreated = true;
            i = 0;
        }
    }

    public void CreateWaters(int currentLevel)
    {
        for (i = 0; i < levels[currentLevel].waters.Length; i++)
        {
            var water = levels[currentLevel].waters[i];
            Instantiate(waterPrefab, water, Quaternion.identity);
        }

        if (i >= levels[currentLevel].waters.Length)
        {
            isRiverCreated = true;
            i = 0;
        }
    }

    public void CreateTouchables()
    {

    }
}
