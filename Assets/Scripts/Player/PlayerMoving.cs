 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : NghiaMonoBehaviour
{
    private Vector3 movingDir;

    private float clampX = 4;

    private float clampZ = 40f;

    private bool isSetWalk = false;

    [SerializeField]
    private float moveSpeedPlayer = 3;
    public float MoveSpeedPlayer { get { return moveSpeedPlayer; } }

    [SerializeField]
    private float rotationSpeed = 720;

    [SerializeField]
    private PlayerCtrl playerCtrl;

    private void Update()
    {
        GetTagetDir();
        if (movingDir.magnitude <= 0.1f || playerCtrl.PlayerAttack.IsAttack || !playerCtrl.PlayerAnim.IsExitState) return;
        Move();
        LookAtTaget();

    }

    private void GetTagetDir()
    {
        movingDir = InputManager.Instance.Direction;
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeedPlayer = 10;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //if (isSetWalk)
            //    moveSpeedPlayer = 1;
            //else 
            moveSpeedPlayer = 3;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isSetWalk = !isSetWalk;
            if (isSetWalk)
                moveSpeedPlayer = 1;
            else
                moveSpeedPlayer = 3;
        }
        transform.parent.position += movingDir * moveSpeedPlayer * Time.deltaTime;
        ClampPos();
    }

    private void LookAtTaget()
    {
        //transform.parent.rotation = Quaternion.LookRotation(movingDir);
        Quaternion toRatation = Quaternion.LookRotation(movingDir, Vector3.up);
        transform.parent.rotation = Quaternion.RotateTowards(transform.parent.rotation, toRatation, rotationSpeed * Time.deltaTime);
    }

    private void ClampPos()
    {
        transform.parent.position = new Vector3(Mathf.Clamp(transform.parent.position.x, -clampX, clampX),
    Mathf.Clamp(transform.position.y, 0, 0), Mathf.Clamp(transform.parent.position.z, 0, clampZ));
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        moveSpeedPlayer = 3;
        rotationSpeed = 720;
    }
}
