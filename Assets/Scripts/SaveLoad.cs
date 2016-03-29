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
            //Debug.Log(rect.offsetMin.ToString());
            //Debug.Log(rect.pivot.ToString());
            item.setRect(rect.anchoredPosition, rect.sizeDelta, rect.eulerAngles);
            item.itemName = itemHolder.transform.GetChild(i).GetChild(1).GetComponent<Text>().text;
            items.Add(item);
        }

        //Populate the rooms data
        //Todo...

        savedFloors.items = items;
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
        }
    }
}
