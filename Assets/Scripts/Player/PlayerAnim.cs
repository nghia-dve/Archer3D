using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

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

    const string animRun = "NormalRun_noWeapon";
    const string animIdle = "Idle_noWeapon";
    const string animAttack = "Combo01_SingleTwohandSword";


    private void Update()
    {
        Run();
        CheckRun();
        Attack();
        //RestCombo();

    }

    private void CheckRun()
    {
        isRun = false;
        if (InputManager.Instance.JoyStickDirection.magnitude > 0) return;
        isRun = true;
    }

    private void Run()
    {
        if (isRun) return;
        ChangeCurrentState(animRun);
    }
    private void Attack()
    {
        if (!isRun) return;
        ChangeCurrentState(animAttack);
    }


    protected void RestCombo()
    {
        //if (!playerCtrl.IsRestCombo) return;

        //ChangeCurrentState(animAttack);
        //currentState = "";

    }


    private void ChangeCurrentState(string newState)
    {

        if (currentState == newState) return;

        //animator.Play(newState);
        animator.SetTrigger(newState);

        currentState = newState;
    }
    protected override void LoadComponent()
    {
        animator = GetComponent<Animator>();
        playerCtrl = GetComponent<PlayerCtrl>();

    }
}
