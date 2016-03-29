using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class Floor
{
    public List<Item> items;
    public List<Room> rooms;

    public Floor()
    {
        items = new List<Item>();
        rooms = new List<Room>();
    }
}
