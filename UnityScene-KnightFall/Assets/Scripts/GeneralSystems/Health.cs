using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    private Death deathComponent;

    private void Start()
    {
        currentHealth = maxHealth;
        deathComponent = GetComponent<Death>(); // Reference the Death script
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Remaining Health: {currentHealth}");

        if (currentHealth <= 0 && deathComponent != null)
        {
            deathComponent.TriggerDeath(); // Call Death script when health is zero
        }
    }
}
