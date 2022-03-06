using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotel : MonoBehaviour
{
    /// <summary>
    /// Deals with placing order that you can make on a particular hotel
    /// </summary>
   

    [Header("Hotel Information")]
    [SerializeField]
    int _HotelID;

    [SerializeField]
    GameObject _orderUI;

    [SerializeField]
    string _hotelName;

    [SerializeField]
    private List<FoodPackageSO> _foodItems;


    [Header("Related Components")]
    [SerializeField]
    Transform _packageSpawnPoint;




    EventManager _eventManager;
    HotelManager _hotelManager;

    bool _CanOrder = false;

    private void Awake()
    {
        _hotelManager = GetComponentInParent<HotelManager>();
        _eventManager = FindObjectOfType<EventManager>();

    }
    public int GetHotelID()
    {
        return _HotelID;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _CanOrder)
        {
            _eventManager.OnOrderingfromRestaurantEvent(_foodItems);
        }
        
    }

    void CheckIfItemPresent(int id)
    {
       if(id <= _foodItems.Count)
       {
            _hotelManager.InitiateOrder(_foodItems[id-1], _packageSpawnPoint.position);
       }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _orderUI.SetActive(true);
        }
        _CanOrder = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _orderUI.SetActive(false);
        }
        _CanOrder = false;
    }

}
