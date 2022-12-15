using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class FloatingJoystick : Joystick
{
    private Vector3 offset;
    protected override void Start()
    {
        base.Start();
        background.gameObject.SetActive(true);
        offset = background.anchoredPosition;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.anchoredPosition = offset;
        background.gameObject.SetActive(true);
        base.OnPointerUp(eventData);
    }
}