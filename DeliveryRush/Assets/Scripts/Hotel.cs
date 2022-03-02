using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotel : MonoBehaviour
{
    /// <summary>
    /// Deals with placing order that you can make on a particular hotel
    /// </summary>
    [SerializeField]
    Transform _packageSpawnPoint;

    [SerializeField]
    int _HotelID;


    [SerializeField]
    [TextArea(5,3)]
    string message = "";  //later i have to change this to UI

    public List<FoodPackageSO> _foodItems;


    HotelManager _hotelManager;

    bool _CanOrder = false;

    private void Awake()
    {
        _hotelManager = GetComponentInParent<HotelManager>();
    }
    public int GetHotelID()
    {
        return _HotelID;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && _CanOrder)
        {
            CheckIfItemPresent(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) && _CanOrder)
        {
            CheckIfItemPresent(2);
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
            Debug.Log(message);
        }
        _CanOrder = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Leaving Already?");
        }
        _CanOrder = false;
    }

}
