using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectManager : MonoBehaviour
{
    /// <summary>
    /// Deals with showing the saved info on the levels
    /// </summary>

    [SerializeField]
    GameObject ButtonGroup;

    [SerializeField]
    Color yellow;

    [SerializeField]
    Color black;

    [SerializeField]
    Sprite star;

 
    public void ConfigureLevels()
    {
        ButtonActivity();
        SetScores();
    }

    void ButtonActivity()
    {
        Button[] buttons = ButtonGroup.GetComponentsInChildren<Button>();
        buttons[0].interactable = true;

        int i = 2;

        while(i <= 4)
        { 
            if(PlayerPrefs.HasKey("Level" + (i - 1).ToString() + "BestTime"))
            {
                if(PlayerPrefs.GetInt("Level" + (i - 1).ToString() + "Stars") > 1)
                {
                    buttons[i - 1].interactable = true;
                }
            }
            else
            {
                buttons[i - 1].interactable = false;
            }

            i++;
        }
    }

    void SetScores()
    {
        int i = 1;

        foreach (Transform item in ButtonGroup.transform)
        {
            TextMeshProUGUI[] texts = item.GetComponentsInChildren<TextMeshProUGUI>();

            if (!PlayerPrefs.HasKey("Level" + i + "BestTime"))
            {

                return;
            }
            else
            {
                foreach (var text in texts)
                {
                    if (text.text.StartsWith("Best Time :"))
                    {
                        int[] time = MinToHour(PlayerPrefs.GetInt("Level" + i + "BestTime"));
                        text.text = "Best Time : " + time[0] + " hr " + time[1] + " min";
                    }

                    if (text.text.StartsWith("Max Tips :"))
                    {
                        text.text = "Max Tips : $" + PlayerPrefs.GetInt("Level" + i + "Tips");
                    }
                }
            }


            if (!PlayerPrefs.HasKey("Level" + i + "Stars"))
            {
                return;
            }
            else
            {
                int j = PlayerPrefs.GetInt("Level" + i + "Stars");
                while (j != 0)
                {
                    Image[] images = item.GetComponentsInChildren<Image>();

                    foreach (var image in images)
                    {
                        if (image.sprite == star)
                        {
                            image.color = yellow;
                            j--;
                        }

                    }
                }
            }
            i++;
        }
    }

   int[] MinToHour(int time)
   {
        int[] t1 = new int[2];

        t1[0] = time / 60;
        t1[1] = time % 60;

        return t1;
   }
}
