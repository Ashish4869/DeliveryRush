using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    ///<summary>
    ///This script triggers the event that a pickup as been obtained
    ///</summary>


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SpriteRenderer playerSprite = collision.GetComponent<SpriteRenderer>();

            if(playerSprite != null)
            {
                playerSprite.color = Color.green;
            }
            FindObjectOfType<GameManager>().OnPackagePickedEvent();
            Destroy(gameObject);
        }
    }
}
