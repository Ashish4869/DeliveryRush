using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// This class does the following
    /// 1.Control movement
    /// 2.Sets Colors when package picked and delivered
    /// </summary>
    

    float _speed = 10f;
    float _rotationSpeed = 1.0f;
    SpriteRenderer _carSprite;


    private void Awake()
    {
        EventManager.OnPackagePicked += HighlightCar;
        EventManager.OnPackageDelivered += RemoveHighlight;
    }

    private void Start()
    {
        _carSprite = GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        CalcMovment();
    }


    void CalcMovment()
    {
        float verticalDirection = Input.GetAxisRaw("Vertical");
        float horizontalDirection = -Input.GetAxisRaw("Horizontal");

        //forward-backward movement of the vehicle
        if (verticalDirection != 0)
        {
            transform.Translate(Vector3.up * (verticalDirection > 0 ? _speed : _speed /3) * verticalDirection * Time.deltaTime);
        }

        //turn only when you are moving
        if (horizontalDirection != 0 && verticalDirection !=0)
        {
            transform.Rotate(new Vector3(0, 0, _rotationSpeed * horizontalDirection));
        }
        
    }

    //Highlight car when the package is picked
    void HighlightCar() => _carSprite.color = Color.green;
  

    //Remove the highlight when the package is delivered
    void RemoveHighlight() => _carSprite.color = Color.white;
   

    private void OnDestroy()
    {
        EventManager.OnPackagePicked -= HighlightCar;
        EventManager.OnPackageDelivered -= RemoveHighlight;
    }


}
