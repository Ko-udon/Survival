using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationWindow : MonoBehaviour
{
    private InventoryManager invenManager;
    
    void Start()
    {
        invenManager = GameObject.Find("InventoryImage").GetComponent<InventoryManager>();
    }

    
    void Update()
    {
        
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
                    GameManager.gameManager.equipInventory(GameManager.gameManager.head_inventory, this.transform.GetChild(1).GetComponent<Text>().text);
                }
                else if (GameManager.gameManager.hand_inventory.Contains(this.transform.GetChild(1).GetComponent<Text>().text))
                {
                    GameManager.gameManager.equipInventory(GameManager.gameManager.hand_inventory, this.transform.GetChild(1).GetComponent<Text>().text);
                }
                else if (GameManager.gameManager.body_inventory.Contains(this.transform.GetChild(1).GetComponent<Text>().text))
                {
                    GameManager.gameManager.equipInventory(GameManager.gameManager.body_inventory, this.transform.GetChild(1).GetComponent<Text>().text);
                }
                break;

            case "Ingred":
                GameManager.gameManager.useInventory(GameManager.gameManager.ingred_inventory, this.transform.GetChild(1).GetComponent<Text>().text);
                break;
        }

        this.gameObject.SetActive(false);
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
                    GameManager.gameManager.deleteInventory(GameManager.gameManager.head_inventory, this.transform.GetChild(1).GetComponent<Text>().text);
                }
                else if(GameManager.gameManager.hand_inventory.Contains(this.transform.GetChild(1).GetComponent<Text>().text))
                {
                    GameManager.gameManager.deleteInventory(GameManager.gameManager.hand_inventory, this.transform.GetChild(1).GetComponent<Text>().text);
                }
                else if (GameManager.gameManager.body_inventory.Contains(this.transform.GetChild(1).GetComponent<Text>().text))
                {
                    GameManager.gameManager.deleteInventory(GameManager.gameManager.body_inventory, this.transform.GetChild(1).GetComponent<Text>().text);
                }
                break;

            case "Ingred":
                GameManager.gameManager.deleteInventory(GameManager.gameManager.ingred_inventory, this.transform.GetChild(1).GetComponent<Text>().text, 1);
                break;
        }

        this.gameObject.SetActive(false);
    }
}
