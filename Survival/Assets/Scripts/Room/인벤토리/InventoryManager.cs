using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public string inventory_state;
    public GameObject info_window;
    public GameObject equip_window;
    public GameObject info_background;
    public GameObject canvas;

    void Start()
    {
        inventory_state = "Expend";

        info_window.SetActive(false);
        equip_window.SetActive(false);
    }


    void Update()
    {
        switch(inventory_state)
        {
            case "Expend":
                for (int i = 0; i < 16; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                int ex = 0;
                foreach (KeyValuePair<string, int> name in GameManager.gameManager.expend_inventory)
                {
                    transform.GetChild(ex).gameObject.SetActive(true);
                    transform.GetChild(ex).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name.Key];
                    transform.GetChild(ex).GetComponent<ItemInfo>().item_name = name.Key;
                    transform.GetChild(ex).GetComponent<ItemInfo>().state = inventory_state;
                    transform.GetChild(ex).GetChild(0).GetComponent<Text>().text = name.Value.ToString();

                    ex++;
                }
                break;

            case "Equip":
                for (int i = 0; i < 16; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                int eq = 0;
                foreach (string name in GameManager.gameManager.head_inventory)
                {
                    transform.GetChild(eq).gameObject.SetActive(true);
                    transform.GetChild(eq).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name];
                    transform.GetChild(eq).GetComponent<ItemInfo>().item_name = name;
                    transform.GetChild(eq).GetComponent<ItemInfo>().state = inventory_state;

                    if (eq == GameManager.gameManager.equip_head_index)
                    {
                        transform.GetChild(eq).GetChild(0).GetComponent<Text>().text = "E";
                    }
                    else
                    {
                        transform.GetChild(eq).GetChild(0).GetComponent<Text>().text = "머리";
                    }
                    transform.GetChild(eq).GetComponent<ItemInfo>().index = eq;

                    eq++;
                }
                foreach (string name in GameManager.gameManager.hand_inventory)
                {
                    transform.GetChild(eq).gameObject.SetActive(true);
                    transform.GetChild(eq).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name];
                    transform.GetChild(eq).GetComponent<ItemInfo>().item_name = name;
                    transform.GetChild(eq).GetComponent<ItemInfo>().state = inventory_state;

                    if (eq == GameManager.gameManager.equip_hand_index)
                    {
                        transform.GetChild(eq).GetChild(0).GetComponent<Text>().text = "E";
                    }
                    else
                    {
                        transform.GetChild(eq).GetChild(0).GetComponent<Text>().text = "손";
                    }
                    transform.GetChild(eq).GetComponent<ItemInfo>().index = eq;

                    eq++;
                }
                foreach (string name in GameManager.gameManager.body_inventory)
                {
                    transform.GetChild(eq).gameObject.SetActive(true);
                    transform.GetChild(eq).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name];
                    transform.GetChild(eq).GetComponent<ItemInfo>().item_name = name;
                    transform.GetChild(eq).GetComponent<ItemInfo>().state = inventory_state;

                    if (eq == GameManager.gameManager.equip_body_index)
                    {
                        transform.GetChild(eq).GetChild(0).GetComponent<Text>().text = "E";
                    }
                    else
                    {
                        transform.GetChild(eq).GetChild(0).GetComponent<Text>().text = "몸";
                    }
                    transform.GetChild(eq).GetComponent<ItemInfo>().index = eq;

                    eq++;
                }
                foreach (string name in GameManager.gameManager.shoes_inventory)
                {
                    transform.GetChild(eq).gameObject.SetActive(true);
                    transform.GetChild(eq).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name];
                    transform.GetChild(eq).GetComponent<ItemInfo>().item_name = name;
                    transform.GetChild(eq).GetComponent<ItemInfo>().state = inventory_state;

                    if (eq == GameManager.gameManager.equip_shoes_index)
                    {
                        transform.GetChild(eq).GetChild(0).GetComponent<Text>().text = "E";
                    }
                    else
                    {
                        transform.GetChild(eq).GetChild(0).GetComponent<Text>().text = "신발";
                    }
                    transform.GetChild(eq).GetComponent<ItemInfo>().index = eq;

                    eq++;
                }
                break;

            case "Ingred":
                for (int i = 0; i < 16; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                int ing = 0;
                foreach (string name in GameManager.gameManager.recipe_inventory)
                {

                    transform.GetChild(ing).gameObject.SetActive(true);
                    transform.GetChild(ing).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name];
                    transform.GetChild(ing).GetComponent<ItemInfo>().item_name = name;
                    transform.GetChild(ing).GetComponent<ItemInfo>().state = inventory_state;
                    transform.GetChild(ing).GetChild(0).GetComponent<Text>().text = "";

                    ing++;
                }
                foreach (KeyValuePair<string, int> name in GameManager.gameManager.ingred_inventory)
                {
                    
                    transform.GetChild(ing).gameObject.SetActive(true);
                    transform.GetChild(ing).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name.Key];
                    transform.GetChild(ing).GetComponent<ItemInfo>().item_name = name.Key;
                    transform.GetChild(ing).GetComponent<ItemInfo>().state = inventory_state;
                    transform.GetChild(ing).GetChild(0).GetComponent<Text>().text = name.Value.ToString();

                    ing++;
                }
                break;
        }
    }

    public void OnExpendClick()
    {
        OnExitClicked();
        inventory_state = "Expend";
    }

    public void OnEquipClick()
    {
        OnExitClicked();
        inventory_state = "Equip";
    }

    public void OningredClick()
    {
        OnExitClicked();
        inventory_state = "Ingred";
    }

    public void OnExitClicked()
    {
        info_background.SetActive(false);
        info_window.SetActive(false);
        equip_window.SetActive(false);
    }

    public void OnCloseClicked()
    {
        OnExitClicked();
        inventory_state = "Expend";
        canvas.SetActive(false);
    }
}
