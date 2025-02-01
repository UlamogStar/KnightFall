using UnityEngine;

public class Death : MonoBehaviour
{
    public void TriggerDeath()
    {
        Debug.Log($"{gameObject.name} has been destroyed!");
        Destroy(gameObject);
    }
}
