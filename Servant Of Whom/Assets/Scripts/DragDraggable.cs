using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDraggable : MonoBehaviour
{
    DetectDraggable d;
    bool detected;
    bool moveObject;

    // Start is called before the first frame update
    void Start()
    {
        d = GetComponent<DetectDraggable>();
        detected = false;
        moveObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        detected = d.IsPointerOverUIElement();
        if (detected && Input.GetKeyDown(KeyCode.Mouse0))
        {
            moveObject = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log("Let go of object.");
            moveObject = false;
        }
    }

    void FixedUpdate()
    {
        if (moveObject)
        {
            Debug.Log("Moving object...");
            d.obj.transform.position = Input.mousePosition;
        }
    }
}
