using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vector3Data", menuName = "ScriptableObjects/Vector3Data", order = 4)]
public class Vector3Data : ScriptableObject
{
    public Vector3 value;

    public void UpdateValue(Vector3 vector3Obj)
    {
        value = vector3Obj;
    }
    
    public void TransformValue(Transform transformObj)
    {
        value = transformObj.position;
    }
}
