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
    public Image monsterImage;
    public Text damageText;
    public Text missText;
    public Text criticalDamageText;



    //public GameObject booty;
    public string booty_item;
    public int exp;

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
            //Instantiate(booty,new Vector2(gameObject.transform.position.x+1,gameObject.transform.position.y),Quaternion.identity);
            player.getVictoryReward();
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
    void checkAttack()
    {
        float check;
        if((accuracy - player.avoid + 30)>=100){
            //무조건 공격 성공
            check = 100;
        }

        else{
            check = (accuracy - player.avoid + 30) % 100;
        }
        
        
        int tmp=Random.Range(1,101);  //1~100

        if(tmp<=check){
            isAttack=true;
        }
        else if(tmp>check){
            isAttack=false;
        }
    }

    void checkCritical()
    {
        float check;
        
        check = critical;

        int tmp=Random.Range(1,101);  //1~100

        if(tmp<=check){
            isCritical=true;
        }
        else if(tmp>check){
            isCritical=false;
        }
        
    }

    IEnumerator textDamage()
    {

        damageText.gameObject.SetActive(true);
        damageText.text = "-" + (player.AtkDamage - defense).ToString() + "\n";
        yield return new WaitForSeconds(1.0f);
        damageText.gameObject.SetActive(false);
        //damage_enemy_text.gameObject.SetActive(false);

    }
    IEnumerator textMiss()
    {
        missText.gameObject.SetActive(true);
        missText.text="Miss";
        yield return new WaitForSeconds(1.0f);
        missText.gameObject.SetActive(false);
    }

    IEnumerator textCritical(int damage)
    {
        criticalDamageText.gameObject.SetActive(true);
        criticalDamageText.text="-"+damage.ToString()+"\n";
        yield return new WaitForSeconds(1.0f);
        criticalDamageText.gameObject.SetActive(false);
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
                    //공격도 맞고 크리티컬이지만 방어력이 높아 데미지0인 경우
                    int damage=0;
                    HPbar.fillAmount = (float)Hp / 100;
                    StartCoroutine("textDamage",damage);
                }
                else
                {
                    //공격도 맞고 크리티컬 데미지 입은 경우
                    //(enemy.AtkDamage - defense)
                    int damage=player.AtkDamage-defense;
                    Hp = Hp - damage;
                    HPbar.fillAmount = (float)Hp / 100;
                    StartCoroutine("textCritical",damage);
                }

            }
            
            else
            {
                if ((player.AtkDamage - defense) <= 0)
                {
                    int damage=0;
                    HPbar.fillAmount = (float)Hp / 100;
                    StartCoroutine("textDamage",damage);
                }
                else
                {
                    int damage=player.AtkDamage-defense;
                    Hp = Hp - damage;
                    HPbar.fillAmount = (float)Hp / 100;
                    StartCoroutine("textDamage",damage);
                }
            }
                        
            //Hp = Hp - (player.AtkDamage - defense);
            /*Hp -= 100;
            HPbar.fillAmount = (float)Hp / 100;*/

        }
        else 
        //공격을 회피한 경우
        {
            StartCoroutine("textMiss");

        }
        Nulkback();

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            checkAttack();
            checkCritical();
           if (isAttack == true)
            {
                if (isCritical == true)
                {
                    AtkDamage = (int)(power * 1.5);
                    
                }
                else
                {
                    AtkDamage = power;
                   
                }
            }
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
