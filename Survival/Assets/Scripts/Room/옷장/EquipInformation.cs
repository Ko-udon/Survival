using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EquipInformation : MonoBehaviour
{
    public GameObject info_window;
    public GameObject equip_window;
    public GameObject equipButton;
    public GameObject backgroundButton;
    public string item_name;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClicked()
    {
        GameObject.Find("EquipInventory").GetComponent<EquipInventory>().select_item = item_name;

        backgroundButton.SetActive(true);
        info_window.SetActive(true);
        equip_window.SetActive(true);

        info_window.transform.position = this.transform.position;
        equip_window.transform.position = new Vector2(this.transform.position.x - 471, this.transform.position.y);

        info_window.transform.GetChild(0).GetComponent<Image>().sprite = this.GetComponent<Image>().sprite;
        info_window.transform.GetChild(1).GetComponent<Text>().text = this.item_name;
        info_window.transform.GetChild(2).GetComponent<Text>().text = GameManager.gameManager.name_info[this.item_name];

        switch (GameObject.Find("EquipInventory").GetComponent<EquipInventory>().parts)
        {
            case "head":
                if (GameManager.gameManager.equip_head == "" || GameManager.gameManager.equip_head == item_name)
                {
                    equip_window.SetActive(false);
                }
                else
                {
                    equip_window.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.gameManager.name_image[GameManager.gameManager.equip_head];
                    equip_window.transform.GetChild(1).GetComponent<Text>().text = GameManager.gameManager.equip_head;
                    equip_window.transform.GetChild(2).GetComponent<Text>().text = GameManager.gameManager.name_info[GameManager.gameManager.equip_head];
                }

                if (transform.GetChild(0).GetComponent<Text>().text == "E")
                {
                    equipButton.transform.GetChild(0).GetComponent<Text>().text = "해제하기";
                    GameObject.Find("EquipInventory").GetComponent<EquipInventory>().isEquip = true;
                    GameObject.Find("EquipInventory").GetComponent<EquipInventory>().index = index;
                }
                else
                {
                    Debug.Log("asdasdasd");
                    equipButton.transform.GetChild(0).GetComponent<Text>().text = "장착하기";
                    GameObject.Find("EquipInventory").GetComponent<EquipInventory>().isEquip = false;
                    GameObject.Find("EquipInventory").GetComponent<EquipInventory>().index = index;
                }
                break;

            case "hand":
                if (GameManager.gameManager.equip_hand == "" || GameManager.gameManager.equip_hand == item_name)
                {
                    equip_window.SetActive(false);
                }
                else
                {
                    equip_window.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.gameManager.name_image[GameManager.gameManager.equip_hand];
                    equip_window.transform.GetChild(1).GetComponent<Text>().text = GameManager.gameManager.equip_hand;
                    equip_window.transform.GetChild(2).GetComponent<Text>().text = GameManager.gameManager.name_info[GameManager.gameManager.equip_hand];
                }

                if (transform.GetChild(0).GetComponent<Text>().text == "E")
                {
                    equipButton.transform.GetChild(0).GetComponent<Text>().text = "해제하기";
                    GameObject.Find("EquipInventory").GetComponent<EquipInventory>().isEquip = true;
                    GameObject.Find("EquipInventory").GetComponent<EquipInventory>().index = index;
                }
                else
                {
                    equipButton.transform.GetChild(0).GetComponent<Text>().text = "장착하기";
                    GameObject.Find("EquipInventory").GetComponent<EquipInventory>().isEquip = false;
                    GameObject.Find("EquipInventory").GetComponent<EquipInventory>().index = index;
                }
                break;

            case "body":
                if (GameManager.gameManager.equip_body == "" || GameManager.gameManager.equip_body == item_name)
                {
                    equip_window.SetActive(false);
                }
                else
                {
                    equip_window.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.gameManager.name_image[GameManager.gameManager.equip_body];
                    equip_window.transform.GetChild(1).GetComponent<Text>().text = GameManager.gameManager.equip_body;
                    equip_window.transform.GetChild(2).GetComponent<Text>().text = GameManager.gameManager.name_info[GameManager.gameManager.equip_body];
                }

                if (transform.GetChild(0).GetComponent<Text>().text == "E")
                {
                    equipButton.transform.GetChild(0).GetComponent<Text>().text = "해제하기";
                    GameObject.Find("EquipInventory").GetComponent<EquipInventory>().isEquip = true;
                    GameObject.Find("EquipInventory").GetComponent<EquipInventory>().index = index;
                }
                else
                {
                    equipButton.transform.GetChild(0).GetComponent<Text>().text = "장착하기";
                    GameObject.Find("EquipInventory").GetComponent<EquipInventory>().isEquip = false;
                    GameObject.Find("EquipInventory").GetComponent<EquipInventory>().index = index;
                }
                break;

            case "shoes":
                if (GameManager.gameManager.equip_shoes == "" || GameManager.gameManager.equip_shoes == item_name)
                {
                    equip_window.SetActive(false);
                }
                else
                {
                    equip_window.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.gameManager.name_image[GameManager.gameManager.equip_shoes];
                    equip_window.transform.GetChild(1).GetComponent<Text>().text = GameManager.gameManager.equip_shoes;
                    equip_window.transform.GetChild(2).GetComponent<Text>().text = GameManager.gameManager.name_info[GameManager.gameManager.equip_shoes];
                }

                if (transform.GetChild(0).GetComponent<Text>().text == "E")
                {
                    equipButton.transform.GetChild(0).GetComponent<Text>().text = "해제하기";
                    GameObject.Find("EquipInventory").GetComponent<EquipInventory>().isEquip = true;
                    GameObject.Find("EquipInventory").GetComponent<EquipInventory>().index = index;
                }
                else
                {
                    equipButton.transform.GetChild(0).GetComponent<Text>().text = "장착하기";
                    GameObject.Find("EquipInventory").GetComponent<EquipInventory>().isEquip = false;
                    GameObject.Find("EquipInventory").GetComponent<EquipInventory>().index = index;
                }
                break;
        }
    }
}
