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
    private new CinemachineFreeLook camera;

    protected void Start()
    {
        PlayerSpawn();
    }
    private void PlayerSpawn()
    {
        GameObject newGameObject = Spawn(prefabName, pos, Quaternion.identity);
        newGameObject.transform.parent = transform.parent;
        camera.Follow = newGameObject.transform;
        camera.LookAt = newGameObject.GetComponent<PlayerCtrl>().CameraLookAt.transform;
        // StartCoroutine(ResetAminator());
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        camera = GameObject.Find("ThirdPersonCamera").GetComponent<CinemachineFreeLook>();
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
