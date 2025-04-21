using System.Collections;
using UnityEngine;

public class AnimalDrops : MonoBehaviour
{
    [SerializeField] GameObject pickUp;
    [SerializeField] int maxDrops = 4;       
    [SerializeField] float spread = 2f;      
    [SerializeField] float dropInterval = 240f; 

    private int dropsLeft;

    private void Start()
    {
        dropsLeft = maxDrops;
        StartCoroutine(DropRoutine());
    }

    IEnumerator DropRoutine()
    {
        while (dropsLeft > 0)
        {
            yield return new WaitForSeconds(dropInterval);
            Drop();
        }
    }

    void Drop()
    {
        if (dropsLeft <= 0) return;

        Vector3 position = transform.position;
        position.x += spread * Random.value - spread / 2;
        position.y += spread * Random.value - spread / 2;

        GameObject go = Instantiate(pickUp, position, Quaternion.identity);
        go.transform.position = position;
        dropsLeft--;

        Debug.Log("Drop Position: " + position);

    }
}
