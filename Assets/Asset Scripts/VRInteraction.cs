using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VRInteraction : MonoBehaviour
{

    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;

    public void Start()
    {

    }
    void Update()
    {
        if (gazedAt == true)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                timer = 0f;
            }
        }
    }


    public void OnPointerEnter()
    {
        gazedAt = true;
    }

    public void OnPointerExit()
    {
        gazedAt = false;
        timer = 0f;
    }

    public void PointerDown()
    {
        gazedAt = false;
    }
}
