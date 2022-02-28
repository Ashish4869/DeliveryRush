using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelManager : MonoBehaviour
{

    /// <summary>
    /// This script deals with choosing and instantiating food items
    /// </summary>
    
    GameManager gameManager;
    EventManager eventManager;

    [SerializeField]
    GameObject package;

    FoodPackageSO _OrderedFood;
    Vector3 _hotelPos;

    SpriteRenderer _packageSprite;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        eventManager = FindObjectOfType<EventManager>();
        _packageSprite = package.GetComponent<SpriteRenderer>();
    }

    

    // Start is called before the first frame update
    void Start()
    {
        EventManager.OnPackageOrdered += OrderFood;
    }

   

    void OrderFood()
    {
       _packageSprite.sprite = _OrderedFood.GetFoodSprite();
        SpawnPackage(_hotelPos);
    }

    void SpawnPackage(Vector3 pos)
    {
        package.transform.position = pos;
    }

    private void OnDestroy()
    {
        EventManager.OnPackageOrdered -= OrderFood;
    }

    public void InitiateOrder(FoodPackageSO FoodItem , Vector3 HotelPosition)
    {
        _OrderedFood = FoodItem;
        _hotelPos = HotelPosition;
        eventManager.OnPackageOrderedEvent();
    }

}
