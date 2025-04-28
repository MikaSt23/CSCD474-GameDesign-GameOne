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

    public List<Shop> shops; // List of shops

    private float discountTimeInSeconds; // Random time for discount to apply (in-game)
    private bool discountApplied = false; // Flag to check if discount has been applied
    private float discountEndTime = 0f; // The time when the discount ends (30 seconds after it's applied in real-life time)
    private float discountStartTime = 0f; // The time when the discount was applied (in real-life time)

    [SerializeField] Text discountStatusText; // Text to display discount status

    private void Awake()
    {
        agents = new List<TimeAgent>();
    }

    private void Start()
    {
        time = startAtTime;

        // Ensure discount text is initially hidden
        if (discountStatusText != null)
        {
            discountStatusText.enabled = false; // Hide the text at the start
        }
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

        // Check if the discount is active
        if (discountApplied && Time.time - discountStartTime >= 30f) // 30 seconds in real life
        {
            discountApplied = false; // Expire the discount
            RevertShopDiscount();
            ToggleDiscountMessage(); // Toggle off the discount message after it expires
        }

        // Check if it's time to apply the discount and if it hasn't been applied yet
        if (!discountApplied && time >= discountTimeInSeconds)
        {
            discountApplied = true;
            discountStartTime = Time.time; // Record the real-time when the discount starts
            discountEndTime = Time.time + 30f; // Set the discount to last for 30 seconds in real time
            ApplyShopDiscount();
        }

        for (int i = 0; i < agents.Count; i++)
        {
            agents[i].Invoke();
        }
    }

    private void NextDay()
    {
        time = 0f; // Reset time properly to 0
        days += 1;

        // Generate a random time between 0 and 86400 seconds (24 hours)
        discountTimeInSeconds = Random.Range(0f, secondsInDay);

        // Debug log for when the discount will be triggered
        Debug.Log($"Discount will be applied at {discountTimeInSeconds} seconds today.");
    }

    // Get a random shop from the list
    Shop GetRandomShop()
    {
        if (shops.Count > 0)
        {
            int randomIndex = Random.Range(0, shops.Count);
            return shops[randomIndex];
        }
        return null; // If no shops exist
    }

    // Apply the discount to a random shop
    void ApplyShopDiscount()
    {
        Shop randomShop = GetRandomShop();

        if (randomShop != null)
        {
            randomShop.animalPrice = Mathf.FloorToInt(randomShop.animalPrice * 0.5f); // Example: 50% discount
            Debug.Log("Discount applied to shop: " + randomShop.name);

            // Update the discount message (this could be a Text component within the panel)
            discountStatusText.text = $"Discount applied at {randomShop.name}!";
            discountStatusText.enabled = true; // Show the discount text
        }
        else
        {
            Debug.Log("No shop found for discount.");
            discountStatusText.text = "No shop found for discount!";
            discountStatusText.enabled = true; // Show the discount text
        }
    }

    // Revert the discount after 30 seconds (real time)
    void RevertShopDiscount()
    {
        Shop randomShop = GetRandomShop();

        if (randomShop != null)
        {
            randomShop.animalPrice = Mathf.FloorToInt(randomShop.animalPrice / 0.5f); // Revert back to original price
            Debug.Log("Discount expired, reverted shop price: " + randomShop.name);
        }
        else
        {
            Debug.Log("No shop found to revert discount.");
        }
    }

    // Toggle the visibility of the discount message (text)
    void ToggleDiscountMessage()
    {
        if (discountStatusText != null)
        {
            discountStatusText.enabled = false; // Hide the text after the discount ends
        }
    }

    // Add this method to return the current time
    public float GetCurrentTimeInSeconds()
    {
        return time;
    }
}

