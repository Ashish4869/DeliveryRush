using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ///<summary>
    ///controls the games actions
    ///</summary>
    

    public void RepositionElement(GameObject gameobject)
    {
        gameobject.transform.position = new Vector3(2000, 6000, 100);
    }
}