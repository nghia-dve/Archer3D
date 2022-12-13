using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Vector3 movingDir;

    [SerializeField]
    private float clampX = 4;

    [SerializeField]
    private float clampZ = 14f;

    [SerializeField]
    private float moveSpeedPlayer = 3;

    private void Update()
    {
        GetTagetDir();
        ClampPos();
        if (movingDir.magnitude < 0.01f) return;
        Move();
        LookAtTaget();

    }

    private void ResetPhysic()
    {

    }

    private void GetTagetDir()
    {
        movingDir = InputManager.Instance.JoyStickDirection;
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
}
