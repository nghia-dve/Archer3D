using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<PlayerCtrl>();
            return instance;
        }
    }
    [SerializeField]
    private Animator animator;
    public Animator Animator { get { return animator; } }

    [SerializeField]
    private GameObject model;
    public GameObject Model { get { return model; } }

    private void Reset()
    {
        LoadComponent();
    }
    private void LoadComponent()
    {
        animator = GameObject.Find("Model").GetComponent<Animator>();
        model = GameObject.Find("Model");

    }

}
