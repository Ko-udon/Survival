using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangerManager : MonoBehaviour
{
    public Sprite defultImage;
    public GameObject equipWindow;
    public GameObject infoWindow;
    public GameObject equipInfo;

    public GameObject canvas;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(GameManager.gameManager.equip_head == "")
        {
            transform.GetChild(0).GetComponent<Image>().sprite = defultImage;
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().sprite = GameManager.gameManager.name_image[GameManager.gameManager.equip_head];
        }

        if (GameManager.gameManager.equip_hand == "")
        {
            transform.GetChild(1).GetComponent<Image>().sprite = defultImage;
            transform.GetChild(2).GetComponent<Image>().sprite = defultImage;
        }
        else
        {
            transform.GetChild(1).GetComponent<Image>().sprite = GameManager.gameManager.name_image[GameManager.gameManager.equip_hand];
            transform.GetChild(2).GetComponent<Image>().sprite = GameManager.gameManager.name_image[GameManager.gameManager.equip_hand];
        }

        if(GameManager.gameManager.equip_body == "")
        {
            transform.GetChild(3).GetComponent<Image>().sprite = defultImage;
        }
        else
        {
            transform.GetChild(3).GetComponent<Image>().sprite = GameManager.gameManager.name_image[GameManager.gameManager.equip_body];
        }

        if (GameManager.gameManager.equip_shoes == "")
        {
            transform.GetChild(4).GetComponent<Image>().sprite = defultImage;
        }
        else
        {
            transform.GetChild(4).GetComponent<Image>().sprite = GameManager.gameManager.name_image[GameManager.gameManager.equip_shoes];
        }

        if (GameManager.gameManager.equip_skill == "")
        {
            transform.GetChild(5).GetComponent<Image>().sprite = defultImage;
        }
        else
        {
            transform.GetChild(5).GetComponent<Image>().sprite = GameManager.gameManager.name_image[GameManager.gameManager.equip_skill];
        }
    }

    public void OnOpenClicked(string parts)
    {
        equipWindow.SetActive(true);
        equipWindow.GetComponent<EquipInventory>().parts = parts;
    }

    public void OnCloseClicked()
    {
        equipInfo.SetActive(false);
        infoWindow.SetActive(false);
        equipWindow.SetActive(false);
    }

    public void OnExitClicked()
    {
        OnCloseClicked();
        canvas.SetActive(false);
    }
}
