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

    Dictionary<FoodPackageSO, int> Orders = new Dictionary<FoodPackageSO, int>();

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

        int rand = Random.Range(0, FoodItems.Length);

        //if we dont have any orders on that item , get another order
        if(Orders[FoodItems[rand]] == 0)
        {
            _timebetweenOrderNotification = 1;
            return;
        }

        Debug.Log("we have Order on " + FoodItems[rand]);


        Orders[FoodItems[rand]]--;
        _currentOrderCount++;
        _timebetweenOrderNotification = Random.Range(_timeLowerBound, _timeHigherBound);
    }



}
