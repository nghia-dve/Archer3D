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
        //SetRigidbody();
        GetTagetDir();
        Move();
    }
    private void FixedUpdate()
    {
        //SetRigidbody();
    }

    //private void SetRigidbody()
    //{
    //    transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
    //}

    private void GetTagetDir()
    {
        movingDir = InputManager.Instance.JoyStickDirection;
    }

    private void Move()
    {
        if (movingDir.magnitude < 0.01f) return;
        transform.parent.position += movingDir * moveSpeedPlayer * Time.deltaTime;
        transform.parent.rotation = Quaternion.LookRotation(movingDir);
        transform.parent.position = new Vector3(Mathf.Clamp(transform.parent.position.x, -clampX, clampX),
            Mathf.Clamp(transform.position.y, 0, 0), Mathf.Clamp(transform.parent.position.z, -clampZ, clampZ));
    }
}
