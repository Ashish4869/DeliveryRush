using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FoodPrepLoader : MonoBehaviour
{

    /// <summary>
    /// for updating the loading bar and then destroying it once its done its job and put the real food sprite
    /// </summary>
    [SerializeField]
    Image _loader;

    [SerializeField]
    GameObject _foodLoader;

    [SerializeField]
    Image _foodImage;

    [SerializeField]
    float _foodPrepTime = 5;

    float _remaingPrepTime;
    bool _showLoading = false;

    void Start()
    {
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
                _foodLoader.gameObject.SetActive(false);
            }
        }
        
    }

    void ShowAnimation(FoodPackageSO FoodItem)
    {
        _foodPrepTime = FoodItem.GetPrepTime();
        _remaingPrepTime = _foodPrepTime;
        _showLoading = true;
        _foodLoader.gameObject.SetActive(true);
        _foodImage.sprite = FoodItem.GetFoodSprite();

    }
}
