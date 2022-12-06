using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

public class EnemySpawner : Spawner
{
    [SerializeField]
    private Vector3 pos;

    [SerializeField]
    private string EnemyPath;

    [SerializeField]
    private float randomX = 4;
    [SerializeField]
    private float randomZ = 14;

    private List<GameObject> listEnemy = new List<GameObject>();

    #region test


    #endregion

    private TransformAccessArray transformAccessArray = new TransformAccessArray();

    private void Awake()
    {
        PlayerSpawn();
    }
    private void PlayerSpawn()
    {
        GameObject newGameObject = Spawn(EnemyPath, pos, Quaternion.identity);
        newGameObject.transform.parent = EnemyCtrl.Instance.Model.transform;
        listEnemy.Add(newGameObject);

        //transformAccessArray.Add(newGameObject.transform);
        //StartCoroutine(ResetAminator());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 1000; i++)
            {
                pos = new Vector3(UnityEngine.Random.Range(-randomX, randomX), pos.y, UnityEngine.Random.Range(-randomZ, randomZ));
                PlayerSpawn();
            }

        }
        Jobs(listEnemy, transformAccessArray);

    }



    public IEnumerator ResetAminator()
    {
        GameObject gameObject = EnemyCtrl.Instance.Model;

        gameObject.SetActive(false);
        yield return new WaitForSeconds(0.00f);
        gameObject.SetActive(true);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        pos = Vector3.zero;
        EnemyPath = "Enemy/BatPBR";
    }



}
