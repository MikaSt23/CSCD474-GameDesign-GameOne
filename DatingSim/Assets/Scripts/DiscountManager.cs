using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscountManager : MonoBehaviour
{
    [SerializeField] private DayTimeController dayTimeController;
    [SerializeField] private Text discountMessageText;  // Reference to the UI Text element

    [System.Serializable]
    public class ShopDiscount
    {
        public Shop shop;  // Reference to the shop
        public float discountTime;  // Time at which to apply the discount (in hours)
        public float discountPercentage;  // Discount percentage
        public float displayDurationInMinutes;  // Duration to display the discount message (in minutes)
    }

    [SerializeField] private ShopDiscount[] shopDiscounts;

    private float discountMessageTimer = 0f;  // Timer for how long to display the message

    void Update()
    {
        // Get current time in hours
        float currentTimeInSeconds = dayTimeController.GetCurrentTimeInSeconds();
        float currentHour = (currentTimeInSeconds / 3600f) % 24f;

        // Iterate through all the shops
        foreach (var shopDiscount in shopDiscounts)
        {
            // Check if the time matches the shop's assigned discount time
            if (Mathf.Approximately(currentHour, shopDiscount.discountTime))
            {
                shopDiscount.shop.discountPercentage = shopDiscount.discountPercentage;  // Apply the discount
                ShowDiscountMessage($"Discount! {shopDiscount.discountPercentage}% Off!", shopDiscount.displayDurationInMinutes);
            }
            else
            {
                shopDiscount.shop.discountPercentage = 0f;  // No discount at other times
            }
        }

        // Decrease the timer if the message is showing
        if (discountMessageTimer > 0f)
        {
            discountMessageTimer -= Time.deltaTime;
            if (discountMessageTimer <= 0f)
            {
                HideDiscountMessage();
            }
        }
    }

    // Show the discount message for a set duration
    private void ShowDiscountMessage(string message, float durationInMinutes)
    {
        discountMessageText.text = message;
        discountMessageText.gameObject.SetActive(true);

        // Convert duration from minutes to seconds
        discountMessageTimer = durationInMinutes * 60f;
    }

    // Hide the discount message
    private void HideDiscountMessage()
    {
        discountMessageText.gameObject.SetActive(false);
    }
}

