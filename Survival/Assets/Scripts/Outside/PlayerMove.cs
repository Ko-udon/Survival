using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
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


    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        maxSpeed = 1.0f;

        isFarming = false;
        isblocked = false;
        isFarmDone = false;
        farmingTimer = 0;


    }

    // Update is called once per frame
    void Update()
    {
        //Speed ∏ÿ√ﬂ¥¬∞≈
        if (Input.GetButton("Horizontal"))
        {
            rigid.velocity = new Vector2(0, 0);
        }
        else if (Input.GetButton("Vertical"))
        {
            rigid.velocity = new Vector2(0, 0);
        }

        //Direction Sprite
        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        if (Input.GetButtonUp("Horizontal"))

            if (rigid.velocity.normalized.x == 0)
            {
                anim.SetBool("isWalking", false);
            }
            else
            {
                anim.SetBool("isWalking", true);
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


    // Update is called once per frame
    void FixedUpdate() //1√ ø° 50π¯ ¡§µµ πﬁ¿Ω
    {
        float h = Input.GetAxisRaw("Horizontal");
        float w = Input.GetAxisRaw("Vertical");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        rigid.AddForce(Vector2.up * w, ForceMode2D.Impulse);


        if (rigid.velocity.x > maxSpeed) // Right Max Speed
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1)) // left Max Speed
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
        else if (rigid.velocity.y < maxSpeed * (-1)) // left Max Speed
        {
            rigid.velocity = new Vector2(rigid.velocity.x, maxSpeed * (-1));
        }
        else if (rigid.velocity.y > maxSpeed) // Right Max Speed
        {
            rigid.velocity = new Vector2(rigid.velocity.x, maxSpeed);
        }
    }



    void getItem()
    {
        int item = 3;
        //farmClean.gameObject.SetActive(true);
        //farm.gameObject.SetActive(false);
        Debug.Log("item»πµÊ" + item);
    }
    void getBack()
    {
        rigid.position = new Vector2(rigid.position.x - 3f, rigid.position.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            isblocked = true;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Farming")
        {
            if (!isFarmDone) isFarming = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Farming")
        {
            isFarming = false;
            farmingTimer = 0;
        }
    }
}
