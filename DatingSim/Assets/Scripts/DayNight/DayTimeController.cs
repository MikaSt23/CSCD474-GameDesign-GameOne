using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class DayTimeController : MonoBehaviour
{
    const float secondsInDay = 86400f;

    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color dayLightColor = Color.white;

    float time = 0f; // Start time at 0
    [SerializeField] float timeScale = 96f; // Full day (86400s) in 15 minutes (900s)
    [SerializeField] float startAtTime = 2f;

    [SerializeField] Text text;
    [SerializeField] Light2D globalLight;
    private int days;

    List<TimeAgent> agents;

    private void Awake()
    {
        agents = new List<TimeAgent>();
    }
    
    private void Start()
    {
        time = startAtTime;
    }

    public void Subscribe(TimeAgent timeAgent)
    {
        agents.Add(timeAgent);
    }

    public void Unsubscribe(TimeAgent timeAgent)
    {
        agents.Remove(timeAgent);
    }

    float Hours
    {
        get { return time / 3600f; }
    }

    private void Update()
    {
        time += Time.deltaTime * timeScale;

        // Add 4 hours to the displayed time
        float displayHours = (Hours + 4f) % 24f;

        int hours = Mathf.FloorToInt(displayHours);
        int minutes = Mathf.FloorToInt((displayHours - hours) * 60);
        text.text = string.Format("{0:00}:{1:00}", hours, minutes);

        float v = nightTimeCurve.Evaluate(Hours); // Keep light logic based on real hours
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLight.color = c;

        if (time > secondsInDay)
        {
            NextDay();
        }

        for(int i = 0; i < agents.Count; i++)
        {
            agents[i].Invoke();
        }
    }

    private void NextDay()
    {
        time = 0f; // Reset time properly to 0
        days += 1;
    }

    public float GetCurrentTimeInSeconds()
    {
        return time;
    }
}
s