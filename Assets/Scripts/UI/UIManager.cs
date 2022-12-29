using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : NghiaMonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<UIManager>();
            return instance;
        }
    }

    [Header("==joystick==")]
    [SerializeField]
    private FloatingJoystick joyStick;
    public FloatingJoystick Joystick { get { return joyStick; } }

    [SerializeField]
    private Button buttonAttack;
    public Button ButtonAttack { get { return buttonAttack; } }

    protected override void LoadComponent()
    {
        joyStick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();
    }
}
