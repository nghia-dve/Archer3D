using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public abstract class Spawner : NghiaMonoBehaviour
{
    [SerializeField]
    protected Vector3 pos;
    //protected GameObject prefab;
    [SerializeField]
    protected string prefabName;
    [SerializeField]
    protected List<GameObject> listPrefabs = new List<GameObject>();
    public List<GameObject> ListPrefabs { get { return listPrefabs; } }

    protected List<GameObject> listPoolObjs = new List<GameObject>();

    protected TransformAccessArray transformAccessArray = new TransformAccessArray();
    //private List<GameObject> gameObjects = new List<GameObject>();
    public virtual GameObject Spawn(string prefabName, Vector3 pos, Quaternion ros)
    {
        GameObject gameObject = GetPrefabByName(prefabName);
        GameObject newGameObject = GetObjectFromPool(gameObject);
        newGameObject.transform.SetPositionAndRotation(pos, ros);
        newGameObject.SetActive(true);
        newGameObject.name = prefabName;
        listPrefabs.Add(newGameObject);
        return newGameObject;
    }

    public virtual GameObject GetPrefabByName(string prefabName)
    {
        foreach (var item in GameCtrl.Instance.ListPrefabs)
        {
            if (item.name == prefabName)
            {
                return item.model;
            }
        }
        return null;
    }

    public virtual void Despawn(GameObject gameObject)
    {
        listPoolObjs.Add(gameObject);
        gameObject.SetActive(false);
    }
    protected virtual GameObject GetObjectFromPool(GameObject gameObject)
    {
        foreach (var item in listPoolObjs)
        {
            if (item.name == gameObject.name)
            {
                listPoolObjs.Remove(item);
                return item;
            }
        }
        GameObject newGameObject = Instantiate(gameObject);
        newGameObject.name = gameObject.name;
        return newGameObject;
    }
}
