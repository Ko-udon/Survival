using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationWindow : MonoBehaviour
{
    private InventoryManager invenManager;

    public GameObject useButton;
    public bool isEquip;
    public int index;

    void Start()
    {
        invenManager = GameObject.Find("InventoryImage").GetComponent<InventoryManager>();
        isEquip = false;
        index = -1;
    }

    
    void Update()
    {
        switch (invenManager.inventory_state)
        {
            case "Expend":
                useButton.SetActive(true);
                useButton.transform.GetChild(0).GetComponent<Text>().text = "사용하기";
                break;

            case "Equip":
                useButton.SetActive(true);
                string item = transform.GetChild(1).GetComponent<Text>().text;
                if (isEquip)
                {
                    useButton.transform.GetChild(0).GetComponent<Text>().text = "해제하기";
                }
                else
                {
                    useButton.transform.GetChild(0).GetComponent<Text>().text = "장착하기";
                }
                break;

            case "Ingred":
                useButton.SetActive(false);
                break;
        }       
    }

    public void OnUseClicked()
    {
        switch (invenManager.inventory_state)
        {
            case "Expend":
                GameManager.gameManager.useInventory(GameManager.gameManager.expend_inventory, this.transform.GetChild(1).GetComponent<Text>().text);
                break;

            case "Equip":
                if (GameManager.gameManager.head_inventory.Contains(this.transform.GetChild(1).GetComponent<Text>().text))
                {
                    GameManager.gameManager.equipInventory(GameManager.gameManager.head_inventory, this.transform.GetChild(1).GetComponent<Text>().text, isEquip, index);
                }
                else if (GameManager.gameManager.hand_inventory.Contains(this.transform.GetChild(1).GetComponent<Text>().text))
                {
                    GameManager.gameManager.equipInventory(GameManager.gameManager.hand_inventory, this.transform.GetChild(1).GetComponent<Text>().text, isEquip, index);
                }
                else if (GameManager.gameManager.body_inventory.Contains(this.transform.GetChild(1).GetComponent<Text>().text))
                {
                    GameManager.gameManager.equipInventory(GameManager.gameManager.body_inventory, this.transform.GetChild(1).GetComponent<Text>().text, isEquip, index);
                }
                else if (GameManager.gameManager.shoes_inventory.Contains(this.transform.GetChild(1).GetComponent<Text>().text))
                {
                    GameManager.gameManager.equipInventory(GameManager.gameManager.shoes_inventory, this.transform.GetChild(1).GetComponent<Text>().text, isEquip, index);
                }
                break;

            case "Ingred":
                GameManager.gameManager.useInventory(GameManager.gameManager.ingred_inventory, this.transform.GetChild(1).GetComponent<Text>().text);
                break;
        }

        invenManager.OnExitClicked();
    }
    
    public void OnDeleteClicked()
    {
        switch (invenManager.inventory_state)
        {
            case "Expend":
                GameManager.gameManager.deleteInventory(GameManager.gameManager.expend_inventory, this.transform.GetChild(1).GetComponent<Text>().text, 1);
                break;

            case "Equip":
                if(GameManager.gameManager.head_inventory.Contains(this.transform.GetChild(1).GetComponent<Text>().text))
                {
                    GameManager.gameManager.deleteInventory(GameManager.gameManager.head_inventory, this.transform.GetChild(1).GetComponent<Text>().text, index);
                }
                else if(GameManager.gameManager.hand_inventory.Contains(this.transform.GetChild(1).GetComponent<Text>().text))
                {
                    GameManager.gameManager.deleteInventory(GameManager.gameManager.hand_inventory, this.transform.GetChild(1).GetComponent<Text>().text, index);
                }
                else if (GameManager.gameManager.body_inventory.Contains(this.transform.GetChild(1).GetComponent<Text>().text))
                {
                    GameManager.gameManager.deleteInventory(GameManager.gameManager.body_inventory, this.transform.GetChild(1).GetComponent<Text>().text, index);
                }
                else if (GameManager.gameManager.shoes_inventory.Contains(this.transform.GetChild(1).GetComponent<Text>().text))
                {
                    GameManager.gameManager.deleteInventory(GameManager.gameManager.shoes_inventory, this.transform.GetChild(1).GetComponent<Text>().text, index);
                }
                break;

            case "Ingred":
                if(GameManager.gameManager.recipe_inventory.Contains(this.transform.GetChild(1).GetComponent<Text>().text))
                {
                    GameManager.gameManager.deleteInventory(GameManager.gameManager.recipe_inventory, this.transform.GetChild(1).GetComponent<Text>().text);
                }
                else
                {
                    GameManager.gameManager.deleteInventory(GameManager.gameManager.ingred_inventory, this.transform.GetChild(1).GetComponent<Text>().text, 1);
                }
                
                break;
        }

        invenManager.OnExitClicked();
    }
}
