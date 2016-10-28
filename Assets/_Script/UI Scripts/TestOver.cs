using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isOver = false;
    
    
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);

        Debug.Log("Mouse enter");
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Debug.Log("Mouse exit");
        isOver = false;
    }
}
