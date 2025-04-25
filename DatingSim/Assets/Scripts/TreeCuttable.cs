using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 3;
    [SerializeField] float spread = 0.7f;
    [SerializeField] int requiredTool = 1; // Tool 1 is the axe

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
