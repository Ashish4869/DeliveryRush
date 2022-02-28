using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    /// <summary>
    /// Deals with all the events that happend in the game
    /// </summary>


    public delegate void PackagePicked();
    public static event PackagePicked OnPackagePicked;

    public delegate void PackageDelivered();
    public static event PackageDelivered OnPackageDelivered;

    public delegate void PackageOrdered();
    public static event PackageOrdered OnPackageOrdered;

    public void OnPackagePickedEvent()
    {
        if (OnPackagePicked != null)
        {
            OnPackagePicked();
        }
    }

    public void OnPackageDeliveredEvent()
    {
        if (OnPackageDelivered != null)
        {
            OnPackageDelivered();
        }
    }

    public void OnPackageOrderedEvent()
    {
        if (OnPackageOrdered != null)
        {
            OnPackageOrdered();
        }
    }
   
}
