using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyCharacter : MonoBehaviour
{
    public int Hp;


    public int power;
    public int AtkDamage;
    public int defense;
    public int accuracy;
    public int avoid;
    public int critical;
    public int speed;

    private bool isDead;
    private bool isRun;
    public bool isAttack;
    public bool isCritical;
    public bool canMove;


    Rigidbody2D rigid;
    PlayerCharacter player;
    public Image HPbar;
    public Text damage_enemy_text;

    public GameObject booty;
    public string booty_item;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        canMove = true;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerCharacter>();
    }
    void Enemy_Move()
    {
        if (canMove == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
    }

    void Dead()
    {
        if (Hp <= 0)
        {
            isDead = true;
            Instantiate(booty,new Vector2(gameObject.transform.position.x+1,gameObject.transform.position.y),Quaternion.identity);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
    IEnumerator destroy_text()
    {

        damage_enemy_text.gameObject.SetActive(true);
        damage_enemy_text.text = "-" + (player.AtkDamage - defense).ToString() + "\n";
        yield return new WaitForSeconds(1.0f);
        damage_enemy_text.gameObject.SetActive(false);
        //damage_enemy_text.gameObject.SetActive(false);

    }
    IEnumerator StopMove()
    {
        canMove = false;
        yield return new WaitForSeconds(0.8f);
        //Debug.Log(1);
        canMove = true;
    }
   
    void Nulkback()
    {
        rigid.AddForce(new Vector2(player.speed * 50, player.speed * 50));
        StartCoroutine("StopMove");
    }
    void GetDamage()
    {
        if (player.isAttack == true)
        {
            
            if (player.isCritical == true)
            {
                if ((player.AtkDamage - defense) <= 0)
                {
                    //Hp = Hp;
                    HPbar.fillAmount = (float)Hp / 100;
                    
                    StartCoroutine("destroy_text");
                }
                else
                {
                    Hp = Hp - (player.AtkDamage - defense);
                    HPbar.fillAmount = (float)Hp / 100;
                    StartCoroutine("destroy_text");
                }

            }
            
            else
            {
                if ((player.AtkDamage - defense) <= 0)
                {
                    //Hp = Hp;
                    HPbar.fillAmount = (float)Hp / 100;
                    StartCoroutine("destroy_text");
                }
                else
                {
                    Hp = Hp - (player.AtkDamage - defense);
                    HPbar.fillAmount = (float)Hp / 100;
                    StartCoroutine("destroy_text");
                }
            }
                        
            //Hp = Hp - (player.AtkDamage - defense);
            /*Hp -= 100;
            HPbar.fillAmount = (float)Hp / 100;*/

        }
        Nulkback();

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isAttack = true;
            //rigid.AddForce(Vector3.right * player.speed * 20);
            GetDamage();

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_Move();
        Dead();
    }
}
