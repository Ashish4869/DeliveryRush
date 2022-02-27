using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelManager : MonoBehaviour
{

    /// <summary>
    /// This script deals with choosing and instantiating food items
    /// </summary>
    
    GameManager gameManager;

    [SerializeField]
    GameObject package;

    FoodPackageSO _OrderedFood;
    Vector3 _hotelPos;

    SpriteRenderer _packageSprite;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        _packageSprite = package.GetComponent<SpriteRenderer>();
    }

    

    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnPackageOrdered += OrderFood;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            //gameManager.OnPackageOrderedEvent(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //gameManager.OnPackageOrderedEvent(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            //gameManager.OnPackageOrderedEvent(2);
        }

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
        GameManager.OnPackageOrdered -= OrderFood;
    }

    public void InitiateOrder(FoodPackageSO FoodItem , Vector3 HotelPosition)
    {
        _OrderedFood = FoodItem;
        _hotelPos = HotelPosition;
        gameManager.OnPackageOrderedEvent();
    }

}
