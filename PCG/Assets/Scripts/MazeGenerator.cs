using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private List<MazeBlockDefinition> mazeBlockDefinitions;
    [SerializeField] private GameObject border;
    [SerializeField] private GameObject propPrefab;
    [SerializeField] private GameObject propManager;
    [SerializeField] private int mazeWidth;
    [SerializeField] private int mazeHeight;

    private List<MazeBlockObject> mazeBlockObjects;
    // Start is called before the first frame update
    void Start()
    {
        mazeBlockObjects = new List<MazeBlockObject>();
        List<MazeBlockDefinition> possibleBlocks = new List<MazeBlockDefinition>();
        MazeBlockDefinition connectedBlockLeft = null;
        MazeBlockDefinition connectedBlockBottom = null;
        for(int i = -3; i < mazeWidth * 3 + 1 ; i++)
        {
            GameObject gameObject = Instantiate(border, transform);
            gameObject.transform.position = new Vector3(i, 0, -3);

            GameObject gameObject2 = Instantiate(border, transform);
            gameObject2.transform.position = new Vector3(i, 0, 15);
        }
        for(int i = -2; i < mazeHeight * 3; i++)
        {
            GameObject gameObject = Instantiate(border, transform);
            gameObject.transform.position = new Vector3(-3, 0, i);

            GameObject gameObject2 = Instantiate(border, transform);
            gameObject2.transform.position = new Vector3(15, 0, i);
        }
        for(int i = 0; i < mazeHeight; i++)
        {
            possibleBlocks.Clear();
            for (int j = 0; j < mazeWidth; j++)
            {
                if(i > 0)
                {
                    Debug.Log("Index: " + i * mazeWidth + j);
                    connectedBlockBottom = mazeBlockObjects[(i - 1) * mazeWidth + j].BlockDefinition;
                }

                if(connectedBlockBottom != null && connectedBlockLeft != null)
                {
                    possibleBlocks.Clear();
                    foreach(MazeBlockDefinition definition in mazeBlockDefinitions)
                    {
                        if(connectedBlockLeft.connection.HasFlag(Connection.Right) && definition.connection.HasFlag(Connection.Left)
                        && connectedBlockBottom.connection.HasFlag(Connection.Top) && definition.connection.HasFlag(Connection.Bottom))
                        { 
                            possibleBlocks.Add(definition);
                        }
                        if(connectedBlockLeft.connection.HasFlag(Connection.Right) && definition.connection.HasFlag(Connection.Left)
                        && !connectedBlockBottom.connection.HasFlag(Connection.Top) && !definition.connection.HasFlag(Connection.Bottom))
                        { 
                            possibleBlocks.Add(definition);
                        }
                        if(!connectedBlockLeft.connection.HasFlag(Connection.Right) && !definition.connection.HasFlag(Connection.Left)
                        && !connectedBlockBottom.connection.HasFlag(Connection.Top) && !definition.connection.HasFlag(Connection.Bottom))
                        { 
                            possibleBlocks.Add(definition);
                        }
                        if(!connectedBlockLeft.connection.HasFlag(Connection.Right) && !definition.connection.HasFlag(Connection.Left)
                        && connectedBlockBottom.connection.HasFlag(Connection.Top) && definition.connection.HasFlag(Connection.Bottom))
                        { 
                            possibleBlocks.Add(definition);
                        }
                    }
                }
                else if(connectedBlockBottom != null)
                {
                    possibleBlocks.Clear();
                    foreach(MazeBlockDefinition definition in mazeBlockDefinitions)
                    {
                        if(connectedBlockBottom.connection.HasFlag(Connection.Top) && definition.connection.HasFlag(Connection.Bottom))
                        { 
                            possibleBlocks.Add(definition);
                        }
                        else if(!connectedBlockBottom.connection.HasFlag(Connection.Top) && !definition.connection.HasFlag(Connection.Bottom))
                        {
                            possibleBlocks.Add(definition);
                        }
                    }
                }
                else if(connectedBlockLeft != null)
                {
                    possibleBlocks.Clear();
                    foreach(MazeBlockDefinition definition in mazeBlockDefinitions)
                    {
                        if(connectedBlockLeft.connection.HasFlag(Connection.Right) && definition.connection.HasFlag(Connection.Left))
                        { 
                            possibleBlocks.Add(definition);
                        }
                        else if(!connectedBlockLeft.connection.HasFlag(Connection.Right) && !definition.connection.HasFlag(Connection.Left))
                        {
                            possibleBlocks.Add(definition);
                        }
                    }
                }
                if(possibleBlocks.Count > 0)
                {
                    int random  = UnityEngine.Random.Range(0, possibleBlocks.Count);
                    GameObject block = Instantiate(possibleBlocks[random].blockPrefab, transform);
                    block.transform.position = new Vector3(j * 3, 0, i * 3);
                    MazeBlockObject mazeBlockObject = block.AddComponent<MazeBlockObject>();
                    mazeBlockObject.SetDefinition(possibleBlocks[random]);
                    mazeBlockObjects.Add(mazeBlockObject);
                    connectedBlockLeft = possibleBlocks[random];
                    Debug.Log("POSIBBLE COUNT:" + possibleBlocks.Count);
                    Debug.Log("NEW BLOCK: " + block.name);
                }
                else
                {
                    int random  = UnityEngine.Random.Range(0, mazeBlockDefinitions.Count);
                    GameObject block = Instantiate(mazeBlockDefinitions[random].blockPrefab, transform);
                    block.transform.position = new Vector3(j * 3, 0, i * 3);
                    MazeBlockObject mazeBlockObject = block.AddComponent<MazeBlockObject>();
                    mazeBlockObject.SetDefinition(mazeBlockDefinitions[random]);
                    mazeBlockObjects.Add(mazeBlockObject);
                    connectedBlockLeft = mazeBlockDefinitions[random];
                }
            }
        }

        for(int i = 0; i < mazeHeight; i++)
        {
            for (int j = 0; j < mazeWidth; j++)
            {
                int random = UnityEngine.Random.Range(0, 2);
                if(random == 1)
                {
                    GameObject prop = Instantiate(propPrefab, propManager.transform);
                    prop.transform.position = mazeBlockObjects[i * mazeWidth + j].transform.position + new Vector3(0, 0.5f, 0);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
