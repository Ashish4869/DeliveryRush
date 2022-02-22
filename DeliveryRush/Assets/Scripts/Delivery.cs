using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    ///<summary>
    ///deals with the delivery of the food to customer
    ///</summary>
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SpriteRenderer playerSprite = collision.GetComponent<SpriteRenderer>();

            if(playerSprite != null)
            {
                playerSprite.color = Color.white;
            }
        }
        RepositionMarker();
    }

    void RepositionMarker()
    {
        transform.position = new Vector3(1000, 1000, 0);
    }
}
