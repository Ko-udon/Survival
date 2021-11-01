using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EquipInformation : MonoBehaviour
{
    public GameObject info_window;
    public GameObject equip_window;
    public string item_name;

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

        info_window.SetActive(true);
        equip_window.SetActive(true);

        info_window.transform.position = this.transform.position;
        equip_window.transform.position = new Vector2(this.transform.position.x - 456, this.transform.position.y);

        info_window.transform.GetChild(0).GetComponent<Image>().sprite = this.GetComponent<Image>().sprite;
        switch(GameObject.Find("EquipInventory").GetComponent<EquipInventory>().parts)
        {
            case "head":
                if(GameManager.gameManager.equip_head == "" || GameManager.gameManager.equip_head == item_name)
                {
                    equip_window.SetActive(false);
                }
                else
                {
                    equip_window.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.gameManager.name_image[GameManager.gameManager.equip_head];
                    equip_window.transform.GetChild(1).GetComponent<Text>().text = GameManager.gameManager.equip_head;
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
                }
                break;
        }
        

        info_window.transform.GetChild(1).GetComponent<Text>().text = this.item_name;
    }
}
