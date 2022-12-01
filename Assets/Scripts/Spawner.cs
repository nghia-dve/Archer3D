using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{

    //private List<GameObject> gameObjects = new List<GameObject>();
    protected virtual GameObject Spawn(string prefabName, Vector3 pos, Quaternion ros)
    {
        GameObject newGameObject = Instantiate(GetPrefabByName(prefabName), pos, ros);
        newGameObject.SetActive(true);
        newGameObject.name = GetPrefabByName(prefabName).name;
        return newGameObject;
    }

    protected virtual GameObject GetPrefabByName(string prefabName)
    {
        return (GameObject)Resources.Load(prefabName);
    }
}
