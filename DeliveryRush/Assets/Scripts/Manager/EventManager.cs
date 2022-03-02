using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    /// <summary>
    /// Takes care of the events in the game , the events are :
    /// 
    /// 1.OnPackagePicked - event fired when the package has been picked by the player and the following takes place when the event is fired
    ///     1.Arrow.cs - The arrow functionality is activated
    ///     2.DeliveryManager.cs - The destination for delivery is selected and is brought in scene
    ///     
    /// 2.OnPackageDelivered
    /// 
    /// 3.OnPackageDelivered
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
