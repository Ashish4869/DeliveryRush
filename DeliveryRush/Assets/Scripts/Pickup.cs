using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    ///<summary>
    ///This script triggers the event that a pickup as been obtained
    ///</summary>

    GameManager gameManager;
    int pickupID;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameManager.OnPackagePickedEvent();
            gameManager.RepositionElement(this.gameObject);
        }
    }

    public void SetPickUpID(int id)
    {
        pickupID = id;
    }
}
