using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : Spawner
{
    [SerializeField]
    private Vector3 pos;

    [SerializeField]
    private string playerPath;

    private void Awake()
    {
        PlayerSpawn();
    }
    private void PlayerSpawn()
    {
        GameObject newGameObject = Spawn(playerPath, pos, Quaternion.identity);
        newGameObject.transform.parent = PlayerCtrl.Instance.Model.transform;
        StartCoroutine(ResetAminator());
    }

    protected override void ResetValue()
    {
        pos = Vector3.zero;
        playerPath = "Player/PlayerBasic";
    }

    public IEnumerator ResetAminator()
    {
        GameObject gameObject = PlayerCtrl.Instance.Model;

        gameObject.SetActive(false);
        yield return new WaitForSeconds(0.00f);
        gameObject.SetActive(true);
    }
}
