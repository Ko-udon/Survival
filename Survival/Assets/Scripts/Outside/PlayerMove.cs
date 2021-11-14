using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    public bool isFarming;
    public bool isFarmDone;
    public bool isblocked;
    private int farmingTimer;
   /// public GameObject farm;
   /// public GameObject farmClean;
    //public GameObject AIR;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    float h;
    float v;
    bool isHorizonMove;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        Speed = 3.0f;

        isFarming = false;
        isblocked = false;
        isFarmDone = false;
        farmingTimer = 0;


    }

    // Update is called once per frame
    void Update()
    {
        //Move Value
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //Check Button Down & Up
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        //Check Horizontal Move
        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        //Animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
            anim.SetBool("isChange", false);

        //Trap에 의해 막혔는지 체크
        if (isblocked)
        {
            getBack();
            isblocked = false;
        }

        //Farming 타일에 Player 있는지 체크
        if (isFarming)
        {
            if (farmingTimer > 300)
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


    // Update is called once per frame
    void FixedUpdate() //1초에 50번 정도 받음
    {
        //좌우움직임이면 (h,0) 상하면 (0,v) 대각선 안됨
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;

        
    }


    //item 획득 획득한 파밍존은 어두워짐
    void getItem()
    {
        int item = 3;
        //farmClean.gameObject.SetActive(true);
        //farm.gameObject.SetActive(false);
        Debug.Log("item획득" + item);
    }

    //함정에 닿으면 오던 방향으로 튕겨짐
    void getBack()
    {
        rigid.position = isHorizonMove ? 
            new Vector2(rigid.position.x - 2f * h, rigid.position.y) : new Vector2(rigid.position.x, rigid.position.y - 2f * v);
    }

    //함정에 닿았는지 Collision 체크
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            isblocked = true;
        }

    }

    //파밍존 들어가면 파밍 시작 (이미 파밍된 곳은 파밍 불가능)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Farming")
        {
            if (!isFarmDone) isFarming = true;
        }
    }

    //파밍존 나가면 카운트 리셋
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Farming")
        {
            isFarming = false;
            farmingTimer = 0;
        }
    }
}
