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

    int StartTime;
    int EndTime;

    [SerializeField]
    TextMeshProUGUI TipsText;
    private void Awake()
    {
        _clock = FindObjectOfType<Clock>();
    }

    private void Start()
    {
        string Time = _clock.GetTime();
        StartTime = GetTimeInMinutes(Time);
    }

    public void IncrementTips(string OrderTime)
    {
        //Gets the current time 
        string Time = _clock.GetTime();

        int OrderedTime = GetTimeInMinutes(OrderTime);
        int DeliveredTime = GetTimeInMinutes(Time);

        CalculateTips(OrderedTime, DeliveredTime); //Calculates the tips to be added to the UI
    }

    int GetTimeInMinutes(string Time) //converts the time formatted value into minutes
    {
        int minTime = 0;
        int hour = int.Parse(Time.Substring(0, 2)); //gets the hour part
        int min = int.Parse(Time.Substring(3, 2)); //gets the minute part
        string am_pm = Time.Substring(6, 2); //gets of its AM or PM

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
        if((DeliveredTime - OrderTime)  < 60) //give tips only if delivered with 30 min of delivery
        {
            TipsCount += (int)(TipsModifier * (60 - (DeliveredTime - OrderTime))); //adds the time to the total tips count
            TipsText.text = TipsCount.ToString("00000000");
        }
    }

    public int GetTipsCount()
    {
        return TipsCount;
    }

    public int GetStartTime()
    {
        return StartTime;
    }

    public int GetEndTime()
    {
        string Time = _clock.GetTime();
        EndTime = GetTimeInMinutes(Time);
        return EndTime;

    }
}
