using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;

    private NavMeshAgent agent;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    PlayerMove player;

    public bool isPlayerFound;
    float h;
    float v;
    bool isHorizonMove;
    bool isblocked;

  

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        agent = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody2D>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        h = rigid.velocity.x;
        v = rigid.velocity.y;
        if (h!=0)
            isHorizonMove = true;
        else if (v!=0)
            isHorizonMove = false;
        */
        //Check player on trap
        if (player.isEnemyZone)
        {
            isPlayerFound = true;
        }
        else isPlayerFound = false;

        if (isblocked)
        {
            getBack();
            isblocked = false;
            isHorizonMove = true;
        }

        
    }
    void FixedUpdate()
    {
        if (isPlayerFound) agent.SetDestination(target.position);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Trap")
        {
            isblocked = true;
        }
    }

    void getBack()
    {
        rigid.position = isHorizonMove ?
            new Vector2(rigid.position.x - 2f , rigid.position.y) : new Vector2(rigid.position.x, rigid.position.y - 2f);
    }
}
