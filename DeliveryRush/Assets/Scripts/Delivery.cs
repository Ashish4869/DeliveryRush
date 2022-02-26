using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    ///<summary>
    ///deals with the delivery of the food to customer and triggers event package has been delivered
    ///</summary>

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameManager.OnPackageDeliveredEvent();
        }
        gameManager.RepositionElement(this.gameObject);
    }

    
}
