using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseEnterButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse over button");
        FindObjectOfType<AudioManager>().Play("button", 1f);

        // Add code here for what happens when the mouse enters the button
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse left button");
        // Add code here for what happens when the mouse leaves the button
    }


}
