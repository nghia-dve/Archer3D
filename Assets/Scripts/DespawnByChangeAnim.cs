using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByChangeAnim : Despawn
{
    protected override bool CanDespawn()
    {
        return true;
    }

    protected override void DespawnObject()
    {

    }
}
