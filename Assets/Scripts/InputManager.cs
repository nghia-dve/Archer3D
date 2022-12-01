using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
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

    private Vector3 joyStickDirection;
    public Vector3 JoyStickDirection { get { return joyStickDirection; } }

    private void FixedUpdate()
    {
        _GetJoyStickDir();
    }

    private void _GetJoyStickDir()
    {
        joyStickDirection = new Vector3(GameCtrl.Instance.Joystick.Horizontal, 0, GameCtrl.Instance.Joystick.Vertical);
    }
}
