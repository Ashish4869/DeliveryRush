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
        int i = 1;
        foreach (Transform item in ButtonGroup.transform)
        {
            TextMeshProUGUI[] texts = item.GetComponentsInChildren<TextMeshProUGUI>();

            if(!PlayerPrefs.HasKey("Level" + i + "BestTime"))
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
                while (j!=0)
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
