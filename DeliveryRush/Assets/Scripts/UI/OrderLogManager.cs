using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderLogManager : MonoBehaviour
{
    /// <summary>
    /// Updates the log of the orders
    /// </summary>

    [SerializeField]
    TextMeshProUGUI _OrdersPendingText;

    [SerializeField]
    GameObject _tableComponent;

    [SerializeField]
    GameObject _OrderPrefab;

    GameObject OrderLogListGameObject;
    int _orderPendingCount = 0;
    bool _showTable = false;

    List<List<string>> _OrderPendingList = new List<List<string>>();

    // Start is called before the first frame update
    void Start()
    {
        EventManager.OnOrderReceived += UpdateOrderLog;
    }


    void UpdateOrderLog(string OrderDetails , int foodID)
    {
        string[] order = OrderDetails.Split('-');

        _OrderPendingList.Add(new List<string>());

        foreach (var item in order)
        {
            _OrderPendingList[_orderPendingCount].Add(item);
        }

        _orderPendingCount += 1;

        UpdateUI();
    }


    void UpdateUI()
    {
        _OrdersPendingText.text = "Orders Pending (" + _orderPendingCount.ToString() + ")";

        if(_showTable == true)
        {
            ConfigureOrderList();
        }
    }

    public void ShowTable()
    {
        _showTable = !_showTable;
        _tableComponent.SetActive(_showTable);

        if(_showTable == false)
        {
            return;
        }
        ConfigureOrderList();
    }

    void ConfigureOrderList()
    {
        OrderLogListGameObject = GameObject.Find("OrderStatus/TableComponent/OrderLogList");


        if (OrderLogListGameObject.transform.childCount != 0)
        {
            foreach (Transform item in OrderLogListGameObject.transform)
            {
                Destroy(item.gameObject);
            }
        }

        int max = Mathf.Min(_OrderPendingList.Count, 9);
        for (int i = 0; i < max; i++)
        {
            GameObject child = Instantiate(_OrderPrefab);
            child.transform.SetParent(OrderLogListGameObject.transform);
            child.transform.localScale = new Vector3(1, 1, 1);

            TextMeshProUGUI[] texts = child.GetComponentsInChildren<TextMeshProUGUI>();

            for (int j = 0; j < 3; j++)
            {
                texts[j].text = _OrderPendingList[i][j];
            }
        }
    }
}
