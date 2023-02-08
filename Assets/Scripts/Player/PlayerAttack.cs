using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
    private bool isAttack;
    public bool IsAttack { get { return isAttack; } }

#if (UNITY_ANDROID || UNITY_IOS)
    // Start is called before the first frame update
    void Start()
    {
        AddEvenButton();
        //Debug.Log("run android and IPhone");
    }
    // add even UI button down and up
    private void AddEvenButton()
    {
        EventTrigger eventTrigger = UIManager.Instance.ButtonAttack.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        eventTrigger.triggers.Add(entry);
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener((data) => { OnPointerUpDelegate((PointerEventData)data); });
        eventTrigger.triggers.Add(entry);
    }
    private void OnPointerDownDelegate(PointerEventData data)
    {
        isAttack = true;
    }
    private void OnPointerUpDelegate(PointerEventData data)
    {
        isAttack = false;
    }
#endif

    // Update is called once per frame
    void Update()
    {
//Sử dụng công cụ này để biên dịch/thực thi mã cho bất kỳ nền tảng độc lập nào (Mac, Windows hoặc Linux).
#if UNITY_STANDALONE
        EvenMouse();
       
#endif
    }

    private void EvenMouse()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttack = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isAttack = false;
        }
    }
}
