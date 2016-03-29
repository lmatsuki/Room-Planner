using UnityEngine;
using System.Collections;

public class DragItem : MonoBehaviour {

    public static bool isDeleting;

	void Start () 
    {
        isDeleting = false;
	}

    public void OnDrag()
    {
        transform.position = Input.mousePosition;
    }

    public void OnClick()
    {        
        if(name == "Item Panel(Clone)" && isDeleting)
        {            
            isDeleting = false;
            Destroy(gameObject);
        }
    }
}
