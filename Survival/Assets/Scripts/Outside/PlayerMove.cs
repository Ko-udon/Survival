using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    public bool isFarming;
    public bool isFarmDone;
    public bool isblocked;
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
        // if(SceneManager.GetActiveScene().name=="Battle"){
        //     gameObject.GetComponent<PlayerMove>().enabled=false;
        // }

        // if(SceneManager.GetActiveScene().name=="Battle"){
        //     gameObject.GetComponent<PlayerMove>().enabled=true;
        // }

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

        //Trap�� ���� �������� üũ
        if (isblocked)
        {
            getBack();
            isblocked = false;
        }

        //Farming Ÿ�Ͽ� Player �ִ��� üũ
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
    void FixedUpdate() //1�ʿ� 50�� ���� ����
    {
        //�¿�������̸� (h,0) ���ϸ� (0,v) �밢�� �ȵ�
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;

        
    }


    //item ȹ�� ȹ���� �Ĺ����� ��ο���
    void getItem()
    {
        int item = 3;
        //farmClean.gameObject.SetActive(true);
        //farm.gameObject.SetActive(false);
        Debug.Log("item111" + item);
    }

    //������ ������ ���� �������� ƨ����
    void getBack()
    {
        rigid.position = isHorizonMove ? 
            new Vector2(rigid.position.x - 2f * h, rigid.position.y) : new Vector2(rigid.position.x, rigid.position.y - 2f * v);
    }

    //������ ��Ҵ��� Collision üũ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            isblocked = true;
        }
    }

    //�Ĺ��� ���� �Ĺ� ���� (�̹� �Ĺֵ� ���� �Ĺ� �Ұ���)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Farming")
        {
            if (!isFarmDone) isFarming = true;
        }
    }

    //�Ĺ��� ������ ī��Ʈ ����
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Farming")
        {
            isFarming = false;
            farmingTimer = 0;
        }
    }
}
