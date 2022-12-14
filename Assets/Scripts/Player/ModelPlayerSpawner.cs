using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelPlayerSpawner : Spawner
{
    private static ModelPlayerSpawner instance;
    public static ModelPlayerSpawner Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<ModelPlayerSpawner>();
            return instance;
        }
    }
}
