using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Reference: https://forum.unity.com/threads/how-to-detect-if-mouse-is-over-ui.1025533/
public class DetectDraggable : MonoBehaviour
{
    public GameObject obj;

    int DraggableLayer;

    int SlotLayer;
    
    private void Start()
    {
        DraggableLayer = LayerMask.NameToLayer("Draggable");
        SlotLayer = LayerMask.NameToLayer("Slot");
    }

    private void FixedUpdate()
    {
        if (obj == null)
        {
            print(IsPointerOverUIElement() ? "Over draggable" : "Not over draggable");
        }
    }


    // Returns 'true' if we touched or hovering on Draggable element.
    public bool IsPointerOverUIElement()
    {
        IsPointerOverUIElement(GetEventSystemRaycastResults());

        if (obj != null)
        {
            return true;
        }
        return false;
    }


    // Changes appropriate bool to true if we touched or hovering on element with said layer.
    private void IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];

            if (curRaysastResult.gameObject.layer == DraggableLayer)
            {
                obj = curRaysastResult.gameObject;
                return;
            }
        }
        //obj = null;
    }


    // Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
}
