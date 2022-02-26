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

    SpriteRenderer _packageSprite;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        _packageSprite = package.GetComponent<SpriteRenderer>();
    }

    

    public List<FoodPackageSO> foodItems;

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
            OrderFood(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OrderFood(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            OrderFood(2);
        }

    }

    void OrderFood(int id)
    {
        Debug.Log("You have Ordered : " + foodItems[id].GetFoodName());
        _packageSprite.color = foodItems[id].GetFoodColor();
        SpawnPackage();
    }

    void SpawnPackage()
    {
        Instantiate(package, transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        GameManager.OnPackageOrdered -= OrderFood;
    }

}
