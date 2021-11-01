using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public string inventory_state;
    public GameObject info_window;
    public GameObject canvas;

    void Start()
    {
        inventory_state = "Expend";

        info_window.SetActive(false);
    }


    void Update()
    {
        switch(inventory_state)
        {
            case "Expend":
                for (int i = 0; i < 20; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                int ex = 0;
                foreach (KeyValuePair<string, int> name in GameManager.gameManager.expend_inventory)
                {
                    transform.GetChild(ex).gameObject.SetActive(true);
                    transform.GetChild(ex).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name.Key];
                    transform.GetChild(ex).GetComponent<ItemInfo>().item_name = name.Key;
                    transform.GetChild(ex).GetChild(0).GetComponent<Text>().text = name.Value.ToString();

                    ex++;
                }
                break;

            case "Equip":
                for (int i = 0; i < 20; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                int eq = 0;
                int head_eq = GameManager.gameManager.head_inventory.FindIndex(x => x == GameManager.gameManager.equip_head);
                int hand_eq = GameManager.gameManager.hand_inventory.FindIndex(x => x == GameManager.gameManager.equip_hand);
                int body_eq = GameManager.gameManager.body_inventory.FindIndex(x => x == GameManager.gameManager.equip_body);
                foreach (string name in GameManager.gameManager.head_inventory)
                {
                    transform.GetChild(eq).gameObject.SetActive(true);
                    transform.GetChild(eq).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name];
                    transform.GetChild(eq).GetComponent<ItemInfo>().item_name = name;

                    if (eq == head_eq)
                    {
                        transform.GetChild(eq).GetChild(0).GetComponent<Text>().text = "E";
                    }
                    else
                    {
                        transform.GetChild(eq).GetChild(0).GetComponent<Text>().text = "¸Ó¸®";
                    }
                        
                    eq++;
                }
                foreach (string name in GameManager.gameManager.hand_inventory)
                {
                    transform.GetChild(eq).gameObject.SetActive(true);
                    transform.GetChild(eq).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name];
                    transform.GetChild(eq).GetComponent<ItemInfo>().item_name = name;

                    if(eq == hand_eq + GameManager.gameManager.head_inventory.Count)
                    {
                        transform.GetChild(eq).GetChild(0).GetComponent<Text>().text = "E";
                    }
                    else
                    {
                        transform.GetChild(eq).GetChild(0).GetComponent<Text>().text = "¼Õ";
                    }

                    eq++;
                }
                foreach (string name in GameManager.gameManager.body_inventory)
                {
                    transform.GetChild(eq).gameObject.SetActive(true);
                    transform.GetChild(eq).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name];
                    transform.GetChild(eq).GetComponent<ItemInfo>().item_name = name;

                    if (eq == body_eq + GameManager.gameManager.head_inventory.Count + GameManager.gameManager.hand_inventory.Count)
                    {
                        transform.GetChild(eq).GetChild(0).GetComponent<Text>().text = "E";
                    }
                    else
                    {
                        transform.GetChild(eq).GetChild(0).GetComponent<Text>().text = "¸ö";
                    }

                    eq++;
                }
                break;

            case "Ingred":
                for (int i = 0; i < 20; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                int ing = 0;
                foreach (KeyValuePair<string, int> name in GameManager.gameManager.ingred_inventory)
                {
                    
                    transform.GetChild(ing).gameObject.SetActive(true);
                    transform.GetChild(ing).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name.Key];
                    transform.GetChild(ing).GetComponent<ItemInfo>().item_name = name.Key;
                    transform.GetChild(ing).GetChild(0).GetComponent<Text>().text = name.Value.ToString();

                    ing++;
                }
                break;
        }
    }

    public void OnExpendClick()
    {
        info_window.SetActive(false);
        inventory_state = "Expend";
    }

    public void OnEquipClick()
    {
        info_window.SetActive(false);
        inventory_state = "Equip";
    }

    public void OningredClick()
    {
        info_window.SetActive(false);
        inventory_state = "Ingred";
    }

    public void OnExitClicked()
    {
        info_window.SetActive(false);
    }

    public void OnCloseClicked()
    {
        OnExitClicked();
        inventory_state = "Expend";
        canvas.SetActive(false);
    }
}
