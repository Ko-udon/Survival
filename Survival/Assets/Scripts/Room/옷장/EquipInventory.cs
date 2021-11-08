using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipInventory : MonoBehaviour
{
    public GameObject info_window;
    public GameObject equip_window;
    public string parts;
    public string select_item;

    void Start()
    {
        
    }

    
    void Update()
    {
        switch(parts)
        {
            case "head":
                for (int i = 0; i < 16; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                int head = 0;
                int head_eq = GameManager.gameManager.head_inventory.FindIndex(x => x == GameManager.gameManager.equip_head);
                foreach (string name in GameManager.gameManager.head_inventory)
                {
                    transform.GetChild(head).gameObject.SetActive(true);
                    transform.GetChild(head).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name];
                    transform.GetChild(head).GetComponent<EquipInformation>().item_name = name;

                    if (head == head_eq)
                    {
                        transform.GetChild(head).GetChild(0).GetComponent<Text>().text = "E";
                    }
                    else
                    {
                        transform.GetChild(head).GetChild(0).GetComponent<Text>().text = "";
                    }

                    head++;
                }
                break;

            case "hand":
                for (int i = 0; i < 16; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                int hand = 0;
                int hand_eq = GameManager.gameManager.hand_inventory.FindIndex(x => x == GameManager.gameManager.equip_hand);
                foreach (string name in GameManager.gameManager.hand_inventory)
                {
                    transform.GetChild(hand).gameObject.SetActive(true);
                    transform.GetChild(hand).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name];
                    transform.GetChild(hand).GetComponent<EquipInformation>().item_name = name;

                    if (hand == hand_eq)
                    {
                        transform.GetChild(hand).GetChild(0).GetComponent<Text>().text = "E";
                    }
                    else
                    {
                        transform.GetChild(hand).GetChild(0).GetComponent<Text>().text = "";
                    }

                    hand++;
                }
                break;

            case "body":
                for (int i = 0; i < 16; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                int body = 0;
                int body_eq = GameManager.gameManager.body_inventory.FindIndex(x => x == GameManager.gameManager.equip_body);
                foreach (string name in GameManager.gameManager.body_inventory)
                {
                    transform.GetChild(body).gameObject.SetActive(true);
                    transform.GetChild(body).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name];
                    transform.GetChild(body).GetComponent<EquipInformation>().item_name = name;

                    if (body == body_eq)
                    {
                        transform.GetChild(body).GetChild(0).GetComponent<Text>().text = "E";
                    }
                    else
                    {
                        transform.GetChild(body).GetChild(0).GetComponent<Text>().text = "";
                    }

                    body++;
                }
                break;

            case "skill":
                for (int i = 0; i < 16; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                break;
        }
    }

    public void OnUseClicked()
    {
        switch (parts)
        {
            case "head":
                GameManager.gameManager.equipInventory(GameManager.gameManager.head_inventory, select_item);
                break;

            case "hand":
                GameManager.gameManager.equipInventory(GameManager.gameManager.hand_inventory, select_item);
                break;

            case "body":
                GameManager.gameManager.equipInventory(GameManager.gameManager.body_inventory, select_item);
                break;
        }
        OnCloseClicked();
    }

    public void OnDeleteClicked()
    {
        switch (parts)
        {
            case "head":
                GameManager.gameManager.deleteInventory(GameManager.gameManager.head_inventory, select_item);
                break;

            case "hand":
                GameManager.gameManager.deleteInventory(GameManager.gameManager.hand_inventory, select_item);
                break;

            case "body":
                GameManager.gameManager.deleteInventory(GameManager.gameManager.body_inventory, select_item);
                break;
        }
        OnCloseClicked();
    }

    public void OnCloseClicked()
    {
        info_window.SetActive(false);
        equip_window.SetActive(false);
    }
}
