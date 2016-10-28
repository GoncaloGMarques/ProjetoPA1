using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isOver = false;
    private Text theText;

    void Start()
    {
        theText = GetComponent<Text>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        theText.fontStyle = FontStyle.Bold;
        //theText.color = Color.black;

        Debug.Log("Mouse enter");
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theText.fontStyle = FontStyle.Normal;


        Debug.Log("Mouse exit");
        isOver = false;
    }
}