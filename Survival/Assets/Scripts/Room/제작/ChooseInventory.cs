using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseInventory : MonoBehaviour
{
    private CraftManager craftManager;

    public GameObject useWindow;
    public GameObject backgroundButton;
    public string selectItem;

    void Start()
    {
        craftManager = GameObject.Find("CraftWindow").GetComponent<CraftManager>();
    }

    void Update()
    {
        for (int i = 0; i < 16; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        int ing = 0;

        if(craftManager.buttonNum == 0)
        {
            foreach (string name in GameManager.gameManager.recipe_inventory)
            {

                transform.GetChild(ing).gameObject.SetActive(true);
                transform.GetChild(ing).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name];
                transform.GetChild(ing).GetChild(0).GetComponent<Text>().text = "";
                transform.GetChild(ing).name = name;

                ing++;
            }
        }
        else
        {
            foreach (KeyValuePair<string, int> name in GameManager.gameManager.ingred_inventory)
            {

                transform.GetChild(ing).gameObject.SetActive(true);
                transform.GetChild(ing).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name.Key];
                transform.GetChild(ing).GetChild(0).GetComponent<Text>().text = name.Value.ToString();
                transform.GetChild(ing).name = name.Key;

                ing++;
            }
        }
    }

    public void OnItemClicked(GameObject item)
    {
        backgroundButton.SetActive(true);
        useWindow.SetActive(true);
        useWindow.transform.GetChild(0).GetComponent<Text>().text = GameManager.gameManager.name_info[item.name];
        selectItem = item.name;
    }

    public void OnUseClicked()
    {
        OnExitClicked();

        if(craftManager.buttonNum == 0)
        {
            craftManager.select_list[craftManager.buttonNum] = selectItem;
            if(selectItem == "HP 회복 물약 레시피")
            {
                craftManager.select_list[1] = "사과";
                craftManager.select_list[2] = "당근";
                craftManager.select_list[3] = "";
                craftManager.select_list[4] = "";
            }
            else if(selectItem == "MT 회복 물약 레시피")
            {
                craftManager.select_list[1] = "버섯";
                craftManager.select_list[2] = "다이아몬드";
                craftManager.select_list[3] = "나무";
                craftManager.select_list[4] = "";
            }
        }
        else
        {
            if (!craftManager.select_list.Contains(selectItem))
            {
                craftManager.select_list[craftManager.buttonNum] = selectItem;
            }
        }
        selectItem = "";
        craftManager.buttonNum = 100;
    }

    public void OnCloseClicked()
    {
        backgroundButton.SetActive(false);
        useWindow.SetActive(false);
    }

    public void OnExitClicked()
    {
        OnCloseClicked();
        this.gameObject.SetActive(false);
    }
}
