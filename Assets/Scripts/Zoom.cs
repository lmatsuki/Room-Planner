using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour {

    Transform roomHolder, itemHolder;
    float zoomFactor = 0.25f;

	void Start () 
    {
        roomHolder = GameObject.Find("Room Holder").transform;
        itemHolder = GameObject.Find("Item Holder").transform;
	}
	
	public void ZoomIn()
    {
        roomHolder.localScale += new Vector3(zoomFactor, zoomFactor, 0);
        itemHolder.localScale += new Vector3(zoomFactor, zoomFactor, 0);
    }

    public void ZoomOut()
    {
        roomHolder.localScale -= new Vector3(zoomFactor, zoomFactor, 0);
        itemHolder.localScale -= new Vector3(zoomFactor, zoomFactor, 0);
    }
}
