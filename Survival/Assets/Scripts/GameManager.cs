using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public static PlayerCharacter player;

    public GameObject Player;

    const int MAX_SIZE = 16;
    public Dictionary<string, int> expend_inventory;
    public List<string> head_inventory;
    public List<string> hand_inventory;
    public List<string> body_inventory;
    public List<string> shoes_inventory;
    public Dictionary<string, int> ingred_inventory;
    public List<string> recipe_inventory;

    public string equip_head;
    public int equip_head_index;
    public string equip_hand;
    public int equip_hand_index;
    public string equip_body;
    public int equip_body_index;
    public string equip_shoes;
    public int equip_shoes_index;
    public string equip_skill;

    public float hp;
    public float mt;
    public float air;
    public int time;
    public int day;

    public List<Sprite> item_images;
    public Dictionary<string, Sprite> name_image;

    public int maxLayer;

    void Awake() 
    {
        
        if (gameManager == null)
            gameManager = this;

        else if (gameManager != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        hp = 50;
        mt = 50;
        air=100;
        

    }

    void Start()
    {
        //player 오브젝트 수집
        Player.SetActive(true);

        player=GameObject.FindWithTag("Player").GetComponent<PlayerCharacter>();

        expend_inventory = new Dictionary<string, int>();
        head_inventory = new List<string>();
        hand_inventory = new List<string>();
        body_inventory = new List<string>();
        shoes_inventory = new List<string>();
        ingred_inventory = new Dictionary<string, int>();
        name_image = new Dictionary<string, Sprite>();
        recipe_inventory = new List<string>();

        player.Hp=hp;
        player.Mt=mt;
        player.Air=air;

        time = 300;
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
        addInventory(head_inventory, "DDD");
        addInventory(hand_inventory, "EEE");
        addInventory(hand_inventory, "FFF");
        addInventory(body_inventory, "GGG");
        addInventory(shoes_inventory, "HHH");
        addInventory(shoes_inventory, "III");
        addInventory(shoes_inventory, "JJJ");
        addInventory(shoes_inventory, "KKK");

        addInventory(ingred_inventory, "HHH", 6);
        addInventory(ingred_inventory, "III", 4);
        addInventory(ingred_inventory, "JJJ", 2);

        addInventory(recipe_inventory, "KKK");

        equip_head = "";
        equip_head_index = -1;
        equip_hand = "";
        equip_hand_index = -1;
        equip_body = "";
        equip_body_index = -1;
        equip_shoes = "";
        equip_shoes_index = -1;
        equip_skill = "";

        maxLayer = 0;
    }


    void Update()
    {
        if(time <= 0)
        {
            day++;
            time += 1440;
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
        if (inventory.ContainsKey(name))
        {
            inventory[name] += num;
            return "succes";
        }
        else
        {
            if (inventory.Count < MAX_SIZE)
            {
                inventory.Add(name, num);
                return "succes";
            }
            else
            {
                return "fail";
            }
        }

        
    }
    public string addInventory(List<string> inventory, string name)
    {
        if(inventory.Equals(head_inventory) || inventory.Equals(hand_inventory) || inventory.Equals(body_inventory) || inventory.Equals(shoes_inventory))
        {
            if (head_inventory.Count + hand_inventory.Count + body_inventory.Count + shoes_inventory.Count < MAX_SIZE)
            {
                inventory.Add(name);
                if(inventory.Equals(head_inventory))
                {
                    if(equip_hand != "")
                    {
                        equip_hand_index--;
                    }
                    if(equip_body != "")
                    {
                        equip_body_index--;
                    }
                    if (equip_shoes != "")
                    {
                        equip_shoes_index--;
                    }
                }
                else if(inventory.Equals(hand_inventory))
                {
                    if (equip_body != "")
                    {
                        equip_body_index--;
                    }
                    if (equip_shoes != "")
                    {
                        equip_shoes_index--;
                    }
                }
                else if(inventory.Equals(body_inventory))
                {
                    if (equip_shoes != "")
                    {
                        equip_shoes_index--;
                    }
                }
                return "succes";
            }
            else
            {
                return "fail";
            }
        }
        else
        {
            if(recipe_inventory.Count < MAX_SIZE && !recipe_inventory.Contains(name))
            {
                inventory.Add(name);
                return "succes";
            }
            else
            {
                return "fail";
            }
        }
    }

    public string useInventory(Dictionary<string, int> inventory, string name)
    {
        if(inventory.ContainsKey(name))
        {
            //�Է¹��� �̸��� ���� ��� ȿ�� ����
            Debug.Log(name + " use");
            return deleteInventory(inventory, name, 1);
        }
        else
        {
            return "fail";
        }
    }

    public string equipInventory(List<string> inventory, string name, bool isEquip, int index)
    {
        if(inventory.Contains(name))
        {
            //������ �����ϱ�
            if(inventory.Equals(head_inventory))
            {
                if(isEquip)
                {
                    equip_head = "";
                    equip_head_index = -1;
                }
                else
                {
                    equip_head = name;
                    equip_head_index = index;
                }
            }
            else if(inventory.Equals(hand_inventory))
            {
                if(isEquip)
                {
                    equip_hand = "";
                    equip_hand_index = -1;
                }
                else
                {
                    equip_hand = name;
                    equip_hand_index = index;
                }
            }
            else if(inventory.Equals(body_inventory))
            {
                if (isEquip)
                {
                    equip_body = "";
                    equip_body_index = -1;
                }
                else
                {
                    equip_body = name;
                    equip_body_index = index;
                }
            }
            else if(inventory.Equals(shoes_inventory))
            {
                if (isEquip)
                {
                    equip_shoes = "";
                    equip_shoes_index = -1;
                }
                else
                {
                    equip_shoes = name;
                    equip_shoes_index = index;
                }
            }
            return "succes";
        }
        else
        {
            return "fail";
        }
    }

    public string deleteInventory(Dictionary<string, int> inventory, string name, int num)
    {
        if (inventory.ContainsKey(name))
        {
            if (inventory[name] < num)
            {
                return "fail";
            }
            else if(inventory[name] == num)
            {
                inventory.Remove(name);
                return "succes";
            }
            else
            {
                inventory[name] -= num;
                return "succes";
            }
        }
        else
        {
            return "fail";
        }
    }
    public string deleteInventory(List<string> inventory, string name, int index)
    {
        if(inventory.Contains(name))
        {
            if(equip_head == name)
            {
                equip_head = "";
                equip_head_index = -1;
            }
            else if(equip_hand == name)
            {
                equip_hand = "";
                equip_hand_index = -1;
            }
            else if(equip_body == name)
            {
                equip_body = "";
                equip_body_index = -1;
            }
            else if (equip_shoes == name)
            {
                equip_shoes = "";
                equip_shoes_index = -1;
            }
            inventory.Remove(name);

            if(inventory.Equals(head_inventory))
            {
                if(equip_head_index > index)
                {
                    equip_head_index -= 1;
                }
                equip_hand_index -= 1;
                equip_body_index -= 1;
                equip_shoes_index -= 1;
            }
            else if(inventory.Equals(hand_inventory))
            {
                if (equip_hand_index > index)
                {
                    equip_hand_index -= 1;
                }
                equip_body_index -= 1;
                equip_shoes_index -= 1;
            }
            else if (inventory.Equals(body_inventory))
            {
                if (equip_body_index > index)
                {
                    equip_body_index -= 1;
                }
                equip_shoes_index -= 1;
            }
            else if (inventory.Equals(shoes_inventory))
            {
                if (equip_shoes_index > index)
                {
                    equip_shoes_index -= 1;
                }
            }
            return "succes";
        }
        else
        {
            return "fail";
        }
    }
}
