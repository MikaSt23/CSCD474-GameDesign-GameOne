using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCuttable : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 2;
    [SerializeField] float spread = 0.5f;
    [SerializeField] int requiredTool = 2;

    private int hitPoints = 7;
    private float lastHitTime = 0f;  // Time when the last hit occurred
    private float hitCooldown = 2f;  // Cooldown in seconds

    private IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = originalPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPos;
    }

    public override void Hit()
    {
        if (Time.time - lastHitTime < hitCooldown)
            return;

        // Update the time of the last hit
        lastHitTime = Time.time;

        if (ToolBarSettings.currentTool != requiredTool)
            return;

        hitPoints--;

        if (hitPoints > 0)
        {
            StartCoroutine(Shake(0.1f, 0.05f)); // Shake duration + strength
            return;
        }

        while (dropCount > 0)
        {
            dropCount--;

            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;

            Instantiate(pickUpDrop, position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
