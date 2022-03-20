using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ///<summary>
    ///controls the games actions and interacts with other managers
    ///</summary>

    public string _currentFoodInCar = "";
    Dictionary<string, int> OrderCount = new Dictionary<string, int>();

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("BackGroundNoise");
        FindObjectOfType<AudioManager>().Play("BGMUSIC");

        EventManager.OnPackageDelivered += IncrementDeliveredCount;
    }


    public void RepositionElement(GameObject gameobject)
    {
        gameobject.transform.position = new Vector3(2000, 6000, 100);
    }

    public void CurrentPackage(string food)
    {
        _currentFoodInCar = food;
    }

    public string GetCurrentFoodInCar() => _currentFoodInCar;

    public void RemoveCurrentFood() => _currentFoodInCar = "";

    public void GetFoodItemsOnLevel(FoodPackageSO[] foodItems)
    {
        for (int i = 0; i < foodItems.Length; i++)
        {
            OrderCount.Add(foodItems[i].GetFoodName(), 0);
        }
    }

    void IncrementDeliveredCount()
    {
        OrderCount[_currentFoodInCar]++;
        _currentFoodInCar = "";
    }

    public Dictionary<string, int> GetOrderCount()
    {
        return OrderCount;
    }

    private void OnDestroy()
    {
        EventManager.OnPackageDelivered -= IncrementDeliveredCount;
    }



}
