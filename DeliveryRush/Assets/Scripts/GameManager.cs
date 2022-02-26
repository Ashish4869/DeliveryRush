using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ///<summary>
    ///controls the games actions
    ///</summary>
    

    public delegate void PackagePicked();
    public static event PackagePicked OnPackagePicked;

    public delegate void PackageDelivered();
    public static event PackageDelivered OnPackageDelivered;

    public delegate void PackageOrdered(int ID);
    public static event PackageOrdered OnPackageOrdered;

 

    public void OnPackagePickedEvent()
    {
        if(OnPackagePicked != null)
        {
            OnPackagePicked();
        }
    }

    public void OnPackageDeliveredEvent()
    {
        if(OnPackageDelivered != null)
        {
            OnPackageDelivered();
        }
    }

    public void OnPackageOrderedEvent()
    {
        if (OnPackageOrdered != null)
        {
            OnPackageOrdered(1);
        }
    }

 


    public void RepositionElement(GameObject gameobject)
    {
        gameobject.transform.position = new Vector3(2000, 6000, 0);
    }
}
