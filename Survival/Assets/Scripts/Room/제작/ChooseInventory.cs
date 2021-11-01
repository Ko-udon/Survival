using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseInventory : MonoBehaviour
{
    private CraftManager craftManager;

    public GameObject useWindow;
    public string selectItem;

    void Start()
    {
        craftManager = GameObject.Find("CraftWindow").GetComponent<CraftManager>();
    }

    void Update()
    {
        for (int i = 0; i < 20; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        int ing = 0;
        foreach (KeyValuePair<string, int> name in GameManager.gameManager.ingred_inventory)
        {

            transform.GetChild(ing).gameObject.SetActive(true);
            transform.GetChild(ing).GetComponent<Image>().sprite = GameManager.gameManager.name_image[name.Key];
            transform.GetChild(ing).GetChild(0).GetComponent<Text>().text = name.Value.ToString();
            transform.GetChild(ing).name = name.Key;

            ing++;
        }
    }

    public void OnItemClicked(GameObject item)
    {
        useWindow.SetActive(true);
        selectItem = item.name;
    }

    public void OnUseClicked()
    {
        useWindow.SetActive(false);
        this.gameObject.SetActive(false);

        if(craftManager.buttonNum == 0)
        {
            craftManager.select_list[craftManager.buttonNum] = selectItem;
            craftManager.select_list[1] = "HHH";
            craftManager.select_list[2] = "JJJ";
            craftManager.select_list[3] = "III";
            craftManager.select_list[4] = "LLL";
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
}
