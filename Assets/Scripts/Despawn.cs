using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : NghiaMonoBehaviour
{
    protected string currentState;
    protected virtual void FixedUpdate()
    {
        Despawning();
    }
    protected virtual void Despawning()
    {
        if (!CanDespawn()) return;
        DespawnObject();
    }

    protected virtual void DespawnObject() { }
    protected abstract bool CanDespawn();
}
