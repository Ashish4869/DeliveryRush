using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HotelUIManager : MonoBehaviour
{
    /// <summary>
    /// Deals with controlling UI functions so that the player can place orders
    /// </summary>

    [SerializeField]
    GameObject FoodItemPrefab;

    [SerializeField]
    GameObject PrepFoodItemPrefab;

    [SerializeField]
    GameObject HotelUI;

    EventManager _eventManager;
    GameObject FoodItemList;

    bool _isPreparing = false;

    void Start()
    {
        EventManager.OnOrderingFromRestaurant += ShowMenu;
        _eventManager = FindObjectOfType<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowMenu(List<FoodPackageSO> foodItems)
    {
        HotelUI.SetActive(true);

       FoodItemList = GameObject.Find("HotelOrderUI/PlaceOrderComponent/FoodItemList");
        
        foreach (var Fooditem in foodItems)
        {
            GameObject child = Instantiate(FoodItemPrefab);
            child.transform.SetParent(FoodItemList.transform);
            child.transform.localScale = new Vector3(1, 1, 1);

            Image[] images = child.GetComponentsInChildren<Image>();

            //Set the food sprites
            foreach (var image in images)
            {
                if(image.color == Color.black)
                {
                    //do nothing
                }
                else
                {
                    image.sprite = Fooditem.GetFoodSprite();
                }
            }

            //set the food text
            TextMeshProUGUI foodDesc = child.GetComponentInChildren<TextMeshProUGUI>();
            foodDesc.text = Fooditem.GetFoodDesc();

            //set the button
            Button itemButton = child.GetComponent<Button>();
            itemButton.onClick.AddListener(delegate { Order(Fooditem); });

           
        }
        
    }

    public void Order(FoodPackageSO fooditem)
    {
        _isPreparing = true;
        DeactivateButtons();
        _eventManager.OnPackageOrderedEvent(fooditem);
    }

    void DeactivateButtons()
    {
        foreach (Transform item in FoodItemList.transform)
        {
            Button foodButton = item.GetComponent<Button>();
            foodButton.interactable = false;
        }
    }

    public void HideMenu()
    {
        foreach (Transform item in FoodItemList.transform)
        {
            Destroy(item.gameObject);
        }

        HotelUI.SetActive(false);
    }

    public void FoodPrepared()
    {
        _isPreparing = false;
    }

  
}
