using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    GameObject ScoreSystem;

    [SerializeField]
    GameObject FoodScoreStatusPrefab;

    [SerializeField]
    GameObject OrderDeliveryStatus;

    [SerializeField]
    GameObject[] Stars;

    [SerializeField]
    Image ScoreLoader;

    [SerializeField]
    GameObject ScoreButtons;

    [SerializeField]
    int MaxScoreOfLevel;

    [SerializeField]
    int MaxMinutes  ;




    GameManager _gameManager;
    OrderManager _orderManager;
    TipsManager tipsManager;

    Dictionary<FoodPackageSO, int> OrdersDelivered = new Dictionary<FoodPackageSO, int>();
    Dictionary<string, int> OrderCount;
    
    FoodPackageSO[] FoodItems;

    int TipsCount = 0;
    int StartTime;
    int EndTime;
    int counter = 0;
    int ScoreLoadSpeed = 5;
    
    public float Scorecount = 0;
    public float ScoreCountingTotal = 0;

    float ScoreScored = 0;

    int level;




    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _orderManager = FindObjectOfType<OrderManager>();
        tipsManager = FindObjectOfType<TipsManager>();
    }

    private void Start()
    {
        EventManager.OnGameOver += ShowScores;
        OrdersDelivered.Clear();

        level = SceneManager.GetActiveScene().buildIndex;
    }

    void ShowScores()
    {
        GetScoreValues();
        ScoreSystem.SetActive(true);
        UpdateDeliveryStatusCount();
        LoadScoreBar();
    }

    void UpdateDeliveryStatusCount()
    {
        foreach (var Food in FoodItems)
        {
            GameObject child = Instantiate(FoodScoreStatusPrefab);
            child.transform.SetParent(OrderDeliveryStatus.transform);
            child.transform.localScale = new Vector3(1, 1, 1);

            Image[] images = child.GetComponentsInChildren<Image>();

            foreach (var image in images)
            {
                if (image.sprite != null)
                {
                    image.sprite = Food.GetFoodSprite();
                }
            }

            TextMeshProUGUI scoreText = child.GetComponentInChildren<TextMeshProUGUI>();

            StartCoroutine(CountUp(scoreText, OrdersDelivered[Food]));

        }
    }
    IEnumerator CountUp(TextMeshProUGUI text, int score)
    {
        int value = 0;

        while (value != score)
        {
            yield return new WaitForSeconds(0.5f);
            text.text = "X " + (value).ToString();
            value++;
        }

        yield return new WaitForSeconds(0.5f);
        text.text = "X " + (score).ToString();
    }

    void LoadScoreBar()
    {
        float LoaderValue = 0;
        StartCoroutine(ScoreBar(LoaderValue));
    }

    IEnumerator ScoreBar(float LoaderValue)
    {
        int i= 0 ;

        while((ScoreCountingTotal < ScoreScored) && (ScoreCountingTotal < MaxScoreOfLevel))
        {
            yield return null;
            LoaderValue = Scorecount / (MaxScoreOfLevel / 3);

            if(LoaderValue > 1)
            {
                LoaderValue = 0;
                Scorecount = 0;
                Stars[i].GetComponent<Animator>().SetTrigger("LightUp");
                i++;
                FindObjectOfType<AudioManager>().Play("PickOrder");
            }

            ScoreCountingTotal += 0.3f;
            Scorecount += 0.3f;
            ScoreLoader.transform.localScale = new Vector3(LoaderValue, ScoreLoader.transform.localScale.y, ScoreLoader.transform.localScale.z);
        }

        if(!PlayerPrefs.HasKey("Level" + level + "Stars"))
        {
            PlayerPrefs.SetInt("Level" + level + "Stars", i);
        }
        else if(PlayerPrefs.GetInt("Level" + level + "Stars") < i)
        {
            PlayerPrefs.SetInt("Level" + level + "Stars", i);
        }
       
        ShowButtons();
    }

    void ShowButtons()
    {
        ScoreButtons.SetActive(true);
    }

    void GetScoreValues()
    {
        OrderCount = _gameManager.GetOrderCount();
        FoodItems = _orderManager.GetFoodItems();
        TipsCount = tipsManager.GetTipsCount();
        StartTime = tipsManager.GetStartTime();
        EndTime = tipsManager.GetEndTime();

        for (int i = 0; i < FoodItems.Length; i++)
        {
            if(!OrdersDelivered.ContainsKey(FoodItems[i]))
            {
                OrdersDelivered.Add(FoodItems[i], OrderCount[FoodItems[i].GetFoodName()]);
            }
        }

        if (MaxMinutes - (EndTime - StartTime) < 0)
        {
            ScoreScored = TipsCount;
        }
        else
        {
            ScoreScored = TipsCount + (MaxMinutes - (EndTime - StartTime));
        }

       

        if (PlayerPrefs.HasKey("Level" + level + "BestTime"))
        {
            if (PlayerPrefs.GetInt("Level" + level + "BestTime") > (EndTime - StartTime))
            {
                PlayerPrefs.SetInt("Level1BestTime", (EndTime - StartTime));
            }
        }
        else
        {
            PlayerPrefs.SetInt("Level1BestTime", (EndTime - StartTime));
        }
        
        if(PlayerPrefs.HasKey("Level" + level + "Tips"))
        {
            if(PlayerPrefs.GetInt("Level" + level + "Tips") < TipsCount)
            {
                PlayerPrefs.SetInt("Level" + level + "Tips", TipsCount);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Level" + level + "Tips", TipsCount);
        }
        
        
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        EventManager.OnGameOver -= ShowScores;
    }


    
}
