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
