using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : NghiaMonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private string currentState;

    //private bool isRun;

    const string animRun = "NormalRun_noWeapon";
    const string animIdle = "Idle_noWeapon";
    const string animAttack = "Combo01_SingleTwohandSword";

    private void Update()
    {

        Run();
        Attack();
    }

    private bool IsRun()
    {
        if (InputManager.Instance.JoyStickDirection.magnitude > 0) return false;
        return true;
    }

    private void Run()
    {
        if (!IsRun()) return;
        ChangeAnimationState(animRun);
    }
    private void Attack()
    {
        if (IsRun()) return;
        ChangeAnimationState(animAttack);
    }

    #region Even animatoin
    private void EvenRestCombo()
    {
        ChangeAnimationState(animAttack);
    }
    #endregion

    private void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(currentState);

        currentState = newState;
    }
    protected override void LoadComponent()
    {
        animator = GetComponent<Animator>();
    }
}
