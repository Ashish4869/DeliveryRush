using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    /// <summary>
    /// Shows the map and ui when the P key is pressed
    /// </summary>

    [SerializeField]
    GameObject GameMap;

    [SerializeField]
    GameObject LegendUI;


    EventManager eventManager;

    bool _showMap = false;

    // Start is called before the first frame update
    void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
        EventManager.OnShowMap += ShowMap;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            eventManager.OnShowMapEvent();
        }

        if (_showMap)
        {
            GameMap.SetActive(true);
            LegendUI.SetActive(true);
        }   
        else
        {
            GameMap.SetActive(false);
            LegendUI.SetActive(false);
        }
        
    }

    void ShowMap()
    {
        FindObjectOfType<AudioManager>().Play("MapSound");
        _showMap = !_showMap;
    }

    private void Destroy()
    {
        EventManager.OnShowMap -= ShowMap;
    }
}
