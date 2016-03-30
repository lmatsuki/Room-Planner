using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {

    public static Floor savedFloors = new Floor();

    public static void Save()
    {
        Debug.Log("Saving...");

        //Populate the items data
        List<Item> items = new List<Item>();
        GameObject itemHolder = GameObject.Find("Item Holder");
        int itemCount = itemHolder.transform.childCount;
        for (int i = 0; i < itemCount; i++)
        {
            RectTransform rect = itemHolder.transform.GetChild(i).GetComponent<RectTransform>();
            Item item = new Item();
            item.setRect(rect.anchoredPosition, rect.sizeDelta, rect.eulerAngles);
            item.itemName = itemHolder.transform.GetChild(i).GetChild(1).GetComponent<Text>().text;
            items.Add(item);
        }

        //Populate the rooms data
        List<Room> rooms = new List<Room>();
        GameObject roomHolder = GameObject.Find("Room Holder");
        int roomCount = roomHolder.transform.childCount;
        for (int i = 0; i < roomCount; i++)
        {
            RectTransform rect = roomHolder.transform.GetChild(i).GetComponent<RectTransform>();
            Room room = new Room();
            room.setRect(rect.anchoredPosition, rect.sizeDelta, rect.eulerAngles);
            room.itemName = roomHolder.transform.GetChild(i).GetChild(1).GetComponent<Text>().text;
            rooms.Add(room);
        }

        savedFloors.items = items;
        savedFloors.rooms = rooms;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedFiles.gd");
        bf.Serialize(file, savedFloors);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedFiles.gd"))
        {
            Debug.Log("Loading...");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedFiles.gd", FileMode.Open);
            savedFloors = (Floor)bf.Deserialize(file);
            file.Close();

            Icons iconScript = GameObject.Find("Canvas").GetComponent<Icons>();
            iconScript.DestroyAllItems();

            //create items from save data
            for (int i = 0; i < savedFloors.items.Count; i++)
            {
                iconScript.LoadFurniture(savedFloors.items[i]);
            }

            //create rooms from save data
            for (int i = 0; i < savedFloors.rooms.Count; i++)
            {
                iconScript.LoadRoom(savedFloors.rooms[i]);
            }
        }
    }
}
