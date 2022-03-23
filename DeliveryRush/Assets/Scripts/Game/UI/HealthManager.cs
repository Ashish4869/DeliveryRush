using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    /// <summary>
    /// Deals with showing the health bar and reducing the health based on the speed of the car
    /// </summary>

    [SerializeField]
    Image Loader;

    float Health = 100;
    float MaxHealth = 100;

    EventManager _eventManager;


    private void Awake()
    {
        _eventManager = FindObjectOfType<EventManager>();
    }


    IEnumerator YouDied() //call game over screen
    {
        Debug.Log("You died");
        yield return new WaitForSeconds(2f);
        //_eventManager.OnGameOverEvent();

        gameObject.SetActive(false);
    }

    public void DecrementHealth(int damage)
    {
        Health -= damage;
        Loader.transform.localScale = new Vector3(Health / MaxHealth, Loader.transform.localScale.y, Loader.transform.localScale.z);

        if(Health <= 0)
        {
            StartCoroutine(YouDied()); 
            _eventManager.OnGameOverEvent(); // create took too much damage event
            Loader.transform.localScale = new Vector3(0, Loader.transform.localScale.y, Loader.transform.localScale.z);
        }
    }

    public float GetCurrentHealth() => Health;
}
