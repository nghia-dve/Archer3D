using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameCtrl>();
            return instance;
        }
    }

    [Header("==joystick==")]
    [SerializeField]
    private FloatingJoystick joyStick;
    public FloatingJoystick Joystick { get { return joyStick; } }

    private void Reset()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        joyStick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();
    }
}
