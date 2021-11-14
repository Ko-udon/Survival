using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    public Text dayText;
    public Text timeText;
    public Image HPGauge;
    public Image MTGauge;

    void Start()
    {
        dayText = GameObject.Find("DayText").GetComponent<Text>();
        timeText = GameObject.Find("TimeText").GetComponent<Text>();
        HPGauge = GameObject.Find("HPGauge").GetComponent<Image>();
        MTGauge = GameObject.Find("MTGauge").GetComponent<Image>();
    }

    void Update()
    {
        dayText.text = "Day " + GameManager.gameManager.day;
        if(GameManager.gameManager.time == 0)
        {
            timeText.text = "24 : 00";
        }
        else
        {
            timeText.text = (GameManager.gameManager.time / 60) + " : " + (GameManager.gameManager.time % 60).ToString("00");
        }
        HPGauge.fillAmount = GameManager.gameManager.hp / 100;
        MTGauge.fillAmount = GameManager.gameManager.mt / 100;
    }
}
