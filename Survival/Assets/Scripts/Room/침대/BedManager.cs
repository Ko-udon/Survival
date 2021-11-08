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
        transform.GetChild(0).GetComponent<Text>().text = "침대에서 주무시겠습니까?\n\n남은시간: " + GameManager.gameManager.time + "\nHp, MT 회복량: " + (GameManager.gameManager.time / 2);
    }

    public void OnYesClicked()
    {
        GameManager.gameManager.hp += (GameManager.gameManager.time / 2);
        GameManager.gameManager.mt += (GameManager.gameManager.time / 2);
        GameManager.gameManager.time = 0;
        OnNoClicked();
    }

    public void OnNoClicked()
    {
        window.SetActive(false);
    }
}
