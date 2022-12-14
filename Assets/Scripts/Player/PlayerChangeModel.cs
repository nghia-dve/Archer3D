using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeModel : NghiaMonoBehaviour
{
    [SerializeField]
    private PlayerCtrl playerCtrl;
    private string currentState;
    public string CurrentState { get { return currentState; } }

    private void Update()
    {
        SendModel(playerCtrl.PlayerAnim.CurrentState);
    }

    private void SendModel(string newState)
    {
        if (currentState == newState || newState == null) return;
        currentState = newState;
        //GetPrefabByName();
        GameObject newGameObject = ModelPlayerSpawner.Instance.Spawn(newState, Vector3.zero, Quaternion.identity);
        newGameObject.transform.parent = transform.parent;
        newGameObject.transform.SetAsFirstSibling();
        newGameObject.transform.localPosition = Vector3.zero;
        newGameObject.transform.localRotation = Quaternion.identity;
        //GameCtrl.Instance.ReceiveData(transform.parent.gameObject, transform.parent.GetComponent<Animator>(), currentState);
        ResetAminator();
    }
    private void ResetAminator()
    {
        Animator animator = playerCtrl.GetComponent<Animator>();
        animator.Rebind();
        animator.Play(currentState);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }

}
