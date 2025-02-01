using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damageAmount = 20f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health enemyHealth = collision.GetComponent<Health>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damageAmount);
            Debug.Log($"Weapon hit {collision.gameObject.name} for {damageAmount} damage!");
        }
    }
}
