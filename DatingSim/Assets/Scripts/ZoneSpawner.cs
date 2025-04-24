using UnityEngine;
using UnityEngine.Tilemaps;

public class ZoneSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    [SerializeField] int spawnCount = 10;
    [SerializeField] Vector2 areaMin = new Vector2(-10, -10);
    [SerializeField] Vector2 areaMax = new Vector2(10, 10);
    [SerializeField] bool spawnOnStart = true;

    [SerializeField] Tilemap pathTilemap; // Assign this in the inspector

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Vector3 bottomLeft = new Vector3(areaMin.x, areaMin.y, 0);
        Vector3 bottomRight = new Vector3(areaMax.x, areaMin.y, 0);
        Vector3 topLeft = new Vector3(areaMin.x, areaMax.y, 0);
        Vector3 topRight = new Vector3(areaMax.x, areaMax.y, 0);

        Gizmos.DrawLine(bottomLeft, bottomRight);
        Gizmos.DrawLine(bottomRight, topRight);
        Gizmos.DrawLine(topRight, topLeft);
        Gizmos.DrawLine(topLeft, bottomLeft);

        // Optional: draw some sample spawn points
        Gizmos.color = Color.blue;
        for (int i = 0; i < 10; i++)
        {
            float x = Random.Range(areaMin.x, areaMax.x);
            float y = Random.Range(areaMin.y, areaMax.y);
            Gizmos.DrawSphere(new Vector3(x, y, 0), 0.2f);
        }
    }


    private void Start()
    {
        if (spawnOnStart)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        int spawned = 0;
        int maxAttempts = spawnCount * 10;
        int attempts = 0;

        while (spawned < spawnCount && attempts < maxAttempts)
        {
            attempts++;

            // Select a random prefab from the prefabs array
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
            Vector2 position = new Vector2(
                Random.Range(areaMin.x, areaMax.x),
                Random.Range(areaMin.y, areaMax.y)
            );

            Vector3Int cellPosition = pathTilemap.WorldToCell(position);

            // Skip if the position overlaps the path tilemap
            if (pathTilemap.HasTile(cellPosition))
                continue;

            // Adjust the position to Vector3, setting the Z component
            Vector3 spawnPosition = new Vector3(position.x, position.y, 1f);  // Set Z to 1 to avoid overlap with path

            // Instantiate the prefab at the adjusted position
            Instantiate(prefab, spawnPosition, Quaternion.identity);
            spawned++;
        }
    }


}
