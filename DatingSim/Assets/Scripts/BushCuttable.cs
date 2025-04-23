using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushCuttable : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 3;
    [SerializeField] float spread = 0.7f;

    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;

            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;

            // Instantiate the pickup drop at the position with no rotation
            GameObject go = Instantiate(pickUpDrop, position, Quaternion.identity);

            // Optionally, you can add more behavior to the instantiated object
        }
        Destroy(gameObject);
    }
}
