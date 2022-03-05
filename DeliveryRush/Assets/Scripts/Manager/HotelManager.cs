using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelManager : MonoBehaviour
{

    /// <summary>
    /// This script deals with choosing and instantiating food items
    /// </summary>
    
    EventManager eventManager;

    [SerializeField]
    GameObject package;

   

    FoodPackageSO _OrderedFood;
    Vector3 _hotelPos;

    SpriteRenderer _packageSprite;

    private void Awake()
    {
        eventManager = FindObjectOfType<EventManager>();
        _packageSprite = package.GetComponent<SpriteRenderer>();
    }

    

    // Start is called before the first frame update
    void Start()
    {
        EventManager.OnPackageOrdered += OrderFood;
    }

   

    void OrderFood(FoodPackageSO FoodItem)
    {
       _packageSprite.sprite = _OrderedFood.GetFoodSprite();
        StartCoroutine(SpawnPackageAfterLoading(FoodItem.GetPrepTime()));
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
        eventManager.OnPackageOrderedEvent(FoodItem);
    }

    IEnumerator SpawnPackageAfterLoading(int prepTime)
    {
        yield return new WaitForSeconds(prepTime);
        SpawnPackage(_hotelPos);
    }

}
