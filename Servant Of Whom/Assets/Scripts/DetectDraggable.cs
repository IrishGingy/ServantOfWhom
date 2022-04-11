using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectDraggable : MonoBehaviour
{
    public GameObject obj;

    int DraggableLayer;
    
    private void Start()
    {
        DraggableLayer = LayerMask.NameToLayer("Draggable");
    }

    private void FixedUpdate()
    {
        print(IsPointerOverUIElement() ? "Over draggable" : "Not over draggable");
    }


    // Returns 'true' if we touched or hovering on Draggable element.
    public bool IsPointerOverUIElement()
    {
        if (IsPointerOverUIElement(GetEventSystemRaycastResults()) != null)
        {
            return true;
        }
        return false;
    }


    // Returns 'true' if we touched or hovering on Draggable element.
    private GameObject IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == DraggableLayer)
            {
                obj = curRaysastResult.gameObject;
                return curRaysastResult.gameObject;
            }
        }
        return null;
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
