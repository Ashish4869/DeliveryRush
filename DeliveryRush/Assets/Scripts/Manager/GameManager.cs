using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ///<summary>
    ///controls the games actions and interacts with other managers
    ///</summary>

    [SerializeField]


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {

        }
    }
    public void RepositionElement(GameObject gameobject)
    {
        gameobject.transform.position = new Vector3(2000, 6000, 100);
    }
}
