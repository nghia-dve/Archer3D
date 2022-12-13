using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : Spawner
{
    [SerializeField]
    private int numberSpawn;
    protected override void Start()
    {
        base.Start();
        GroundSpawn();
    }

    private void GroundSpawn()
    {
        for (int i = 0; i < numberSpawn; i++)
        {
            GameObject newGameObject = Spawn(prefab, pos, Quaternion.identity);
            newGameObject.transform.parent = transform;
            pos += new Vector3(0, 0, 20);
        }
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        pos = Vector3.zero;
        prefabName = "Ground";
        numberSpawn = 3;
    }


}
