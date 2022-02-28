using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    /// <summary>
    /// Deals with the showing delivery at some random predefined locations
    /// </summary>

    [SerializeField]
    List<Transform> locations;
    Delivery delivery;


    private void Start()
    {
       delivery = GetComponentInChildren<Delivery>();
       EventManager.OnPackagePicked += ShowDeliveryMarker;
    }

    void ShowDeliveryMarker()
    {
        int prev = -1;
        int i = Random.Range(0, 3);

        if(prev == i)
        {
            i = Random.Range(0, 3);
        }

        delivery.transform.position = locations[i].position;
        prev = i;
    }

    private void OnDestroy()
    {
        EventManager.OnPackagePicked -= ShowDeliveryMarker;
    }
}
