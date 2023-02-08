using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFieldOfView : MonoBehaviour
{
    private new CinemachineFreeLook camera;

    private void Awake()
    {
        camera = GameCtrl.Instance.ThirdPersonCamera;
    }

    private void Update()
    {
        SetFieldOfViewCamera();
        //Mathf.Clamp(camera.m_Lens.FieldOfView, 1, 40);
    }

    private void SetFieldOfViewCamera()
    {
        float Scroll = InputManager.Instance.ScrollView;

        if (Scroll > 0 && camera.m_Lens.FieldOfView > 3)
        {
            camera.m_Lens.FieldOfView--;
        }
        if (Scroll < 0 && camera.m_Lens.FieldOfView < 40)
        {
            camera.m_Lens.FieldOfView++;

        }
    }
}
