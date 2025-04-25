using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(TimeAgent))]

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] ItemSpawner toSpawn;
    [SerializeField] int count;

    [SerializeField] float spread = 2f;

    [SerializeField] float probability = 0.5f;
    [SerializeField] float activeStartHour = 6f;
    [SerializeField] float activeEndHour = 8f;

    private DayTimeController dayTimeController;

    private void Start ()
    {
        float currentHour = (dayTimeController.GetCurrentTimeInSeconds() / 3600f + 4f) % 24f;
        if (currentHour < activeStartHour || currentHour >= activeEndHour)
            return;

        TimeAgent timeAgent = GetComponent<TimeAgent>();
        timeAgent.onTimeTick += Spawn;
        dayTimeController = FindObjectOfType<DayTimeController>();
    }

    void Spawn()
    {
        if (UnityEngine.Random.value < probability)
        {
            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;

            Instantiate(toSpawn, position, Quaternion.identity);

        }
    }
}
