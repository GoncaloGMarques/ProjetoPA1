using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class activeBorder : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public bool isOver = false;
    public GameObject border;

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        border.SetActive(true);
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        border.SetActive(false);

        //Debug.Log("Mouse exit");
        isOver = false;
    }

}
