using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;


public class JoystickFocus : NghiaMonoBehaviour
{
    [SerializeField]
    private List<GameObject> listFocus = new List<GameObject>();

    private int currentState;
#if (UNITY_ANDROID || UNITY_IOS)
    private void Update()
    {
        Focus();
    }
#endif
    private void Focus()
    {

        int newState = -1;
        Vector3 vector = InputManager.Instance.Direction;
        if (vector.x < 0 && vector.z > 0)
        {
            newState = 0;
        }
        else if (vector.x > 0 && vector.z > 0)
        {
            newState = 1;
        }
        if (vector.x < 0 && vector.z < 0)
        {
            newState = 3;
        }
        else if (vector.x > 0 && vector.z < 0)
        {
            newState = 2;
        }
        if (vector.magnitude < 0.1f)
        {
            newState = -1;
        }
        ChangeCurrentState(newState);
    }

    private void ChangeCurrentState(int newState)
    {
        if (currentState == newState) return;

        //animator.Play(newState);


        currentState = newState;


        for (int i = 0; i < listFocus.Count; i++)
        {
            if (i != newState)
            {
                listFocus[i].transform.gameObject.SetActive(false);
            }
        }
        if (currentState < 0) return;
        listFocus[newState].transform.gameObject.SetActive(true);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        Transform transform = GameObject.Find("Focus").transform;
        foreach (Transform item in transform)
        {
            listFocus.Add(item.gameObject);
            item.gameObject.SetActive(false);
        }
    }
}

