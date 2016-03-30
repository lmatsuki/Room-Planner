using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
    public SerializableVector2 aPos, sDelta;
    public SerializableVector3 eAngles;
    public string itemName;

    public Item()
    { }

    public void setRect(Vector2 anchorPos, Vector2 sizeDelta, Vector3 eulerAngles)
    {
        aPos = new SerializableVector2(anchorPos);
        sDelta = new SerializableVector2(sizeDelta);
        eAngles = new SerializableVector3(eulerAngles);
    }
}

[System.Serializable]
public class SerializableVector3
{
    public float x;
    public float y;
    public float z;

    public SerializableVector3(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }
    public Vector3 GetVector()
    {
        return new Vector3(x, y, z);
    }
}

[System.Serializable]
public class SerializableVector2
{
    public float x;
    public float y;

    public SerializableVector2(Vector2 vector)
    {
        x = vector.x;
        y = vector.y;
    }
    public Vector2 GetVector()
    {
        return new Vector2(x, y);
    }
}
