using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public GameObject info_window;
    public GameObject equip_window;
    public GameObject info_background;
    public string item_name;
    public string state;
    public int index;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClicked()
    {
        info_background.SetActive(true);
        info_window.SetActive(true);

        info_window.transform.position = this.transform.position;
        
        if (transform.GetChild(0).GetComponent<Text>().text == "E")
        {
            info_window.transform.GetComponent<InformationWindow>().isEquip = true;
        }
        else
        {
            info_window.transform.GetComponent<InformationWindow>().isEquip = false;
        }
        info_window.transform.GetComponent<InformationWindow>().index = index;
        info_window.transform.GetChild(0).GetComponent<Image>().sprite = this.GetComponent<Image>().sprite;
        info_window.transform.GetChild(1).GetComponent<Text>().text = this.item_name;
        info_window.transform.GetChild(2).GetComponent<Text>().text = GameManager.gameManager.name_info[this.item_name];

        if (state == "Equip" && transform.GetChild(0).GetComponent<Text>().text != "E")
        {
            equip_window.SetActive(true);
            equip_window.transform.position = new Vector2(this.transform.position.x - 471, this.transform.position.y);

            if(GameManager.gameManager.head_inventory.Contains(item_name))
            {
                if(GameManager.gameManager.equip_head == "")
                {
                    equip_window.SetActive(false);
                }
                else
                {
                    equip_window.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.gameManager.name_image[GameManager.gameManager.equip_head];
                    equip_window.transform.GetChild(1).GetComponent<Text>().text = GameManager.gameManager.equip_head;
                    equip_window.transform.GetChild(2).GetComponent<Text>().text = GameManager.gameManager.name_info[GameManager.gameManager.equip_head];
                }
            }
            else if(GameManager.gameManager.hand_inventory.Contains(item_name))
            {
                if (GameManager.gameManager.equip_hand == "")
                {
                    equip_window.SetActive(false);
                }
                else
                {
                    equip_window.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.gameManager.name_image[GameManager.gameManager.equip_hand];
                    equip_window.transform.GetChild(1).GetComponent<Text>().text = GameManager.gameManager.equip_hand;
                    equip_window.transform.GetChild(2).GetComponent<Text>().text = GameManager.gameManager.name_info[GameManager.gameManager.equip_hand];
                }
            }
            else if (GameManager.gameManager.body_inventory.Contains(item_name))
            {
                if (GameManager.gameManager.equip_body == "")
                {
                    equip_window.SetActive(false);
                }
                else
                {
                    equip_window.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.gameManager.name_image[GameManager.gameManager.equip_body];
                    equip_window.transform.GetChild(1).GetComponent<Text>().text = GameManager.gameManager.equip_body;
                    equip_window.transform.GetChild(2).GetComponent<Text>().text = GameManager.gameManager.name_info[GameManager.gameManager.equip_body];
                }
            }
            else if (GameManager.gameManager.shoes_inventory.Contains(item_name))
            {
                if (GameManager.gameManager.equip_shoes == "")
                {
                    equip_window.SetActive(false);
                }
                else
                {
                    equip_window.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.gameManager.name_image[GameManager.gameManager.equip_shoes];
                    equip_window.transform.GetChild(1).GetComponent<Text>().text = GameManager.gameManager.equip_shoes;
                    equip_window.transform.GetChild(2).GetComponent<Text>().text = GameManager.gameManager.name_info[GameManager.gameManager.equip_shoes];
                }
            }
        }
        else
        {
            equip_window.SetActive(false);
        }
    }
}
