using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Level", menuName ="Level")]
public class LevelSO : ScriptableObject
{
    public Vector3[] walls;
    public Vector3[] waters;

    public Vector3[] touchables;
}
