using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    public bool isFarming;
    public bool isFarmDone;
    public bool isblocked;
    public bool isEnemyZone;
    private int farmingTimer;
    // public GameObject farm;
    // public GameObject farmClean;
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
            anim.SetBool("isChange", false);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", false);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
            anim.SetBool("isChange", true);
        //Check player on trap
        if (isblocked)
        {
            getBack();
            isblocked = false;
        }

        //Check player on farming zone
        /*if (isFarming)
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
        }*/
    }

    private void Move(Vector2 inputDirection)
    {
        /*
        Vector2 moveInput = inputDirection;

        bool isMove = moveInput.magnitude != 0;
        */
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
           
    }


    // Update is called once per frame
    void FixedUpdate() //50times per second
    {
        //left,right(Horizental) (h,0) up,down(Vertical) (0,v) Can't move daegaksun 
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;

        
    }


    //Geting item 
    void getItem()
    {
        int item = 3;
        //farmClean.gameObject.SetActive(true);
        //farm.gameObject.SetActive(false);
        Debug.Log("item111" + item);
    }

    //When player on trap, it make move back 1 tiles
    void getBack()
    {
        rigid.position = isHorizonMove ? 
            new Vector2(rigid.position.x - 2f * h, rigid.position.y) : new Vector2(rigid.position.x, rigid.position.y - 2f * v);
    }

    //Collison
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            isblocked = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyZone")
        {
            if (!isEnemyZone) isEnemyZone = true;
        }
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyZone")
        {
            isEnemyZone = false;
        }
    }
}
