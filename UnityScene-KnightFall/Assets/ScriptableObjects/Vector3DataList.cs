using System.Collections.Generic;
using UnityEngine;

public class Vector3DataList : ScriptableObject
{
    public List<Vector3Data> vector3DataList;

    public void UpdateValue(Vector3 vector3Obj)
    {
        foreach (var vector3Data in vector3DataList)
        {
            vector3Data.UpdateValue(vector3Obj);
        }
    }
    
    public void TransformValue(Transform transformObj)
    {
        foreach (var vector3Data in vector3DataList)
        {
            vector3Data.TransformValue(transformObj);
        }
    }

    
}
