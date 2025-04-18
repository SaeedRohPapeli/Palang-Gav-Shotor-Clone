using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;

public class LevelEditor : EditorWindow
{
    private int gridSizeX = 20;
    private int gridSizeY = 20;
    private float cellSize = 30f;
    private Vector2 scrollPos;
    private Texture2D preview;
    private GameObject[] myPrefabs;
    private int selectedPrefab = -1;
    private int levelsCount = 0;

    [MenuItem("Tools/Level Editor")]
    public static void ShowWindow()
    {
        LevelEditor window = GetWindow<LevelEditor>("Level Editor");

        window.minSize = new Vector2(1000, 700);
        window.maxSize = new Vector2(1000, 700);
    }

    private void OnEnable()
    {
        LoadPrefabs();
    }

    private void OnGUI()
    {
        DrawGrid();

        DrawPrefab(850, 100, 100, 100);

        CreateLevelSO();
    }

    private void DrawGrid()
    {
        Rect gridRect = new Rect(30, 30, gridSizeX * cellSize, gridSizeY * cellSize);
        GUI.Box(gridRect, GUIContent.none);

        for (int y = 0; y < gridSizeY; y++)
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                float xPos = gridRect.x + x * cellSize;
                float yPos = gridRect.y + y * cellSize;
                Rect cellRect = new Rect(xPos, yPos, cellSize, cellSize);

                EditorGUI.DrawRect(cellRect, new Color(0.95f, 0.95f, 0.95f, 1f));
                GUI.Box(cellRect, GUIContent.none);

                if (Event.current.type == EventType.MouseDown && cellRect.Contains(Event.current.mousePosition))
                {
                    Debug.Log($"Clicked on cell {x}, {y}");
                    Event.current.Use();
                }
            }
        }

        Handles.BeginGUI();
        Handles.color = Color.black;

        for (int x = 1; x <= gridSizeX; x++)
        {
            float xPos = gridRect.x + x * cellSize;
            Handles.DrawLine(new Vector3(xPos, gridRect.y), new Vector3(xPos, gridRect.y + gridRect.height));
        }

        for (int y = 1; y <= gridSizeY; y++)
        {
            float yPos = gridRect.y + y * cellSize;
            Handles.DrawLine(new Vector3(gridRect.x, yPos), new Vector3(gridRect.x + gridRect.width, yPos));
        }

        Handles.EndGUI();

    }

    private void DrawButton(int x, int y, int width, int height, string name)
    {
        Rect btnRect = new Rect(x, y, width, height);
        GUI.Button(btnRect, name);
    }

    private void CreateLevelSO()
    {
        Rect newLevelBtn = new Rect(700, 100, 50, 50);
        if(GUI.Button(newLevelBtn, "New Level"))
        {
            LevelSO asset = CreateInstance<LevelSO>();

            string path = "Assets/Levels/";

            string assetPath = AssetDatabase.GenerateUniqueAssetPath(path + $"Level {levelsCount}.asset");

            AssetDatabase.CreateAsset(asset, assetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
            levelsCount++;
            Debug.Log("Created new TileData at " + assetPath);
        }
    }

    private void DrawPrefab(int x, int y, int width, int height)
    {
        Rect scrollViewRect = new Rect(x, y, width, 500); // ناحیه کلی Scroll
        Rect contentRect = new Rect(0, 0, width - 20, myPrefabs.Length * (height + 10)); // فضای محتوا

        scrollPos = GUI.BeginScrollView(scrollViewRect, scrollPos, contentRect);

        for (int i = 0; i < myPrefabs.Length; i++)
        {
            var prefab = myPrefabs[i];
            var preview = AssetPreview.GetAssetPreview(prefab);
            if (preview == null)
            {
                Repaint(); 
                continue;
            }

            float itemY = i * (height + 10); 
            Rect rect = new Rect(0, itemY, width - 20, height);

            if (GUI.Button(rect, GUIContent.none))
            {
                selectedPrefab = i;
                Debug.Log("Selected prefab: " + prefab.name);
            }

            GUI.DrawTexture(rect, preview, ScaleMode.ScaleToFit);

            if (selectedPrefab == i)
            {
                Handles.BeginGUI();
                Color borderColor = new Color(0.2f, 0.5f, 1f, 1f);
                Color fillColor = new Color(0, 0, 0, 0);
                Handles.DrawSolidRectangleWithOutline(rect, fillColor, borderColor);
                Handles.EndGUI();
            }

            Rect labelRect = new Rect(0, itemY + height - 18, width - 20, 18);
            GUI.Label(labelRect, prefab.name, EditorStyles.whiteLabel);
        }

        GUI.EndScrollView();
    }

    private void LoadPrefabs()
    {
        string[] guids = AssetDatabase.FindAssets("t:Prefab", new[] { "Assets/Prefabs" });
        myPrefabs = guids
            .Select(guid => AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(guid)))
            .ToArray();
    }

}
