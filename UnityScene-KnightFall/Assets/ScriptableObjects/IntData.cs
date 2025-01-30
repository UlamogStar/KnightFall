using UnityEngine;
//using UnityEngine.Events;

[CreateAssetMenu(fileName = "IntData", menuName = "ScriptableObjects/IntData", order = 2)]
public class IntData: ScriptableObject
{
    public int value;
    
    //public UnityEvent disableEvent;
   
    public void SetValue(int num)
    {
        value = num;
    }

    public void CompareValue(IntData obj)
    {
        if (value >= obj.value)
        {
            return;
        }
        else
        {
            value = obj.value;
        }
    }
    
    public void SetValue(IntData obj)
    {
        value = obj.value;
    }

    public void UpdateValue(int num)
    {
        value += num;
    }

   // private void onDisable()
    //{
        //disableEvent.Invoke();
    //}
}