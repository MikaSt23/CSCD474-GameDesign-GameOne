using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickupDistance = 1.5f;

    public Item item;
    public int count = 1;


    private void Awake ()
    {
        player = GameManager.instance.player.transform;
    }

    private void Update ()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > pickupDistance) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
            );

        if (distance < 0.1f) {
            //TODO Should be moved into specified controller rather than being checked here
            if (GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count);
            } else
            {
                Debug.LogWarning("no inventory container attached to the game manager");
            }
            Destroy(gameObject); 
        }




    }

}
