using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUIVersion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if (UNITY_ANDROID || UNITY_IOS) 
        ChangeUI(true);
#else 
        ChangeUI(false);
#endif
    }
    private void ChangeUI(bool check)
    {
        UIManager.Instance.Joystick.gameObject.SetActive(check);
        UIManager.Instance.ButtonAttack.gameObject.SetActive(check);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
