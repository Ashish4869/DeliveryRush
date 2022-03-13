using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ///<summary>
    ///controls the games actions and interacts with other managers
    ///</summary>

    string _currentFoodInCar = "";

  

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
    
}
