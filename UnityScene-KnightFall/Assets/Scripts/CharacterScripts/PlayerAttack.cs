using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public GameObject weaponPrefab;  // Assign your weapon prefab in the Inspector
    public Transform attackPoint;    // The position where the weapon will appear
    public float attackDuration = 0.2f; // Time before weapon disappears
    public float attackCooldown = 0.5f; // Cooldown between attacks

    private PlayerInputActions inputActions;
    private bool isAttacking = false;
    private bool canAttack = true;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Player.Attack.performed += ctx => TryAttack();
    }

    private void OnEnable() { inputActions.Enable(); }
    private void OnDisable() { inputActions.Disable(); }

    private void TryAttack()
    {
        if (isAttacking || !canAttack) return;

        isAttacking = true;
        canAttack = false;
        print("is attacking");
        
        GameObject weaponInstance = Instantiate(weaponPrefab, attackPoint.position, attackPoint.rotation);
        weaponInstance.transform.parent = transform; // Attach weapon to the player

        // Destroy weapon after attack duration
        Destroy(weaponInstance, attackDuration);

        // Start cooldown
        Invoke(nameof(ResetAttack), attackDuration);
        Invoke(nameof(ResetCooldown), attackCooldown);
    }

    private void ResetAttack() { isAttacking = false; }
    private void ResetCooldown() { canAttack = true; }
}
