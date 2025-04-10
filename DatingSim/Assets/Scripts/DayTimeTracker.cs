using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;

public class DayTimeTracker : MonoBehaviour
{
	int currDay = 1;
	int currHour = 6;
	int currMinutes = 0;
	
	public Text DayTimeDisplay;

    public void updateDay (int dayNum, int hour, int minutes)
    {
		currDay = dayNum;
		currHour = hour;
		currMinutes = minutes;
		DayTimeDisplay.text = Convert.ToString(currDay);
    }
	
	void Start()
	{
		string dayTime = "Day " + Convert.ToString(currDay) + " - " + Convert.ToString(currHour) + ":" + Convert.ToString(currMinutes) + "0";
		DayTimeDisplay.text = dayTime;
	}
	
}
