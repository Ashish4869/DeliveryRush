using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipsManager : MonoBehaviour
{
    /// <summary>
    /// Deals with the tips that we migth get for the service and stores the current tips(score)
    /// </summary>

    Clock _clock;
    int TipsCount = 0;
    float TipsModifier = 0.4f;

    [SerializeField]
    TextMeshProUGUI TipsText;
    private void Awake()
    {
        _clock = FindObjectOfType<Clock>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementTips(string OrderTime)
    {
        string Time = _clock.GetTime();

        int OrderedTime = GetTimeInMinutes(OrderTime);
        int DeliveredTime = GetTimeInMinutes(Time);

        CalculateTips(OrderedTime, DeliveredTime);



    }

    int GetTimeInMinutes(string Time)
    {
        int minTime = 0;
        int hour = int.Parse(Time.Substring(0, 2));
        int min = int.Parse(Time.Substring(3, 2));
        string am_pm = Time.Substring(6, 2);

        if(am_pm == "AM" && hour != 12)
        {
            minTime = hour * 60 + min;
        }
        else
        {
            hour += 12;
            minTime = hour * 60 + min;
        }

        return minTime;
    }

    void CalculateTips(int OrderTime , int DeliveredTime)
    {
        if((DeliveredTime - OrderTime)  < 30)
        {
            TipsCount = (int)(TipsModifier * (30 - (DeliveredTime - OrderTime)));
            TipsText.text = TipsCount.ToString("00000000");

        }
    }
}
