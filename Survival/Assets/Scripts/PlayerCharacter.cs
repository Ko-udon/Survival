using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
    public static PlayerCharacter player;

    public GameObject playerUI;

    public int enemyType;
    public float Hp;
    public float Mt;
    public float totalAir;
    public float Air;

    public int power;
    public int AtkDamage;
    public int defense;
    public int accuracy;
    public int avoid;
    public int critical;
    public int speed;

    public bool isDead;
    public bool isRun;
    public bool isAttack;
    public bool isCritical;
    public bool canMove;
    public bool isBattle;
    public bool isHome;

    public bool endBattle;

    public int exp;

    public string booty_item;
    

    public Image HpBar;
    public Text damage_player_text;
    public Text causeDeathText;

    Rigidbody2D rigid;

    CapsuleCollider2D capsuleCol;
    public EnemyCharacter enemy;

    
    public bool isWin;
    public int enemyCount;
    // Start is called before the first frame update


    //playerMove

    public float maxSpeed;
    public bool isFarming;
    public bool isFarmDone;
    public bool isblocked;
    private int farmingTimer;
    //public GameObject farm;
    //public GameObject farmEnd;
    //public GameObject AIR;

    SpriteRenderer spriteRenderer;
    Animator anim;

    void Awake() 
    {
        if (player == null)
            player = this;

        else if (player != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        rigid = GetComponent<Rigidbody2D>();
        capsuleCol=GetComponent<CapsuleCollider2D>();
        AtkDamage = power;
        canMove = true;
        isAttack = true;

        //playerMove
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        //farmEnd.gameObject.SetActive(false);

        maxSpeed = 1.0f;

        isFarming = false;
        isblocked = false;
        isFarmDone = false;
        farmingTimer = 0;
        

        //수정...
        
        
    }
    void Start()
    {
        
    }
    public void getVictoryReward()
    {
        exp+=enemy.exp;
        booty_item=enemy.booty_item;
        isWin=true;
        
        Debug.Log("경험치");
        Debug.Log(exp);
        Debug.Log("전리품");
        Debug.Log(booty_item);
    }

    void getRunPenalty()
    {
        Mt=Mt-5;
    }

    void decreaseAir()
    {
        Air -= Time.deltaTime;
    }
    void checkDead()
    {
        if (Hp <= 0)
        {
            isDead = true;
            //Time.timeScale=0;
            StartCoroutine("showDeathText","체력");
            //gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        else if(Mt<=0){
            isDead=true;
            StartCoroutine("showDeathText","멘탈");
        }
        else if(Air<=0){
            isDead=true;
            
            StartCoroutine("showDeathText","공기");
            
            
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
    IEnumerator showDeathText(string cause)
    {
        causeDeathText.gameObject.SetActive(true);
        causeDeathText.text=cause+"로 인해 사망하였습니다!....";
        canMove=false;
        //isTrigger 비활성화 및 이동 제한
        capsuleCol.isTrigger=true;
        rigid.constraints = RigidbodyConstraints2D.FreezePositionY; 
        rigid.constraints = RigidbodyConstraints2D.FreezePositionX; 
        gameObject.GetComponent<PlayerMove>().enabled=false;

        yield return new WaitForSeconds(4.0f);
        causeDeathText.gameObject.SetActive(false);
        
        gameObject.SetActive(false);
        
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
        if (other.gameObject.tag == "trap")
        {
            isblocked = true;
        }


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
            isWin=false;
            getRunPenalty();
        }

        else if (other.gameObject.tag=="EnemyType_1")
        {
            
            enemyType=1;
            
            enemyCount++;

            isBattle=true;
            

            //전투시 오른쪽 방향
            //anim.SetInteger("hAxisRaw",1);
            //anim.SetInteger("hAxisRaw",-1);
            //anim.SetBool("isChange",false);

            //this.spriteRenderer.sprite=rightSprite;
            
        }

        else if (other.gameObject.tag=="EnemyType_2")
        {
            //this.spriteRenderer.sprite=rightSprite;
            enemyType=2;
            
            enemyCount++;

            isBattle=true;
            // anim.SetInteger("hAxisRaw",1);
            // anim.SetInteger("hAxisRaw",-1);
            // anim.SetBool("isChange",false);
            //this.spriteRenderer.sprite=rightSprite;
            
        }

        else if(other.gameObject.tag=="EnemyBlock")
        {
            endBattle=true;
            isWin=true;
            
        }

        else if(other.gameObject.tag=="Home")
        {
            isHome=true;

            
        }

        else if(other.gameObject.tag=="trap")
        {
            isblocked=true;
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
            if ((isBattle==false)&(SceneManager.GetActiveScene().name=="Outside"))
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.Translate(Vector3.up * speed * Time.deltaTime);
                    //anim.SetBool("isWalking", true);

                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Translate(Vector3.down * speed * Time.deltaTime);
                    //anim.SetBool("isWalking", true);

                }    
            }
            
        }


    }

    // Update is called once per frame
    void Update()
    {
        Move();
        checkDead();
        //decreaseAir();
        

        if(SceneManager.GetActiveScene().name=="Battle"){
            gameObject.GetComponent<PlayerMove>().enabled=false;
            
            if(GameObject.FindGameObjectWithTag("Enemy")!=null){
                enemy=GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyCharacter>();
            }
            decreaseAir();
            playerUI.SetActive(true);
            rigid.gravityScale=1;
        }


        if(SceneManager.GetActiveScene().name=="Outside"){
            gameObject.GetComponent<PlayerMove>().enabled=true;
            playerUI.SetActive(false);
            decreaseAir();
            rigid.gravityScale=0;
            
        }

        if(SceneManager.GetActiveScene().name=="Home"){
            playerUI.SetActive(false);
            
            rigid.gravityScale=0;
        }
        
        if (isblocked)
        {
            getBack();
            isblocked = false;
        }
        if (isFarming)
        {
            if (farmingTimer > 3000)
            {
                Invoke("getItem", 3);
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

    //playerMove
    void getItem()
    {
        int item = 3;
        //farmEnd.gameObject.SetActive(true);
        //farm.gameObject.SetActive(false);
        Debug.Log("itemȹ��" + item);
    }
    void getBack()
    {
        rigid.position = new Vector2(rigid.position.x - 2.5f, rigid.position.y);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "farm")
        {
            if (!isFarmDone) isFarming = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "farm")
        {
            isFarming = false;
            farmingTimer = 0;
        }
    }
}
