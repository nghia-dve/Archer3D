using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelPlayerDespawn : DespawnByChangeAnim
{
    protected override void Despawning()
    {
        var lisPrefabs = ModelPlayerSpawner.Instance.ListPrefabs;
        if (lisPrefabs.Count <= 1) return;
        ModelPlayerSpawner.Instance.Despawn(lisPrefabs[0]);
        lisPrefabs.Remove(lisPrefabs[0]);
    }

}
