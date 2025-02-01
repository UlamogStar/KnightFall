using UnityEngine;

public class WeaponSwing : MonoBehaviour
{
    public float swingSpeed = 500f; // Degrees per second
    public float swingAngle = 90f;  // Total arc angle
    private float swingTime;
    private bool isSwinging = false;

    private void Start()
    {
        swingTime = swingAngle / swingSpeed;
        StartSwing();
    }

    private void StartSwing()
    {
        if (!isSwinging)
        {
            isSwinging = true;
            StartCoroutine(SwingWeapon());
        }
    }

    private System.Collections.IEnumerator SwingWeapon()
    {
        float elapsed = 0f;
        float startAngle = -swingAngle / 2f;
        float endAngle = swingAngle / 2f;

        while (elapsed < swingTime)
        {
            elapsed += Time.deltaTime;
            float angle = Mathf.Lerp(startAngle, endAngle, elapsed / swingTime);
            transform.localRotation = Quaternion.Euler(0, 0, angle);
            yield return null;
        }

        isSwinging = false;
    }
}
