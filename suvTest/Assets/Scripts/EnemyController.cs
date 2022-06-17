using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private PlayerController PlayerController;
    private Vector3 target;
    private Animator ani;
    public CloseWeapon closeAttack;

    public GameObject bullet;
    public Transform front;
    public float atkSpeed;
    public bool isDelay;

    private bool isGround;
    private bool isStiff;

    public float speed;
    public float Hp;
    public float attackRange;

    public bool isPosion;
    private float atkCooltime;

    public int enemytExp;
    AudioSource audio;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //material = gameObject.GetComponent<Renderer>().material;
        ani = GetComponent<Animator>();
        audio = this.GetComponent<AudioSource>();
        closeAttack = GetComponentInChildren<CloseWeapon>();

        isPosion = false;
        isGround = true;
        isStiff = false;
        isDelay = false;
        Hp = 100;

        atkCooltime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] turret = GameObject.FindGameObjectsWithTag("Turret");

        if(turret.Length > 0)
        {
            target = new Vector3(turret[0].transform.position.x, transform.position.y, turret[0].transform.position.z);
        }
        else
        {
            target = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        }

        if (isPosion)
        {
            Hp -= 20 * Time.deltaTime;
        }

        if(Hp > 0)
        {
            if(isStiff)
            {
                if(ani.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    isStiff = false;
                }
            }

            if(isGround && !isStiff)
            {
                if(!isDelay)
                {
                    LookAtSmooth();
                }

                if ((target - transform.position).magnitude > attackRange && !isDelay)
                {
                    ani.SetBool("move", true);
                    if(closeAttack != null)
                    {
                        closeAttack.AttackUnable();
                    }

                    if (ani.GetCurrentAnimatorStateInfo(0).IsName("Run") || ani.GetCurrentAnimatorStateInfo(0).IsName("Move"))
                    {
                        Vector3 dir = (target - transform.position).normalized;
                        transform.position += new Vector3(dir.x, 0, dir.z) * speed * Time.deltaTime;
                    }
                }
                else
                {
                    ani.SetBool("move", false);

                    if (attackRange > 3)  //���Ÿ�
                    {
                        atkCooltime -= Time.deltaTime;
                        if (atkCooltime < 0)
                        {
                            StartCoroutine("RangeAttack");
                            atkCooltime = atkSpeed;
                        }

                        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Shout"))
                        {
                            isDelay = true;
                        }
                        else
                        {
                            isDelay = false;
                        }


                    }
                    else  //�ٰŸ�
                    {
                        atkCooltime -= Time.deltaTime;

                        if(atkCooltime < 0)
                        {
                            ani.SetTrigger("attack");
                            closeAttack.AttackAble();
                            atkCooltime = atkSpeed;
                        }

                        if(ani.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                        {
                            isDelay = true;
                        }
                        else
                        {
                            isDelay = false;
                        }
                    }
                    //�̵��� ���߰� ����
                   

                }
            }
        }
        else
        {
            ani.SetBool("death", true);
            
            if (closeAttack != null)
            {
                closeAttack.AttackUnable();
            }

            if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                PlayerController.SetExp(enemytExp);  //do once
                Destroy(this.gameObject);
            }
            
            
        }

        //material.SetColor("_Color", new Color(1, 1 - (0.01f * Hp), 1 - (0.01f * Hp)));

        if(transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "floor")
        {
            isGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if(other.tag == "Ball")
        {
            Hp -= 20;
            StartCoroutine(Stiff(1.0f));
        }*/
    }

    public IEnumerator Stiff(float time)
    {
        isStiff = true;
        ani.SetTrigger("hit");
        audio.Play();
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        isStiff = false;
    }

    public void KnockBack(float x, float y, float z)
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3((transform.position.x - target.x) * x, y, (transform.position.z - target.z) * z), ForceMode.VelocityChange);
        isGround = false;
    }

    public IEnumerator RangeAttack()
    {
        ani.SetTrigger("attack");
        yield return new WaitForSeconds(0.7f);

        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Shout"))
        {
            GameObject Bullet = Instantiate(bullet, front.position, front.rotation);
        }
    }

    public IEnumerator CloseAttack()
    {
        ani.SetTrigger("attack");
        yield return new WaitForSeconds(atkSpeed);
    }

    public void LookAtSmooth()
    {
        Quaternion originalRot = transform.rotation;
        transform.LookAt(target);
        Quaternion newRot = transform.rotation;
        transform.rotation = originalRot;
        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, 7 * Time.deltaTime);
    }
}
