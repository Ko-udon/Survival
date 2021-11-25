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
    public Dictionary<string, string> name_info;

    public int maxLayer;

    void Awake() 
    {
        
        if (gameManager == null)
            gameManager = this;

        else if (gameManager != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        hp = 80;
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
        recipe_inventory = new List<string>();

        name_image = new Dictionary<string, Sprite>();
        name_info = new Dictionary<string, string>();

        player.Hp=hp;
        player.Mt=mt;
        player.Air=air;

        time = 300;
        day = 1;

        name_image.Add("HP 회복 물약", item_images[0]);
        name_image.Add("MT 회복 물약", item_images[1]);
        name_image.Add("광전사의 헬멧", item_images[2]);
        name_image.Add("광부 모자", item_images[3]);
        name_image.Add("민트 장갑", item_images[4]);
        name_image.Add("주황 장갑", item_images[5]);
        name_image.Add("초록 장갑", item_images[6]);
        name_image.Add("빨간 옷", item_images[7]);
        name_image.Add("파란 옷", item_images[8]);
        name_image.Add("초록 옷", item_images[9]);
        name_image.Add("갈색 신발", item_images[10]);
        name_image.Add("보라 신발", item_images[11]);
        name_image.Add("HP 회복 물약 레시피", item_images[12]);
        name_image.Add("MT 회복 물약 레시피", item_images[13]);
        name_image.Add("사과", item_images[14]);
        name_image.Add("버섯", item_images[15]);
        name_image.Add("다이아몬드", item_images[16]);
        name_image.Add("철광석", item_images[17]);
        name_image.Add("나무", item_images[18]);
        name_image.Add("당근", item_images[19]);

        name_info.Add("HP 회복 물약", "HP를 10 회복한다.");
        name_info.Add("MT 회복 물약", "MT를 10 회복한다.");
        name_info.Add("광전사의 헬멧", "고대 전사들이 쓰던 헬멧이다.\n공격력: \n방어력: ");
        name_info.Add("광부 모자", "광질할 때 쓰기 좋은 모자.\n공격력: \n방어력: ");
        name_info.Add("민트 장갑", "어떤 단체가 좋아하는 색의 장갑.\n공격력: \n방어력: ");
        name_info.Add("주황 장갑", "주황색이 아닌 것 같은 주황 장갑.\n공격력: \n방어력: ");
        name_info.Add("초록 장갑", "초록 옷과 같이 입으면 식물 인간이 될 수 있다.\n공격력: \n방어력: ");
        name_info.Add("빨간 옷", "피가 묻어도 티가 나지 않아 좋은 옷.\n공격력: \n방어력: ");
        name_info.Add("파란 옷", "파란색 옷.\n공격력: \n방어력: ");
        name_info.Add("초록 옷", "그래서 초록색 옷이 젤다죠?\n공격력: \n방어력: ");
        name_info.Add("갈색 신발", "원래 흰색 신발이었지만 진흙이 묻어 갈색이 되었다.\n공격력: \n방어력: ");
        name_info.Add("보라 신발", "보라색 맛 났어!\n공격력: \n방어력: ");
        name_info.Add("HP 회복 물약 레시피", "HP 회복 물약을 만들 수 있다. 재료는 사과와 당근.");
        name_info.Add("MT 회복 물약 레시피", "MT 회복 물약을 만들 수 있다. 재료는 버섯과 다이아몬드, 나무");
        name_info.Add("사과", "맛있다.");
        name_info.Add("버섯", "이것도 맛있다.");
        name_info.Add("다이아몬드", "비싸다.");
        name_info.Add("철광석", "단단하다.");
        name_info.Add("나무", "만능 재료.");
        name_info.Add("당근", "먹으면 눈이 좋아진다.");

        addInventory(expend_inventory, "HP 회복 물약", 3);
        addInventory(expend_inventory, "MT 회복 물약", 7);

        addInventory(head_inventory, "광전사의 헬멧");
        addInventory(head_inventory, "광부 모자");

        addInventory(hand_inventory, "민트 장갑");
        addInventory(hand_inventory, "주황 장갑");
        addInventory(hand_inventory, "초록 장갑");

        addInventory(body_inventory, "빨간 옷");
        addInventory(body_inventory, "파란 옷");
        addInventory(body_inventory, "초록 옷");

        addInventory(shoes_inventory, "갈색 신발");
        addInventory(shoes_inventory, "보라 신발");

        addInventory(recipe_inventory, "HP 회복 물약 레시피");
        addInventory(recipe_inventory, "MT 회복 물약 레시피");

        addInventory(ingred_inventory, "사과", 10);
        addInventory(ingred_inventory, "버섯", 7);
        addInventory(ingred_inventory, "다이아몬드", 3);
        addInventory(ingred_inventory, "철광석", 6);
        addInventory(ingred_inventory, "나무", 4);
        addInventory(ingred_inventory, "당근", 5);



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

        AddReward();
        
        
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
            switch(name)
            {
                case "HP 회복 물약":
                    GameManager.gameManager.hp += 10;
                    break;

                case "MT 회복 물약":
                    GameManager.gameManager.mt += 10;
                    break;
            }
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
                if(equip_head_index == index)
                {
                    equip_head_index = -1;
                }
            }
            else if(equip_hand == name)
            {
                equip_hand = "";
                if (equip_hand_index == index)
                {
                    equip_hand_index = -1;
                }
            }
            else if(equip_body == name)
            {
                equip_body = "";
                if (equip_body_index == index)
                {
                    equip_body_index = -1;
                }
            }
            else if (equip_shoes == name)
            {
                equip_shoes = "";
                if (equip_shoes_index == index)
                {
                    equip_shoes_index = -1;
                }
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

    public string deleteInventory(List<string> inventory, string name)
    {
        if(inventory.Contains(name))
        {
            inventory.Remove(name);
            return "succes";
        }
        else
        {
            return "fail";
        }
    }

    void AddReward()
    {
        if(player.isReward==true)
        {
            addInventory(ingred_inventory,"사과",2);
            player.isReward=false;
        }
    }


}
