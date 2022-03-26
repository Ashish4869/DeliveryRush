using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarData : MonoBehaviour
{
    /// <summary>
    /// Deals with passing the car data from scene to another
    /// </summary>
    
    CarSO SelectedCar;

    public static CarData instance;

    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SetSelectedCar(CarSO car)
    {
        SelectedCar = car;
    }

    public CarSO GetSelectedCar()
    {
        return SelectedCar;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
