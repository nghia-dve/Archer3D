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
#if UNITY_ANDROID || UNITY_IPHONE
        direction = new Vector3(UIManager.Instance.Joystick.Horizontal, 0, UIManager.Instance.Joystick.Vertical);
#endif
#if UNITY_EDITOR
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
#endif
    }

}
