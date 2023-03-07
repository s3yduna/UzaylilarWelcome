using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButon : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public bool tusaBasildi;

    public void OnPointerDown(PointerEventData eventData)
    {
        tusaBasildi = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        tusaBasildi = false;
    }
}
