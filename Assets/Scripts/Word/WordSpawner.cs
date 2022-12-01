using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : Spawner
{
    [SerializeField]
    private Vector3 pos;

    [SerializeField]
    private string groundPath;

    [SerializeField]
    private int numberSpawn;

    private void Reset()
    {
        ResetValue();
    }
    private void Awake()
    {
        WordSpawn();
    }

    private void WordSpawn()
    {
        for (int i = 0; i < numberSpawn; i++)
        {
            GameObject newGameObject = Spawn(groundPath, pos, Quaternion.identity);
            newGameObject.transform.parent = transform;
            pos += new Vector3(0, 0, 20);
        }
    }

    private void ResetValue()
    {
        pos = Vector3.zero;
        groundPath = "Word/Ground";
        numberSpawn = 3;
    }
}
