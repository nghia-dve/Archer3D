using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    private static EnemyCtrl instance;
    public static EnemyCtrl Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<EnemyCtrl>();
            return instance;
        }
    }

    [SerializeField]
    private GameObject model;

    public GameObject Model { get { return model; } }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
