using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBlockObject : MonoBehaviour
{
    private MazeBlockDefinition mazeBlockDefinition;
    public MazeBlockDefinition BlockDefinition => mazeBlockDefinition;

    public void SetDefinition(MazeBlockDefinition newDefinition)
    {
        mazeBlockDefinition = newDefinition;
    }

}
