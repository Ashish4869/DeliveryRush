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
        GameManager.OnPackagePicked += ShowDeliveryMarker;
    }

    void ShowDeliveryMarker()
    {
        delivery.transform.position = locations[0].position;
    }

    private void OnDestroy()
    {
        GameManager.OnPackagePicked -= ShowDeliveryMarker;
    }
}
