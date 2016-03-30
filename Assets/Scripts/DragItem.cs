using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DragItem : MonoBehaviour {

    public static bool isDeleting;
    public Text itemName, width, height;

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
        if(name == "Item Panel(Clone)")
        {            
            if(isDeleting)
            {
                isDeleting = false;
                Destroy(gameObject);
            }
            else
            {
                itemName.text = transform.GetChild(1).GetComponent<Text>().text;
                width.text = GetComponent<RectTransform>().rect.width.ToString();
                height.text = GetComponent<RectTransform>().rect.height.ToString();
            }
        }
    }
}
