using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    /// <summary>
    /// This scripts deals with arrow pointing towards the destination after the packaged is picked
    /// </summary>
    // Start is called before the first frame update

    [SerializeField] Transform delivery;
    [SerializeField] Transform player;
    void Start()
    {
        
    }

    private void Update()
    {
        PointToDestination();
        TiltToDestination();
    }


    void PointToDestination()
    {
        float x = transform.position.x - delivery.position.x;
        float y = transform.position.y - delivery.position.y;
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void TiltToDestination()
    {
        transform.position = player.position - transform.right;
    }

   
}
