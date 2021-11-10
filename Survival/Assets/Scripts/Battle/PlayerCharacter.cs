using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
    public int Hp;
    public int Mt;
    public int totalAir;
    public float Air;

    public int power;
    public int AtkDamage;
    public int defense;
    public int accuracy;
    public int avoid;
    public int critical;
    public int speed;

    private bool isDead;
    public bool isRun;
    public bool isAttack;
    public bool isCritical;
    public bool canMove;
    public bool isBattle;

    public int exp;
    

    public Image HpBar;
    public Text damage_player_text;

    Rigidbody2D rigid;
    public EnemyCharacter enemy;
    // Start is called before the first frame update
    void Awake() 
    {
        
        rigid = GetComponent<Rigidbody2D>();
        AtkDamage = power;
        canMove = true;
        isAttack = true;
        
    }
    void Start()
    {
        if (isBattle==true){
            enemy = GameObject.FindWithTag("Enemy").GetComponent<EnemyCharacter>();           
        }
        else{
            rigid.gravityScale=0;
        }
    }
    void GetVictoryReward()
    {

    }

    void GetRunPenalty()
    {

    }

    void decreaseAir()
    {
        Air -= Time.deltaTime;
    }
    void Dead()
    {
        if ((Hp <= 0)||(Mt <= 0))
        {
            isDead = true;
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
    void checkAttack()
    {
        int check=1;
        //check = (accuracy - avoid + 30) / 100 * ((int)Air / totalAir);
        
        if (check <= 0)
        {
            isAttack = false;
        }
        else
        {
            isAttack = true;
        }
    }

    void checkCritical()
    {
        float check;
        check = (critical / 100) * (totalAir / Air);
        if (check >= 1)
        {
            isCritical = true;
        }
        else
        {
            isCritical = false;
        }

    }
    IEnumerator destroy_text()
    {

        damage_player_text.gameObject.SetActive(true);
        damage_player_text.text = "-" + (enemy.AtkDamage - defense).ToString() + "\n";
        yield return new WaitForSeconds(1.0f);
        damage_player_text.gameObject.SetActive(false);
        //damage_enemy_text.gameObject.SetActive(false);

    }
    void GetDamage()
    {
        if (enemy.isAttack == true)
        {
            if (enemy.isCritical == true)
            {
                if((enemy.AtkDamage - defense) <= 0)
                {
                    //Hp = Hp;
                    HpBar.fillAmount = (float)Hp / 100;
                    /*rigid.AddForce(new Vector2(0,enemy.speed * 20));*/
                    StartCoroutine("destroy_text");
                }
                else
                {
                    Hp = Hp - (enemy.AtkDamage - defense);
                    HpBar.fillAmount = (float)Hp / 100;
                    StartCoroutine("destroy_text");
                }
               
            }
            else
            {
                if ((enemy.AtkDamage - defense) <= 0)
                {
                    //Hp = Hp;
                    HpBar.fillAmount = (float)Hp / 100;
                    StartCoroutine("destroy_text");
                }
                else
                {
                    Hp = Hp - (enemy.AtkDamage - defense);
                    HpBar.fillAmount = (float)Hp / 100;
                    StartCoroutine("destroy_text");
                }
            }
        }
        Nulkback();

    }

    void PlayerAvoid()
    {

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
        rigid.AddForce(new Vector2(-enemy.speed * 20, enemy.speed * 50));

        StartCoroutine("StopMove");

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
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
        else if (other.gameObject.tag == "RunTrigger")
        {
            isRun = true;
        }

        else if (other.gameObject.tag=="EnemyCheck")
        {
            isBattle=true;
            SceneManager.LoadScene("Battle");
        }

    }
    
    void Move()
    {
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }     
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

            //전투씬이 아닌곳에서만 위아래 이동가능 
            if (isBattle==false)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.Translate(Vector3.up * speed * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Translate(Vector3.down * speed * Time.deltaTime);
                }    
            }
            
        }


    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Dead();
        decreaseAir();
        

    }
}
