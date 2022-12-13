using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : Spawner
{

    protected override void Start()
    {
        base.Start();
        PlayerSpawn();
    }
    private void PlayerSpawn()
    {
        GameObject newGameObject = Spawn(prefab, pos, Quaternion.identity);
        newGameObject.transform.parent = transform.parent;

        // StartCoroutine(ResetAminator());
    }


    protected override void ResetValue()
    {
        base.ResetValue();
        pos = Vector3.zero;
        prefabName = "Player";

    }
    //public IEnumerator ResetAminator()
    //{
    //    GameObject gameObject = PlayerCtrl.Instance.Model;

    //    gameObject.SetActive(false);
    //    yield return new WaitForSeconds(0.00f);
    //    gameObject.SetActive(true);
    //}
}
