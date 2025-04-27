using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text popUpText;           
    public GameObject popUpUI;
    public Button yesButton;       
    public Button noButton;     
    public int animalPrice = 30;
    public int maxAnimals = 2;
    public int animalsBought = 0;

    private UpdateText quotaTracker;

    private string animalToBuy = "";

    public GameObject animaPrefab;

    [SerializeField] private Transform player;
    [SerializeField] private float open = 5f;


    //private Dictionary<string, List<Vector3>> animalSpawns = new Dictionary<string, List<Vector3>>();



    // Start is called before the first frame update
    void Start()
    {
        quotaTracker = FindObjectOfType<UpdateText>();

        popUpUI.SetActive(false);
        yesButton.onClick.AddListener(OnYesClick);
        noButton.onClick.AddListener(OnNoClick);

    }

    public void OpenShop(string animal)
    {
        if (animalsBought < maxAnimals)
        {
            animalToBuy = animal;
            //popUpText.text = $"Do you wish to buy a {animal}?";
            popUpUI.SetActive(true);
        }
        else
        {
            popUpText.text = $"Out of stock.";
            popUpUI.SetActive(true);
        }


    }

    void OnYesClick()
    {
        if (quotaTracker.currAmnt >= animalPrice && animalsBought < maxAnimals)
        {
            if (quotaTracker != null)
            {
                quotaTracker.updateScore(animalPrice);
            }
            animalsBought++;

            Debug.Log($"You bought a {animalToBuy}!");
            popUpUI.SetActive(false);
        }
    }

    void OnNoClick()
    {
        popUpUI.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (player == null)
        {
            Debug.LogWarning("Player Transform is not assigned.");
            return;
        }

        float distance = Vector2.Distance(transform.position, player.position);
        //Debug.Log($"Chest clicked. Distance to player: {distance}");  // Debugging line

        if (distance <= open)
        {
            OpenShop(animalToBuy);
            Debug.Log("Shop open!");

        }

        else
        {
            Debug.Log("Too far from shop.");
            Debug.Log(player.position);
        }
    }


}
