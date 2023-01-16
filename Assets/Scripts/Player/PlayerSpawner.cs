using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : Spawner
{
    private static PlayerSpawner instance;
    public static PlayerSpawner Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<PlayerSpawner>();
            return instance;
        }
    }
    [SerializeField]
    private CinemachineVirtualCamera camera;

    protected void Start()
    {
        PlayerSpawn();
    }
    private void PlayerSpawn()
    {
        GameObject newGameObject = Spawn(prefabName, pos, Quaternion.identity);
        newGameObject.transform.parent = transform.parent;
        camera.Follow = newGameObject.transform;
        // StartCoroutine(ResetAminator());
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        camera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
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
