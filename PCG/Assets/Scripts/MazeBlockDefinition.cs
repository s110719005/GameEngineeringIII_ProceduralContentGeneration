using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MazeBlockDefinition", menuName = "Create MazeBlock Definition")]
public class MazeBlockDefinition : ScriptableObject
{
    public GameObject blockPrefab;
    public Connection connection;
    public bool isDeadEnd;
}

[Flags] public enum Connection
{
    None = 0,
    Top = 1 << 0,
    Right = 1 << 1,
    Left = 1 << 2,
    Bottom = 1 << 3
}
