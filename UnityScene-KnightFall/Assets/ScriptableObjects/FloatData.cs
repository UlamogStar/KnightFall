using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatData", menuName = "ScriptableObjects/FloatData", order = 1)]
public class FloatData : ScriptableObject
{
    public float value;

    public void SetValue(float num)
    {
        value = num;
    }

    public void UpdateValue(float num)
    {
        value += num;
    }

}
