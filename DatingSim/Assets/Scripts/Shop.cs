using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Button buyButton;
    public Text buyButtonText;
    public int animalPrice = 30;
    public int maxAnimals = 2;
    public int animalsBought = 0;

    public GameObject animalPrefab;
    public Vector2 spawnAreaSize = new Vector2(2f, 2f);  // Width and height of the spawn area (2D)
    public Vector2 spawnOffset = Vector2.zero;           // Optional offset (2D)

    private UpdateText quotaTracker;

    [SerializeField] private Transform player;
    [SerializeField] private float open = 5f;

    // The button's image component
    public Image buttonImage;

    void Start()
    {
        quotaTracker = FindObjectOfType<UpdateText>();

        buyButton.gameObject.SetActive(false);
        buyButton.onClick.AddListener(OnBuyClick);

        // Update the button image to match the animal prefab's sprite
        if (animalPrefab != null && buttonImage != null)
        {
            Sprite animalSprite = animalPrefab.GetComponent<SpriteRenderer>()?.sprite;
            if (animalSprite != null)
            {
                buttonImage.sprite = animalSprite;
            }
            else
            {
                Debug.LogWarning("No SpriteRenderer found on the animal prefab.");
            }
        }
    }

    void OnMouseDown()
    {
        if (player == null)
        {
            Debug.LogWarning("Player Transform is not assigned.");
            return;
        }

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= open)
        {
            ShowBuyButton();
        }
        else
        {
            Debug.Log("Too far from shop.");
        }
    }


    public void UpdateButtonSprite(Sprite newSprite)
    {
        if (buttonImage != null && newSprite != null)
        {
            buttonImage.sprite = newSprite;
            Debug.Log($"Updated button sprite to: {newSprite.name}");
        }
        else
        {
            Debug.LogWarning("Button image or new sprite is not assigned correctly.");
        }
    }


    void ShowBuyButton()
    {
        if (animalsBought < maxAnimals)
        {
            ApplyDiscount(); // Apply discount before updating UI
            buyButtonText.text = $"Buy Animal - {animalPrice} Points";
            buyButton.gameObject.SetActive(true);
            buyButton.interactable = true;

            // Update button sprite to match the current shop's animal prefab sprite
            UpdateButtonSprite(animalPrefab.GetComponent<SpriteRenderer>()?.sprite);
        }
        else
        {
            buyButtonText.text = "Out of stock.";
            buyButton.gameObject.SetActive(true);
            buyButton.interactable = false;
        }
    }



    void OnBuyClick()
    {
        if (quotaTracker != null && animalsBought < maxAnimals)
        {
            if (quotaTracker.currAmnt >= animalPrice)
            {
                quotaTracker.updateScore(animalPrice);
                animalsBought++;

                SpawnAnimal();

                Debug.Log("You bought an animal!");
                buyButton.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Not enough points!");
                buyButtonText.text = "Not enough points!";
                buyButton.interactable = false;
                StartCoroutine(HideButtonAfterDelay(2f));
            }
        }
    }

    void SpawnAnimal()
    {
        if (animalPrefab != null)
        {
            // Calculate random position within the spawn area (2D)
            float randomX = Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
            float randomY = Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);

            // Position offset relative to the spawn point (2D)
            Vector2 randomSpawnPosition = new Vector2(randomX, randomY) + spawnOffset;

            // Spawn the animal at the calculated position
            Instantiate(animalPrefab, (Vector2)transform.position + randomSpawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Animal prefab not assigned!");
        }
    }

    IEnumerator HideButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        buyButton.gameObject.SetActive(false);
    }

    // Draws a wireframe box for the spawn area in the editor (2D)
    void OnDrawGizmos()
    {
        // Set the color of the gizmo
        Gizmos.color = Color.green;

        // Draw a wireframe box to represent the spawn area in 2D
        Gizmos.DrawWireCube((Vector2)transform.position + spawnOffset, spawnAreaSize);
    }

    public float discountPercentage = 0f;  // Discount percentage (e.g., 20% off)

    void ApplyDiscount()
    {
        if (discountPercentage > 0f)
        {
            animalPrice -= Mathf.RoundToInt(animalPrice * discountPercentage / 100);
            Debug.Log($"Discount applied! New price: {animalPrice}");
        }
    }

}