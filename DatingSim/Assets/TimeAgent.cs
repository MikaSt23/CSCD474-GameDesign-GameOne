using System;
using UnityEngine;

public class TimeAgent : MonoBehaviour
{
    public float interval = 1f;           // Hours between ticks
    private float lastTickHour = -1f;

    public Action onTimeTick;

    private void Start()
    {
        GameManager.instance.timeController.Subscribe(this);
    }

    public void Tick(float currentHour)
    {
        if (lastTickHour < 0f || currentHour - lastTickHour >= interval)
        {
            onTimeTick?.Invoke();
            lastTickHour = currentHour;
        }
    }

    private void OnDestroy()
    {
        GameManager.instance.timeController.Unsubscribe(this);
    }
}
