using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs; // Tree, bush, rock, etc.
    [SerializeField] int spawnCount = 10;


    [SerializeField] bool spawnOnStart = true;
    [SerializeField] GameObject[] trees;
    [SerializeField] GameObject[] rocks;
    [SerializeField] GameObject[] bushes;

    [SerializeField] Vector2 areaMin;
    [SerializeField] Vector2 areaMax;

    [SerializeField] int treeCount = 10;
    [SerializeField] int rockCount = 8;
    [SerializeField] int bushCount = 20;

    private List<GameObject> spawnedBushes = new List<GameObject>();
    private List<GameObject> spawnedTrees = new List<GameObject>();
    private List<GameObject> spawnedRocks = new List<GameObject>();


     private void OnDrawGizmos()
    {
        // Draw a wireframe rectangle to represent the spawn zone
        Gizmos.color = Color.green;  // Set color of the rectangle (green in this case)
        Gizmos.DrawLine(new Vector3(areaMin.x, areaMin.y, 0), new Vector3(areaMax.x, areaMin.y, 0));  // Bottom edge
        Gizmos.DrawLine(new Vector3(areaMin.x, areaMin.y, 0), new Vector3(areaMin.x, areaMax.y, 0));  // Left edge
        Gizmos.DrawLine(new Vector3(areaMax.x, areaMin.y, 0), new Vector3(areaMax.x, areaMax.y, 0));  // Right edge
        Gizmos.DrawLine(new Vector3(areaMin.x, areaMax.y, 0), new Vector3(areaMax.x, areaMax.y, 0));  // Top edge

        // Draw spawn points (you can add this if you want to visualize the spawn locations)
        Gizmos.color = Color.blue;  // Set color for spawn points (blue)
        for (int i = 0; i < 5; i++)  // Show a few example spawn points
        {
            float x = Random.Range(areaMin.x, areaMax.x);
            float y = Random.Range(areaMin.y, areaMax.y);
            Gizmos.DrawSphere(new Vector3(x, y, 0), 0.1f);  // Draw a small sphere at spawn locations
        }
    }


    private void Start()
    {
        if (spawnOnStart)
        {
            SpawnAll();  // Spawn trees, rocks, and bushes at the start
        }
    }


    public void Spawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
            Vector2 position = new Vector2(
                Random.Range(areaMin.x, areaMax.x),
                Random.Range(areaMin.y, areaMax.y)
            );

            Instantiate(prefab, position, Quaternion.identity);
        }
    }

    private void Awake()
    {
        TimeAgent agent = GetComponent<TimeAgent>();
        agent.onTimeTick += OnTimeTick;
    }

    void OnTimeTick()
    {
        float hour = (FindObjectOfType<DayTimeController>().GetCurrentTimeInSeconds() / 3600f + 4f) % 24f;
        if (hour >= 6f && hour < 7f) // spawn between 6 and 7 AM
        {
            Spawn();
        }
    }
    public void SpawnAll()
    {
        SpawnGroup(trees, treeCount, spawnedTrees);
        SpawnGroup(rocks, rockCount, spawnedRocks);
        SpawnGroup(bushes, bushCount, spawnedBushes);
    }

    void SpawnGroup(GameObject[] prefabs, int count, List<GameObject> list)
    {
        foreach (GameObject go in list)
            Destroy(go);
        list.Clear();

        for (int i = 0; i < count; i++)
        {
            Vector2 pos = new Vector2(
                Random.Range(areaMin.x, areaMax.x),
                Random.Range(areaMin.y, areaMax.y)
            );

            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
            GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
            list.Add(obj);
        }
    }

    public void ResetEnvironment()
    {
        // Remove and respawn trees and rocks only
        SpawnGroup(trees, treeCount, spawnedTrees);
        SpawnGroup(rocks, rockCount, spawnedRocks);
        SpawnGroup(bushes, bushCount, spawnedBushes);
    }


}
