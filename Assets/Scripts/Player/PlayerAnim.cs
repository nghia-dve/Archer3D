using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.EventSystems;

public class PlayerAnim : NghiaMonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private PlayerCtrl playerCtrl;

    private string currentState;
    public string CurrentState { get { return currentState; } }

    protected bool isRun;
    public bool IsRun { get { return isRun; } }

    private bool isExitState = true;
    public bool IsExitState { get { return isExitState; } }

    private float runSpeed;

    const string animRun = "Run";
    const string animMove = "Move";
    const string animSingleTwohandSwordAttack = "Sword_L";

    private void Start()
    {

    }
    private void Update()
    {
        Run();
        SingleTwohandSwordAttack();
    }

    private void Run()
    {
        if (Mathf.Abs(InputManager.Instance.Direction.magnitude) == 0 && runSpeed != 0)
        {
            animator.SetFloat(animMove, 0);
            runSpeed = 0;
        }
        if (playerCtrl.PlayerAttack.IsAttack || !isExitState) return;
        ChangeCurrentState(animRun);
        if (Mathf.Abs(InputManager.Instance.Direction.magnitude) == 0) return;
        animator.SetFloat(animMove, Mathf.Abs(playerCtrl.PlayerMoving.MoveSpeedPlayer * InputManager.Instance.Direction.magnitude));
        runSpeed = Mathf.Abs(InputManager.Instance.Direction.magnitude);

    }
    private void SingleTwohandSwordAttack()
    {
        if (!playerCtrl.PlayerAttack.IsAttack) return;
        ChangeCurrentState(animSingleTwohandSwordAttack);
        isExitState = false;
    }

    private void ChangeModelWeapon(List<GameObject> listGameObjects, string name, int n)
    {
        for (int i = 0; i < listGameObjects.Count; i++)
        {
            listGameObjects[i].SetActive(false);
            if (listGameObjects[i].name == (name + n))
            {
                listGameObjects[i].SetActive(true);
                break;
            }
        }
    }

    private void ChangeCurrentState(string newState)
    {
        if (currentState == newState) return;
        animator.SetTrigger(newState);
        string s = "";
        for (int i = 0; i < newState.Length; i++)
        {
            if (newState[i].ToString().Contains(" "))
            {
                break;
            }
            s += newState[i];
        }
        currentState = newState;
        ChangeModelWeapon(playerCtrl.ListWeapon, s, 1);
    }

    protected override void LoadComponent()
    {
        animator = GetComponent<Animator>();
        playerCtrl = GetComponent<PlayerCtrl>();
    }
    #region even anim
    private void State()
    {
        if (playerCtrl.PlayerAttack.IsAttack) return;
        isExitState = true;
    }
    #endregion


}
