using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
    public static PlayerCharacter player;

    public List<int> met_enemy_list;
    public List<int> enemy_kill_list;

    public GameObject playerUI;
    public GameObject farmingUI;

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
    public float critical;
    public int speed;

    public bool isDead;
    public bool isRun;
    public bool isAttack;
    public bool isCritical;
    public bool canMove;
    public bool isBattle;
    public bool isHome;
    public bool isReward;

    public bool endBattle;

    public int exp;

    public string booty_item;
    

    public Image HpBar;
    public Image FarmingBar;

    public Text normalDamageText;

    public Text criticalDamageText;
    public Text missText;

    public Text causeDeathText;

    Rigidbody2D rigid;

    CapsuleCollider2D capsuleCol;
    public EnemyCharacter enemy;

    
    public bool isWin;
    public bool killenemy;
    public int enemyCount;

    public int killCount;

    public Vector2 playerPos;
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
        killCount++;
        killenemy=true;
        isWin=true;
        enemy_kill_list.Add(1);
        isReward=true;
        // Debug.Log("경험치");
        // Debug.Log(exp);
        // Debug.Log("전리품");
        // Debug.Log(booty_item);
    }

    void getRunPenalty()
    {
        Mt=Mt-5;
        enemy_kill_list.Add(0);
    }

    void decreaseAir()
    {
        Air -= Time.deltaTime;
    }
    void checkDead()
    {
        if (Hp <= 0)
        {
            
            //player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            Invisible(0.4f*Time.deltaTime);
           
           
            isDead = true;
            //Time.timeScale=0;
            StartCoroutine("showDeathText","체력");
            //gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        else if(Mt<=0){
            //player.transform.rotation = new Quaternion(0, 0, 45, 0);
            Invisible(0.2f);
            isDead =true;
            StartCoroutine("showDeathText","멘탈");
        }
        else if(Air<=0){
            //player.transform.rotation = new Quaternion(0, 0, 45, 0);
            Invisible(0.2f);
            isDead =true;
            
            StartCoroutine("showDeathText","공기");
            
            
        }
    }
    void checkAttack()
    {
        float check=1;
        check = (accuracy - enemy.avoid + 30) / 100 * ((int)Air / totalAir)*100; //%연산을 위한 *100
        
        
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
        check = (critical / 100)*(totalAir / Air)*100;  //%연산을 위한 *100
        //Debug.Log((int)check); 10%

        int tmp=Random.Range(1,101);  //1~100

        if(tmp<=check){
            isCritical=true;
        }
        else if(tmp>check){
            isCritical=false;
        }
        
    }
    IEnumerator textDamage(int damage)
    {

        normalDamageText.gameObject.SetActive(true);
        normalDamageText.text = "-" + damage.ToString() + "\n";
        yield return new WaitForSeconds(1.0f);
        normalDamageText.gameObject.SetActive(false);   
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
                    //공격도 맞고 크리티컬이지만 방어력이 높아 데미지0인 경우
                    int damage=0;
                    HpBar.fillAmount = (float)Hp / 100;
                    /*rigid.AddForce(new Vector2(0,enemy.speed * 20));*/
                    StartCoroutine("textDamage",damage);
                }
                else
                {
                    //공격도 맞고 크리티컬 데미지 입은 경우
                    //(enemy.AtkDamage - defense)
                    int damage=enemy.AtkDamage-defense;
                    Hp = Hp - damage;
                    HpBar.fillAmount = (float)Hp / 100;
                    StartCoroutine("textCritical",damage);
                }
               
            }
            else
            {
                //공격은 맞고 크리티컬 데미지는 아니지만 방어력이 높아 데미지0인 경우
                if ((enemy.AtkDamage - defense) <= 0)
                {
                    //Hp = Hp;
                    int damage=0;
                    HpBar.fillAmount = (float)Hp / 100;
                    StartCoroutine("textDamage",damage);
                }
                else
                {
                    //공격은 맞고 크리티컬 데미지는 아닌 경우
                    int damage=enemy.AtkDamage-defense;
                    Hp = Hp - damage;
                    HpBar.fillAmount = (float)Hp / 100;
                    StartCoroutine("textDamage",damage);
                }
            }
        }
        else 
        //공격을 회피한 경우
        {
            StartCoroutine("textMiss");

        }

        Nulkback();

    }

    void PlayerAvoid()
    {

    }

    void Invisible(float i)
    {
        player.spriteRenderer.color = new Color(255, 255, 255, player.spriteRenderer.color.a - i);
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
            killCount=0;
            getRunPenalty();
        }

        else if (other.gameObject.tag=="EnemyType_1")
        {
            
            enemyType=1;
            
            enemyCount++;

            isBattle=true;
            met_enemy_list.Add(1);

            
        }

        else if (other.gameObject.tag=="EnemyType_2")
        {
            //this.spriteRenderer.sprite=rightSprite;
            enemyType=2;
            
            enemyCount++;

            isBattle=true;
            met_enemy_list.Add(2);

            
        }
        

        else if(other.gameObject.tag=="EnemyBlock")
        {
            endBattle=true;
            killCount=0;
            //isWin=true;
            
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

    public void SavePlayerPos(float xpos, float ypos)
    {
        playerPos=new Vector2(player.transform.position.x+xpos,player.transform.position.y+ypos);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        checkDead();
        Farming();
        //decreaseAir();
        

        if(SceneManager.GetActiveScene().name=="Battle"){
            gameObject.GetComponent<PlayerMove>().enabled=false;
            if(isDead==true)
            {
                rigid.gravityScale = -1.5f;
                playerUI.SetActive(false);
            }
            else
            {
                rigid.gravityScale = 1;
                playerUI.SetActive(true);
            }
            
            if(GameObject.FindGameObjectWithTag("Enemy")!=null){
                enemy=GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyCharacter>();
            }
            decreaseAir();
            
            
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
                Debug.Log("아이템 획득");

            }

            else
            {
                farmingTimer++;
                //Debug.Log(farmingTimer);
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

  
    
    public void Farming()
    {
        if(isFarming==true)
        {
            //StartCoroutine("FarmingUI");
            farmingUI.SetActive(true);
            FarmingBar.fillAmount = FarmingBar.fillAmount + Time.deltaTime * 0.5f;
        }
        else
        {
            farmingUI.SetActive(false);
            FarmingBar.fillAmount = 0;
        }
    }
}
