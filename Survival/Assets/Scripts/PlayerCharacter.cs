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

    private bool isDead;
    public bool isRun;
    public bool isAttack;
    public bool isCritical;
    public bool canMove;
    public bool isBattle;
    public bool isWin;
    public bool isHome;

    public int exp;

    public string booty_item;
    

    public Image HpBar;
    public Text damage_player_text;

    Rigidbody2D rigid;
    public EnemyCharacter enemy;
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
        AtkDamage = power;
        canMove = true;
        isAttack = true;

        



        //playerMove
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        //farmEnd.gameObject.SetActive(false);

        maxSpeed = 1.0f;

        isFarming = false;
        isblocked = false;
        isFarmDone = false;
        farmingTimer = 0;
        
    }
    void Start()
    {
        
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
        if ((Hp <= 0)||(Mt <= 0)||(Air<=0))
        {
            isDead = true;
            Time.timeScale=0;
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

        else if (other.gameObject.tag=="EnemyType_1")
        {
            enemyType=1;
            isBattle=true;
            //SceneManager.LoadScene("Battle");
        }

        else if (other.gameObject.tag=="EnemyType_2")
        {
            enemyType=2;
            isBattle=true;
            //SceneManager.LoadScene("Battle");
        }

        else if(other.gameObject.tag=="EnemyBlock")
        {
            isWin=true;
            //SceneManager.LoadScene("Outside");
        }

        else if(other.gameObject.tag=="Home")
        {
            isHome=true;

            //SceneManager.LoadScene("Home");
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
        Dead();
        //decreaseAir();
        

        if(SceneManager.GetActiveScene().name=="Battle"){
            if(GameObject.FindGameObjectWithTag("Enemy")!=null){
                enemy=GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyCharacter>();
            }
            decreaseAir();
            playerUI.SetActive(true);
            rigid.gravityScale=1;
        }


        if(SceneManager.GetActiveScene().name=="Outside"){
            
            playerUI.SetActive(false);
            decreaseAir();
            rigid.gravityScale=0;
            
        }

        if(SceneManager.GetActiveScene().name=="Home"){
            playerUI.SetActive(false);
            
            rigid.gravityScale=0;
        }




        // //playerMove
        // if (Input.GetButton("Horizontal"))
        // {
        //     rigid.velocity = new Vector2(0, rigid.velocity.y);
        // }
        // else if (Input.GetButton("Vertical"))
        // {
        //     rigid.velocity = new Vector2(rigid.velocity.x, 0);
        // }

        // //Direction Sprite
        // if (Input.GetButton("Horizontal"))
        // {
        //     spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        // }

        // if (Input.GetButtonUp("Horizontal"))

        //     if (rigid.velocity.normalized.x == 0)
        //     {
        //         anim.SetBool("isWalking", false);

        //     }
        //     else
        //     {
        //         anim.SetBool("isWalking", true);
        //     }

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
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "trap")
    //     {
    //         isblocked = true;
    //     }

    // }
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
