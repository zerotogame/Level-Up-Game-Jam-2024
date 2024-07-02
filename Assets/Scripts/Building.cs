using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building : MonoBehaviour
{
    private string _objectID;
    public string _type;


    public Building(string objectID, string type)
    {
        _objectID = objectID;
        _type = type;
    }

    public string objectID
    {
        get { return _objectID; }
        set { _objectID = value; }
    }

    public string type
    {
        get { return _type; }
        set { _type = value; }
    }


    void generateId()
    {
        _objectID = System.Guid.NewGuid().ToString();
    }
}
