using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelManager : MonoBehaviour
{

    /// <summary>
    /// Retreives info from a hotel and Places the food package at the appropriate place
    /// </summary>

    [SerializeField]
    GameObject package;

    SpriteRenderer _packageSprite;

    private void Awake()
    {
        _packageSprite = package.GetComponent<SpriteRenderer>();
    }

    void SpawnPackage(Vector3 HotelPosition) => package.transform.position = HotelPosition;

    //gets the location and food to be spawned
    public void InitiateOrder(Vector3 HotelPosition , FoodPackageSO Food)
    {
        _packageSprite.sprite = Food.GetFoodSprite();
        SpawnPackage(HotelPosition);
    }

}
