using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Swipe : MonoBehaviour 
{
    Transform roomHolder, itemHolder;
    Vector3 lastMousePosition;
    float scaleFactor = 0.25f;

    void Start()
    {
        roomHolder = GameObject.Find("Room Holder").transform;
        itemHolder = GameObject.Find("Item Holder").transform;
    }

    public void OnDrag(BaseEventData data)
    {
        PointerEventData pointerData = data as PointerEventData;
        roomHolder.position = roomHolder.position + new Vector3(pointerData.delta.x, pointerData.delta.y, 0);
        itemHolder.position = itemHolder.position + new Vector3(pointerData.delta.x, pointerData.delta.y, 0);
    }

    public void OnZoom(BaseEventData data)
    {
        PointerEventData pointerData = data as PointerEventData;
        roomHolder.localScale += new Vector3(pointerData.scrollDelta.y * scaleFactor, pointerData.scrollDelta.y * scaleFactor, 0);
        itemHolder.localScale += new Vector3(pointerData.scrollDelta.y * scaleFactor, pointerData.scrollDelta.y * scaleFactor, 0);
    }
}
