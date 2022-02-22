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

    [SerializeField]
    GameObject package;

    public void OnPackagePickedEvent()
    {
        if(OnPackagePicked != null)
        {
            OnPackagePicked();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPackage();
        }
    }

    void SpawnPackage()
    {
        Instantiate(package, transform.position, Quaternion.identity);
    }
}
