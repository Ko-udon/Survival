using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    const int MAX_SIZE = 20;
    public Dictionary<string, int> expend_inventory;
    public List<string> head_inventory;
    public List<string> hand_inventory;
    public List<string> body_inventory;
    public Dictionary<string, int> ingred_inventory;
    public List<string> recipe_inventory;

    public string equip_head;
    public string equip_hand;
    public string equip_body;
    public string equip_skill;

    public float hp;
    public float mt;
    public float time;
    public int day;

    public List<Sprite> item_images;
    public Dictionary<string, Sprite> name_image;

    void Awake() //씬이 바뀌어도 파괴되지 않음
    {
        if (gameManager == null)
            gameManager = this;

        else if (gameManager != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        expend_inventory = new Dictionary<string, int>();
        head_inventory = new List<string>();
        hand_inventory = new List<string>();
        body_inventory = new List<string>();
        ingred_inventory = new Dictionary<string, int>();
        name_image = new Dictionary<string, Sprite>();
        recipe_inventory = new List<string>();

        hp = 50;
        mt = 50;
        time = 6;
        day = 1;

        name_image.Add("AAA", item_images[0]);
        name_image.Add("BBB", item_images[1]);
        name_image.Add("CCC", item_images[2]);
        name_image.Add("DDD", item_images[3]);
        name_image.Add("EEE", item_images[4]);
        name_image.Add("FFF", item_images[5]);
        name_image.Add("GGG", item_images[6]);
        name_image.Add("HHH", item_images[7]);
        name_image.Add("III", item_images[8]);
        name_image.Add("JJJ", item_images[9]);
        name_image.Add("KKK", item_images[10]);
        name_image.Add("LLL", item_images[11]);

        addInventory(expend_inventory, "AAA", 3);
        addInventory(expend_inventory, "BBB", 7);

        addInventory(head_inventory, "CCC");
        addInventory(head_inventory, "DDD");
        addInventory(hand_inventory, "EEE");
        addInventory(hand_inventory, "FFF");
        addInventory(body_inventory, "GGG");

        addInventory(ingred_inventory, "HHH", 6);
        addInventory(ingred_inventory, "III", 4);
        addInventory(ingred_inventory, "JJJ", 2);

        addInventory(recipe_inventory, "KKK");

        equip_head = "";
        equip_hand = "";
        equip_body = "";
        equip_skill = "";
    }


    void Update()
    {
        if(time >= 24)
        {
            day++;
            time -= 24;
        }

        if(hp > 100)
        {
            hp = 100;
        }

        if(mt > 100)
        {
            mt = 100;
        }
    }

    public string addInventory(Dictionary<string, int> inventory, string name, int num)
    {
        if(inventory.Count < MAX_SIZE)
        {
            if (inventory.ContainsKey(name))
            {
                inventory[name] += num;
            }
            else
            {
                inventory.Add(name, num);
            }
            return "추가 완료";
        }
        else
        {
            return "추가 실패";
        }
    }
    public string addInventory(List<string> inventory, string name)
    {
        if(inventory.Equals(head_inventory) || inventory.Equals(hand_inventory) || inventory.Equals(body_inventory))
        {
            if (head_inventory.Count + hand_inventory.Count + body_inventory.Count < MAX_SIZE)
            {
                inventory.Add(name);
                return "추가 완료";
            }
            else
            {
                return "추가 실패";
            }
        }
        else
        {
            if(recipe_inventory.Count < MAX_SIZE && !recipe_inventory.Contains(name))
            {
                inventory.Add(name);
                return "추가 완료";
            }
            else
            {
                return "추가 실패";
            }
        }
    }

    public string useInventory(Dictionary<string, int> inventory, string name)
    {
        if(inventory.ContainsKey(name))
        {
            //입력받은 이름에 따라 사용 효과 실행
            Debug.Log(name + "사용함.");
            deleteInventory(inventory, name, 1);
            return "사용 완료";
        }
        else
        {
            return "사용 실패";
        }
    }

    public string equipInventory(List<string> inventory, string name)
    {
        if(inventory.Contains(name))
        {
            //아이템 장착하기
            if(inventory.Equals(head_inventory))
            {
                equip_head = name;
            }
            else if(inventory.Equals(hand_inventory))
            {
                equip_hand = name;
            }
            else if(inventory.Equals(body_inventory))
            {
                equip_body = name;
            }
            return "장착 완료";
        }
        else
        {
            return "장착 실패";
        }
    }

    public string deleteInventory(Dictionary<string, int> inventory, string name, int num)
    {
        if (inventory.ContainsKey(name))
        {
            if (inventory[name] < num)
            {
                return "제거 실패";
            }
            else if(inventory[name] == num)
            {
                inventory.Remove(name);
                return "제거 완료";
            }
            else
            {
                inventory[name] -= num;
                return "제거 완료";
            }
        }
        else
        {
            return "제거 실패";
        }
    }
    public string deleteInventory(List<string> inventory, string name)
    {
        if(inventory.Contains(name))
        {
            if(equip_head == name)
            {
                equip_head = "";
            }
            else if(equip_hand == name)
            {
                equip_hand = "";
            }
            else if(equip_body == name)
            {
                equip_body = "";
            }
            inventory.Remove(name);
            return "제거 완료";
        }
        else
        {
            return "제거 실패";
        }
    }
}
