using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public abstract class Spawner : NghiaMonoBehaviour
{
    [SerializeField]
    protected Vector3 pos;

    [SerializeField]
    protected string prefabName;
    protected GameObject prefab;

    protected TransformAccessArray transformAccessArray = new TransformAccessArray();
    //private List<GameObject> gameObjects = new List<GameObject>();
    protected virtual void Start()
    {
        GetPrefabByName();
    }
    protected virtual GameObject Spawn(GameObject frefab, Vector3 pos, Quaternion ros)
    {
        GameObject newGameObject = Instantiate(frefab, pos, ros);
        newGameObject.SetActive(true);
        newGameObject.name = frefab.name;
        return newGameObject;
    }

    protected virtual void GetPrefabByName()
    {
        foreach (var item in GameCtrl.Instance.ListModelPrefabs)
        {
            if (item.name == prefabName)
            {
                prefab = item.model;
            }
        }
    }
}
