using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        CardManager1.instance.MoveCard(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null && gameObject.activeSelf == true)
        {
            if (eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>() != null)
            {
                CardManager1.instance.SetSelectedCard(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>());
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CardManager1.instance.ReleaseSelectedCard();
    }
}
