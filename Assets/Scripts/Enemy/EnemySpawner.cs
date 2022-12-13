using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class EnemySpawner : Spawner
{

    [SerializeField]
    private float randomX = 4;
    [SerializeField]
    private float randomZ = 14;

    private List<GameObject> listEnemy = new List<GameObject>();

    protected override void Start()
    {
        base.Start();
        PlayerSpawn();
    }
    private void PlayerSpawn()
    {
        GameObject newGameObject = Spawn(prefab, pos, Quaternion.identity);
        newGameObject.transform.parent = transform.parent;
        listEnemy.Add(newGameObject);

        //transformAccessArray.Add(newGameObject.transform);
        //StartCoroutine(ResetAminator());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 1; i++)
            {
                pos = new Vector3(UnityEngine.Random.Range(-randomX, randomX), pos.y, UnityEngine.Random.Range(-randomZ, randomZ));
                PlayerSpawn();
            }
        }
        Jobs(listEnemy, transformAccessArray);

    }
    //public IEnumerator ResetAminator()
    //{
    //    GameObject gameObject = EnemyCtrl.Instance.Model;

    //    gameObject.SetActive(false);
    //    yield return new WaitForSeconds(0.00f);
    //    gameObject.SetActive(true);
    //}

    protected override void ResetValue()
    {
        base.ResetValue();
        pos = Vector3.zero;
        prefabName = "BatPBR";

    }
}
