using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : NghiaMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameCtrl>();
            return instance;
        }
    }

    [Header("path")]
    [SerializeField]
    private string EnemyPath;
    [SerializeField]
    private string playerPath;
    [SerializeField]
    private string wordPath;

    private bool isAttack;
    public bool IsAttack { get { return isAttack; } }

    private List<LoadPrefab> listPrefabs = new List<LoadPrefab>();
    public List<LoadPrefab> ListPrefabs { get { return listPrefabs; } }

    private void Awake()
    {
        listPrefabs.Clear();
        GetListPrefabByName(listPrefabs, playerPath);
        GetListPrefabByName(listPrefabs, EnemyPath);
        GetListPrefabByName(listPrefabs, wordPath);
    }

    protected virtual void GetListPrefabByName(List<LoadPrefab> listFrefab, string pathFrefab)
    {
        var list = Resources.LoadAll(pathFrefab);
        foreach (var item in list)
        {
            listFrefab.Add((LoadPrefab)item);
        }
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        EnemyPath = "Enemy";
        playerPath = "Player";
        wordPath = "Word/Ground";
    }

    public void Attack()
    {
        isAttack = true;
    }

    public void NotAttack()
    {
        isAttack = false;
    }
}
