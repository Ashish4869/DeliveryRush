using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// This class does the following
    /// 1.Control movement
    /// 2.Controls speed based on whether the car is on the road
    /// 3.Disables Player when map is shown
    /// </summary>


    [SerializeField] float _onRoadSpeed = 10f;
    [SerializeField] float _offRoadSpeed = 3f;

    float _speed = 10f;
    float _rotationSpeed = 125f;
    bool _onRoad = true;
    bool _canDrive = true;

   

    SpriteRenderer _carSprite;
    PlayerSoundController _playerSoundController;

    private void Awake()
    {
        EventManager.OnShowMap += DisablePlayer;
        _playerSoundController = GetComponent<PlayerSoundController>();
        
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

        //change the speed on going offroad/onroad
        _speed = (_onRoad ? _onRoadSpeed : _offRoadSpeed);


        //make sure the player cant drive when the seeing the map
        if (!_canDrive)
        {
            _speed = 0;
        }

        //forward-backward movement of the vehicle
        if (verticalDirection != 0)
        {
            transform.Translate(Vector3.up * (verticalDirection > 0 ? _speed : _speed /3) * verticalDirection * Time.deltaTime);
        }

        //turn only when you are moving
        if (horizontalDirection != 0 && verticalDirection !=0)
        {
            transform.Rotate(new Vector3(0, 0, _rotationSpeed * horizontalDirection * Time.deltaTime));
        }

        _playerSoundController.SoundHandler(verticalDirection, horizontalDirection, _onRoad);
    }

    //Deals with the speed of the car based on the on its on
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("OffRoad"))
        {
            _onRoad =false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("OffRoad"))
        {
            _onRoad = true;
        }
    }

    void DisablePlayer() => _canDrive = !_canDrive;


    private void OnDestroy()
    {
        EventManager.OnShowMap -= DisablePlayer;
    }
}
