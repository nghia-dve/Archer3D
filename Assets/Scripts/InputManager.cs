using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : NghiaMonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<InputManager>();
            return instance;
        }
    }
    private Vector3 direction;
    public Vector3 Direction { get { return direction; } }

    private void FixedUpdate()
    {
        GetDir();
    }

    private void GetDir()
    {
        float verticalInput = 0;
        float horizontalInput = 0;
        Vector3 forward = GameCtrl.Instance.MainCamera.transform.forward;
        Vector3 right = GameCtrl.Instance.MainCamera.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;
#if (UNITY_ANDROID || UNITY_IPHONE)&& !UNITY_EDITOR
        verticalInput = UIManager.Instance.Joystick.Vertical;
        horizontalInput = UIManager.Instance.Joystick.Horizontal;
        //if (verticalInput != 0 || horizontalInput != 0)
        //{
        //    Vector3 dirFwd = verticalInput * forward;
        //    Vector3 dirRigth = horizontalInput * right;
        //    direction = dirFwd + dirRigth;
        //}
        //direction = new Vector3(UIManager.Instance.Joystick.Horizontal, 0, UIManager.Instance.Joystick.Vertical);
        //Debug.Log("run android and IPhone");
#elif UNITY_EDITOR 
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        //if (verticalInput != 0 || horizontalInput != 0)
        //{
        //    Vector3 dirFwd = verticalInput * forward;
        //    Vector3 dirRigth = horizontalInput * right;
        //    direction = dirFwd + dirRigth;
        //}
        //direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // Debug.Log("run editor");
#endif
        direction = verticalInput * forward + horizontalInput * right;
    }

}
