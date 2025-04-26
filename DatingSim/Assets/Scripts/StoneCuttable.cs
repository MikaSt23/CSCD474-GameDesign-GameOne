using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCuttable : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 2;
    [SerializeField] float spread = 0.5f;
    [SerializeField] int requiredTool = 2; // Tool 2 (e.g., pickaxe)

    public override void Hit()
    {
        if (ToolBarSettings.currentTool != requiredTool)
            return;

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
