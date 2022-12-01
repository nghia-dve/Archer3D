using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : Spawner
{
    [SerializeField]
    private Vector3 pos;

    [SerializeField]
    private string playerPath;

    private void Reset()
    {
        ResetValue();
    }
    private void Awake()
    {
        PlayerSpawn();
    }
    private void Start()
    {

    }
    private void Update()
    {

    }

    private void PlayerSpawn()
    {
        GameObject newGameObject = Spawn(playerPath, pos, Quaternion.identity);
        newGameObject.transform.parent = PlayerCtrl.Instance.Model.transform;
        StartCoroutine(ResetAminator());
    }

    private void ResetValue()
    {
        pos = Vector3.zero;
        playerPath = "Player/PlayerBasic";
    }

    public IEnumerator ResetAminator()
    {
        GameObject gameObject = PlayerCtrl.Instance.Model;
        //PlayerCtrl.Instance.Animator.enabled = false;
        gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(true);
        // PlayerCtrl.Instance.Animator.enabled = true;
    }



}
