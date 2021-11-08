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
        transform.GetChild(0).GetComponent<Text>().text = "침대에서 주무시겠습니까?\n\n남은시간: " + (24 - GameManager.gameManager.time) + "시간\nHp, MT 회복량: " + ((24 - GameManager.gameManager.time) / 2);
    }

    public void OnYesClicked()
    {
        GameManager.gameManager.hp += ((24 - GameManager.gameManager.time) / 2);
        GameManager.gameManager.mt += ((24 - GameManager.gameManager.time) / 2);
        GameManager.gameManager.time = 24;
        OnNoClicked();
    }

    public void OnNoClicked()
    {
        window.SetActive(false);
    }
}
