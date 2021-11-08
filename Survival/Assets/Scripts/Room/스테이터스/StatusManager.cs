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
        timeText.text = (24 - GameManager.gameManager.time) + "½Ã";
        HPGauge.fillAmount = GameManager.gameManager.hp / 100;
        MTGauge.fillAmount = GameManager.gameManager.mt / 100;
    }
}
