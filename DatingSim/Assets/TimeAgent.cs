using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeAgent : MonoBehaviour
{
    public Action onTimeTick;

    private void Start()
    {
        GameManager.instance.timeController.Subscribe(this);
    }

    public void Invoke()
    {
        onTimeTick?.Invoke();
    }

    private void onDestroy()
    {
        GameManager.instance.timeController.Unsubscribe(this);
    }
}

public class ItemSpawnManager : MonoBehaviour
{
    public static ItemSpawnManager instance;

    void Awake()
    {
        instance = this;
    }

    public void SpawnItem(Vector3 position, ItemSpawner prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
