using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapDraggable : MonoBehaviour
{
    /*[SerializeField] Transform slot1;
    [SerializeField] Transform slot2;

    DetectDraggable d;
    Vector3 slotPos = new Vector3(0, 50, 0);
    Image item;
    Sprite s;

    // Start is called before the first frame update
    void Start()
    {
        d = GetComponent<DetectDraggable>();
        item = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (d.obj && Input.GetKeyUp(KeyCode.Mouse0))
        {
            // Snap object to slot.
            Snap(d.obj);
        }
    }

    void Snap(GameObject obj)
    {
        if (obj.tag == "Slot1")
        {
            obj.transform.SetParent(slot1);
        }
        else if (obj.tag == "Slot2")
        {
            obj.transform.SetParent(slot2);
        }
        obj.transform.localPosition = slotPos;
    }*/

    [SerializeField] bool occupied;
    [SerializeField] bool dragging;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            dragging = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            dragging = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Draggable") && !occupied && !dragging)
        {
            collision.gameObject.transform.position = gameObject.transform.position;
            occupied = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Draggable") && occupied && dragging)
        {
            occupied = false;
        }
    }
}
