using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUI : MonoBehaviour, IDragHandler
{
    private bool isMatch;

    private void Start()
    {
        isMatch = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!isMatch)
        {
            transform.position = eventData.position;
        }
    }

    public void setMatch(bool match)
    {
        isMatch = match;
    }    
}
