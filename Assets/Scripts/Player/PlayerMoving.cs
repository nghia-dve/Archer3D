using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : NghiaMonoBehaviour
{
    private Vector3 movingDir;

    [SerializeField]
    private float clampX = 4;

    [SerializeField]
    private float clampZ = 14f;

    [SerializeField]
    private float moveSpeedPlayer = 3;

    [SerializeField]
    private PlayerCtrl playerCtrl;

    private void Update()
    {
        GetTagetDir();
        ClampPos();
        if (movingDir.magnitude < 0.1f || playerCtrl.PlayerAnim.IsAttack || !playerCtrl.PlayerAnim.IsExitState) return;
        Move();
        LookAtTaget();

    }

    private void ResetPhysic()
    {

    }

    private void GetTagetDir()
    {
        movingDir = InputManager.Instance.Direction;
    }

    private void Move()
    {
        transform.parent.position += movingDir * moveSpeedPlayer * Time.deltaTime;
    }

    private void LookAtTaget()
    {
        transform.parent.rotation = Quaternion.LookRotation(movingDir);
    }

    private void ClampPos()
    {
        transform.parent.position = new Vector3(Mathf.Clamp(transform.parent.position.x, -clampX, clampX),
    Mathf.Clamp(transform.position.y, 0, 0), Mathf.Clamp(transform.parent.position.z, -clampZ, clampZ));
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
    }
}
