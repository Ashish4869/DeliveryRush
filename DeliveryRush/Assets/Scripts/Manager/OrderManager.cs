using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{

    /// <summary>
    /// Deals the order system in the game
    /// </summary>
    
    [SerializeField]
    int[] FoodItemAmount;

    [SerializeField]
    FoodPackageSO[] FoodItems;

    int _allOrders;
    int _currentOrderCount = 0;
    float _timebetweenOrderNotification;
    int _timeLowerBound;
    int _timeHigherBound;
    string _timeStamp;
    string _OrderDetails;

    int prev = -1;

    Clock gameClock;
    EventManager _eventManager;

    Dictionary<FoodPackageSO, int> Orders = new Dictionary<FoodPackageSO, int>();
   string[] _hotelNames = new string[10];

    private void Awake()
    {
        _eventManager = FindObjectOfType<EventManager>();
        gameClock = FindObjectOfType<Clock>();

        Hotel[] hotels = FindObjectsOfType<Hotel>();

        foreach (Hotel hotel in hotels)
        {
            _hotelNames[hotel.GetHotelID()] = hotel.GetHotelName();
        }
    }

    private void Start()
    {
        //Create a dictionary for all the food items
        for(int i = 0; i < FoodItemAmount.Length; i++)
        {
            Orders.Add(FoodItems[i], FoodItemAmount[i]);
            _allOrders += FoodItemAmount[i];
        }


        //Initializing values
        _timeLowerBound = 10;
        _timeHigherBound = 20;
        _timebetweenOrderNotification = Random.Range(0, 2);
    }

    private void Update()
    {
        ProcessOrders();
    }


    void ProcessOrders()
    {
        if(_timebetweenOrderNotification <= 0)
        {
            NotifyOrder();
        }
        else
        {
            _timebetweenOrderNotification -= Time.deltaTime;
        }
    }
    
    void NotifyOrder()
    {
        
        // if all the orders have been processed disable game object
        if(_currentOrderCount >= _allOrders)
        {
            gameObject.SetActive(false);
            return;
        }

        int rand = RandomizeWithoutRepeating();

        //if we dont have any orders on that item , get another order
        if (Orders[FoodItems[rand]] == 0)
        {
            _timebetweenOrderNotification = 1;
            return;
        }

        _timeStamp = gameClock.GetTime();
        
        //need to make this debug into a pass to UI
        int foodID = FoodItems[rand].GetFoodID() / 10;
        _OrderDetails = _timeStamp + "-" + FoodItems[rand].GetFoodName() + "-" + _hotelNames[FoodItems[rand].GetFoodID() / 10];
        _eventManager.OnOrderRecievedEvent(_OrderDetails , foodID);


        Orders[FoodItems[rand]]--;
        _currentOrderCount++;
        _timebetweenOrderNotification = Random.Range(_timeLowerBound, _timeHigherBound);
    }

    int RandomizeWithoutRepeating()
    {
        int rand = Random.Range(0, FoodItems.Length);

        if (prev == rand)
        {
            rand = Random.Range(0, FoodItems.Length);
        }

        prev = rand;

        return rand;
    }

}
