using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]

public class GameAction : ScriptableObject  
{
    public UnityAction raise;

    public void Raise()
    {
        raise?.Invoke();
    }
}
