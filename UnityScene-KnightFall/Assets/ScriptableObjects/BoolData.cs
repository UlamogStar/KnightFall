using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoolData", menuName = "ScriptableObjects/BoolData", order = 3)]
public class BoolData : ScriptableObject
{
    public bool value;  

    public void UpdateValue(bool num)
    {
        value = num;
    }
}
