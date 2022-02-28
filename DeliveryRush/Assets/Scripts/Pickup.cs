using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    ///<summary>
    ///This script triggers the event that a pickup as been obtained
    ///</summary>

    EventManager eventManager;
    GameManager gameManager;
    int pickupID;

    private void Awake()
    {
        eventManager = FindObjectOfType<EventManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            eventManager.OnPackagePickedEvent();
            gameManager.RepositionElement(this.gameObject);
        }
    }

    
}
