using UnityEngine;
using System.Collections;

[System.Serializable]
public class Room  
{
    public SerializableVector2 aPos, sDelta;
    public SerializableVector3 eAngles;
    public string itemName;

    public Room ()
    { }

    public void setRect(Vector2 anchorPos, Vector2 sizeDelta, Vector3 eulerAngles)
    {
        aPos = new SerializableVector2(anchorPos);
        sDelta = new SerializableVector2(sizeDelta);
        eAngles = new SerializableVector3(eulerAngles);
    }
}
