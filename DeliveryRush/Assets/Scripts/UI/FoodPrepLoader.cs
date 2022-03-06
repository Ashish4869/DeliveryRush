using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FoodPrepLoader : MonoBehaviour
{

    /// <summary>
    /// for updating the loading bar and then making it possible to pack the food to parcel
    /// </summary>
    
    [SerializeField]
    Image _loader;

    [SerializeField]
    GameObject FoodLoader;

    [SerializeField]
    Image _foodImage;

    float _foodPrepTime = 5;



    float _remaingPrepTime;
    bool _showLoading = false;

    HotelUIManager hoteluiManager;

    void Start()
    {
        hoteluiManager = FindObjectOfType<HotelUIManager>();
        EventManager.OnPackageOrdered += ShowAnimation;
    }

    // Update is called once per frame
    void Update()
    {
        if (_showLoading)
        {
            if (_remaingPrepTime > 0)
            {
                float loaderValue = (_foodPrepTime - _remaingPrepTime) / _foodPrepTime;
                _remaingPrepTime -= Time.deltaTime;
                _loader.rectTransform.localScale = new Vector3(_loader.rectTransform.localScale.x, loaderValue, _loader.rectTransform.localScale.z);
            }
            else
            {
                hoteluiManager.FoodPrepared();
            }
        }
        
    }

    void ShowAnimation(FoodPackageSO FoodItem)
    {
        _foodPrepTime = FoodItem.GetPrepTime();
        _remaingPrepTime = _foodPrepTime;
        _showLoading = true;
        FoodLoader.SetActive(true);
        _foodImage.sprite = FoodItem.GetFoodSprite();
        
    }
}
