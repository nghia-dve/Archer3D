using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
//Sử dụng công cụ này để biên dịch/thực thi mã cho bất kỳ nền tảng độc lập nào (Mac, Windows hoặc Linux).
#if UNITY_STANDALONE
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        SetStatusMouse();
    }
    private void SetStatusMouse()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            if (Cursor.lockState == CursorLockMode.None) return;
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
#endif
}
