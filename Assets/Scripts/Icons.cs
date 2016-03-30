using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Icons : MonoBehaviour {

    public float itemSizeFactor = 1.0f;

    GameObject prefabFolder;
    GameObject addItemPanel;
    GameObject itemPanel, roomPanel;
    Transform itemHolder, roomHolder;

	void Start () 
    {
        prefabFolder = GameObject.Find("Prefabs");
        addItemPanel = GameObject.Find("Add Panel");
        itemPanel = GameObject.Find("Item Panel");
        roomPanel = GameObject.Find("Room Panel");
        itemHolder = GameObject.Find("Item Holder").transform;
        roomHolder = GameObject.Find("Room Holder").transform;
        addItemPanel.SetActive(false);
	}

    #region Add Item Functions

    public void AddItem()
    {
        //addItemPanel.transform.SetParent(transform);
        addItemPanel.SetActive(true);
    }

    public void AddFurniture()
    {
        GameObject addFurnitureClone = (GameObject)Instantiate(itemPanel, new Vector3(Screen.width / 2, Screen.height / 2, 0), Quaternion.identity);

        //check input field of item name
        string itemName = addItemPanel.transform.GetChild(0).GetChild(1).GetChild(2).GetComponent<Text>().text;
        if (itemName != "" || itemName != "Enter text...")
            addFurnitureClone.transform.GetChild(1).GetComponent<Text>().text = itemName;

        //check input field of item dimensions and validate
        string widthInput = addItemPanel.transform.GetChild(0).GetChild(3).GetChild(0).GetChild(2).GetComponent<Text>().text;
        string heightInput = addItemPanel.transform.GetChild(0).GetChild(3).GetChild(2).GetChild(2).GetComponent<Text>().text;
        float widthFloat, heightFloat;

        if (float.TryParse(widthInput, out widthFloat) && float.TryParse(heightInput, out heightFloat))
            addFurnitureClone.GetComponent<RectTransform>().sizeDelta = new Vector2(widthFloat * itemSizeFactor, heightFloat * itemSizeFactor);        

        addFurnitureClone.transform.SetParent(itemHolder);
        //addItemPanel.transform.SetParent(prefabFolder.transform);
        addItemPanel.SetActive(false);
    }

    public void AddRoom()
    {
        GameObject addFurnitureClone = (GameObject)Instantiate(roomPanel, new Vector3(Screen.width / 2, Screen.height / 2, 0), Quaternion.identity);

        //check input field of item name
        string itemName = addItemPanel.transform.GetChild(0).GetChild(1).GetChild(2).GetComponent<Text>().text;
        if (itemName != "" || itemName != "Enter text...")
            addFurnitureClone.transform.GetChild(1).GetComponent<Text>().text = itemName;

        //check input field of item dimensions and validate
        string widthInput = addItemPanel.transform.GetChild(0).GetChild(3).GetChild(0).GetChild(2).GetComponent<Text>().text;
        string heightInput = addItemPanel.transform.GetChild(0).GetChild(3).GetChild(2).GetChild(2).GetComponent<Text>().text;
        float widthFloat, heightFloat;

        if (float.TryParse(widthInput, out widthFloat) && float.TryParse(heightInput, out heightFloat))
            addFurnitureClone.GetComponent<RectTransform>().sizeDelta = new Vector2(widthFloat * itemSizeFactor, heightFloat * itemSizeFactor);

        addFurnitureClone.transform.SetParent(roomHolder);
        //addItemPanel.transform.SetParent(prefabFolder.transform);
        addItemPanel.SetActive(false);
    }

    public void Cancel()
    {
        //addItemPanel.transform.SetParent(prefabFolder.transform);
        addItemPanel.SetActive(false);
    }

    #endregion

    public void Delete()
    {
        DragItem.isDeleting = true;
    }

    #region Save Floor

    public void SaveFloor()
    {
        SaveLoad.Save();        
    }

    #endregion

    #region Load Floor

    public void LoadFloor()
    {
        SaveLoad.Load();
    }

    public void DestroyAllItems()
    {
        for (int i = 0; i < itemHolder.childCount; i++)
        {
            Destroy(itemHolder.GetChild(i).gameObject);
        }

        for (int i = 0; i < roomHolder.childCount; i++)
        {
            Destroy(roomHolder.GetChild(i).gameObject);
        }
    }

    public void LoadFurniture(Item newItem)
    {
        GameObject addFurnitureClone = (GameObject)Instantiate(itemPanel, new Vector3(Screen.width / 2, Screen.height / 2, 0), Quaternion.identity);

        //get item name from newItem
        string itemName = newItem.itemName;
        if (itemName != "" || itemName != "Enter text...")
            addFurnitureClone.transform.GetChild(1).GetComponent<Text>().text = itemName;

        //set item size by recttransform
        RectTransform rect = addFurnitureClone.GetComponent<RectTransform>();
        addFurnitureClone.transform.SetParent(itemHolder); // Order is important!!

        rect.anchoredPosition = newItem.aPos.GetVector();
        rect.sizeDelta = newItem.sDelta.GetVector();
        rect.eulerAngles = newItem.eAngles.GetVector();
        
        addItemPanel.transform.SetParent(prefabFolder.transform);
    }

    public void LoadRoom(Room newRoom)
    {
        GameObject addRoomClone = (GameObject)Instantiate(roomPanel, new Vector3(Screen.width / 2, Screen.height / 2, 0), Quaternion.identity);

        //get item name from newItem
        string itemName = newRoom.itemName;
        if (itemName != "" || itemName != "Enter text...")
            addRoomClone.transform.GetChild(1).GetComponent<Text>().text = itemName;

        //set item size by recttransform
        RectTransform rect = addRoomClone.GetComponent<RectTransform>();
        addRoomClone.transform.SetParent(roomHolder); // Order is important!!

        rect.anchoredPosition = newRoom.aPos.GetVector();
        rect.sizeDelta = newRoom.sDelta.GetVector();
        rect.eulerAngles = newRoom.eAngles.GetVector();

        addItemPanel.transform.SetParent(prefabFolder.transform);
    }

    #endregion

    public void Quit()
    {
        Application.Quit();
    }
}
