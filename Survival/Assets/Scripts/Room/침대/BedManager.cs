using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedManager : MonoBehaviour
{
    public GameObject window;
    void Start()
    {
        
    }

    void Update()
    {
        string time = GameManager.gameManager.time.ToString("00.00");
        time = time.Replace(".", " : ");
        transform.GetChild(0).GetComponent<Text>().text = "침대에서 주무시겠습니까?\n\n남은시간: " + time + "\nHp, MT 회복량: " + (int)(GameManager.gameManager.time / 2);
    }

    public void OnYesClicked()
    {
        GameManager.gameManager.hp += (GameManager.gameManager.time / 2);
        GameManager.gameManager.mt += (GameManager.gameManager.time / 2);
        GameManager.gameManager.time = 24;
        OnNoClicked();
    }

    public void OnNoClicked()
    {
        window.SetActive(false);
    }
}
