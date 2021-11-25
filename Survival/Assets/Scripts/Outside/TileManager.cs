using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static GameManager gameManager;
    public static PlayerCharacter player;

    public Rigidbody2D rigid;

    public bool isFarming;
    public bool isFarmDone;
    private int farmingTimer;

    void Awake()
    {
        gameManager = GameManager.FindObjectOfType<GameManager>();
        rigid = GetComponent<Rigidbody2D>();

        isFarming = false;
        isFarmDone = false;
        farmingTimer = 0;

    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFarming)
        {
            if (farmingTimer > 300 * Time.deltaTime)
            {
                Invoke("getItem", 2);
                isFarming = false;
                isFarmDone = true;
                farmingTimer = 0;

            }
            else
            {
                farmingTimer++;
                Debug.Log(farmingTimer);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isFarmDone) isFarming = true;
            player.isFarming = true;
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isFarming = false;
            player.isFarming = false;
            farmingTimer = 0;
        }
    }

    void getItem()
    {
        name = this.gameObject.name.ToString();

        switch (name)
        {
            case "Mushroom":
                gameManager.addInventory(gameManager.ingred_inventory, "버섯", 5);

                break;
            case "Wood":
                gameManager.addInventory(gameManager.ingred_inventory, "나무", 5);

                break;
            case "Apple":
                gameManager.addInventory(gameManager.ingred_inventory, "사과", 5);

                break;
        }
        Debug.Log(name);
    }
}
