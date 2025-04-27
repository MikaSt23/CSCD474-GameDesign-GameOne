using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestContainer : MonoBehaviour
{
    [SerializeField] ItemContainer inventoryContainer;
    //[SerializeField] Text resultText;
    [SerializeField] private Transform player;
    [SerializeField] private float open = 2f;
    [SerializeField] private UpdateText quotaTracker; 

    private Dictionary<string, int> itemValue = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        itemValue["egg"] = 5;
        itemValue["milk"] = 5;
        itemValue["wool"] = 5;
        itemValue["egg"] = 5;
        itemValue["wood"] = 2;
        itemValue["stone"] = 2;
        itemValue["grass"] = 2;
    }

    private void OnMouseDown()
    {

        if (player == null)
        {
            Debug.LogWarning("Player Transform is not assigned.");
            return;
        }

        float distance = Vector2.Distance(transform.position, player.position);
        //Debug.Log($"Chest clicked. Distance to player: {distance}");  // Debugging line

        if (distance <= open)
        {
            sellItems();
        }

        else
        {
            Debug.Log("Too far from chest.");
        }
    }

    // Update is called once per frame
    public void sellItems()
    {

        int total = 0;
        foreach (ItemSlot slot in inventoryContainer.slots)
        {
            if (slot.item == null) continue;

            string itemName = slot.item.name.ToLower();
            Debug.Log($"Found item: {itemName} x{slot.count}");


            if (itemValue.TryGetValue(itemName, out int value))
            {
                total += value * slot.count;

                slot.item = null;
                slot.count = 0;
            }



        }

        if (quotaTracker != null)
        {
            quotaTracker.updateScore(total);
        }
    }



    
}
