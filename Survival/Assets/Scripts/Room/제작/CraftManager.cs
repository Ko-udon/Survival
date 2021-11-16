using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{
    private int craft_num;
    private List<bool> craftAble;


    public int buttonNum = 100; //레시피, 재료 선택 시 어느 칸에 전달할 지에 대한 정보(100은 초기화 값)

    public GameObject canvas;

    public GameObject numWindow;
    public GameObject succesWindow;
    public GameObject backgroundButton;
    public List<string> select_list;
    public Sprite defaultImage;

    
    
    void Start()
    {
        craft_num = 1;
        craftAble = new List<bool> {true, true, true, true, true};

        select_list = new List<string>();
        select_list.Add("");
        select_list.Add("");
        select_list.Add("");
        select_list.Add("");
        select_list.Add("");
    }

    void Update()
    {
        if(select_list[0] != "")
        {
            transform.GetChild(1).GetComponent<Button>().interactable = false;
            transform.GetChild(2).GetComponent<Button>().interactable = false;
            transform.GetChild(3).GetComponent<Button>().interactable = false;
            transform.GetChild(4).GetComponent<Button>().interactable = false;
        }
        else
        {
            transform.GetChild(1).GetComponent<Button>().interactable = true;
            transform.GetChild(2).GetComponent<Button>().interactable = true;
            transform.GetChild(3).GetComponent<Button>().interactable = true;
            transform.GetChild(4).GetComponent<Button>().interactable = true;
        }

        for(int i = 0; i < 5; i++)
        {
            if(select_list[i] == "")
            {
                transform.GetChild(i).GetComponent<Image>().sprite = defaultImage;
                if(i != 0)
                {
                    transform.GetChild(i).GetChild(1).GetComponent<Text>().text = "";
                }
            }
            else
            {
                transform.GetChild(i).GetComponent<Image>().sprite = GameManager.gameManager.name_image[select_list[i]];
                if (i != 0)
                {
                    transform.GetChild(i).GetChild(1).GetComponent<Text>().text = craft_num + "/" + GameManager.gameManager.ingred_inventory[select_list[i]];
                }
            }

            if ((!GameManager.gameManager.ingred_inventory.ContainsKey(select_list[i]) || craft_num > GameManager.gameManager.ingred_inventory[select_list[i]]) && select_list[i] != "")
            {
                if (i != 0)
                {
                    transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
                    craftAble[i] = false;
                }
            }
            else
            {
                if (i != 0)
                {
                    transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
                    craftAble[i] = true;
                }
            }
        }

        GameObject.Find("NumButton").transform.GetChild(0).GetComponent<Text>().text = craft_num.ToString();
        if (numWindow.activeSelf)
        {
            GameObject.Find("NumWindow").transform.GetChild(3).GetComponent<Text>().text = craft_num.ToString();
        }
    }

    public void OnOpenClicked(GameObject window)
    {
        backgroundButton.SetActive(true);
        window.SetActive(true);
    }
    public void OnCloseClicked(GameObject window)
    {
        backgroundButton.SetActive(false);
        window.SetActive(false);
    }

    public void OnOpen(int num)
    {
        buttonNum = num;
    }

    public void OnPlusClicked()
    {
        craft_num++;
    }
    public void OnMinusClicked()
    {
        if(craft_num > 1)
        {
            craft_num--;
        }
    }

    public void OnCraftClicked(GameObject window)
    {
        if(!craftAble.Contains(false) && (select_list[1] != "" || select_list[2] != "" || select_list[3] != "" || select_list[4] != ""))
        {
            for(int i = 1; i < 5; i++)
            {
                GameManager.gameManager.deleteInventory(GameManager.gameManager.ingred_inventory, select_list[i], craft_num);
                
            }

            select_list.Sort(1, 4, Comparer<string>.Default);

            string isSucces;
            if (select_list[1] == "" && select_list[2] == "" && select_list[3] == "당근" && select_list[4] == "사과")
            {
                isSucces = GameManager.gameManager.addInventory(GameManager.gameManager.expend_inventory, "HP 회복 물약", craft_num);
            }
            else if(select_list[1] == "" && select_list[2] == "나무" && select_list[3] == "다이아몬드" && select_list[4] == "버섯")
            {
                isSucces = GameManager.gameManager.addInventory(GameManager.gameManager.expend_inventory, "MT 회복 물약", craft_num);
            }
            else
            {
                isSucces = "notCraft";
            }
           

            craft_num = 1;
            for(int i = 0; i < 5; i++)
            {
                select_list[i] = "";
            }

            backgroundButton.SetActive(true);
            window.SetActive(true);
            if (isSucces == "succes")
            {
                window.transform.GetChild(0).GetComponent<Text>().text = "제작 성공!";
            }
            else if(isSucces == "fail")
            {
                window.transform.GetChild(0).GetComponent<Text>().text = "인벤토리 공간이 부족하여 제작에 실패했습니다.";
            }
            else if(isSucces == "notCraft")
            {
                window.transform.GetChild(0).GetComponent<Text>().text = "제작 실패!\n사용한 재료들은 사라졌습니다.";
            }
        }
    }

    public void OnExitClicked()
    {
        select_list[0] = "";
        select_list[1] = "";
        select_list[2] = "";
        select_list[3] = "";
        select_list[4] = "";
        craft_num = 1;
        numWindow.SetActive(false);
        succesWindow.SetActive(false);
        canvas.SetActive(false);
    }
}
