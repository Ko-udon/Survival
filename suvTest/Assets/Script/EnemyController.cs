using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private Vector3 target;
    private Material material;

    public GameObject bullet;
    public Transform front;
    public float atkSpeed;
    private bool isDelay;
    

    private bool isGround;
    private bool isStiff;

    public float speed;
    public float Hp;
    public float attackRange;

    public bool isPosion;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        material = gameObject.GetComponent<Renderer>().material;

        isPosion = false;
        isGround = true;
        isStiff = false;
        Hp = 100;
        

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] turret = GameObject.FindGameObjectsWithTag("Turret");

        if(turret.Length > 0)
        {
            target = new Vector3(turret[0].transform.position.x, 0, turret[0].transform.position.z);
        }
        else
        {
            target = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        }

        if(isPosion)
        {
            Hp -= 20 * Time.deltaTime;
        }

        if(Hp > 0)
        {
            if(isGround && !isStiff)
            {
                if((target - transform.position).magnitude > attackRange)
                {
                    transform.LookAt(target);
                    Vector3 dir = (target - transform.position).normalized;
                    transform.position += new Vector3(dir.x, 0, dir.z) * speed * Time.deltaTime;
                }
                else
                {
                    if (attackRange > 3)
                    {
                        if (isDelay == false)
                        {
                            isDelay = true;
                            StartCoroutine("RangeAttack");
                        }
              

                    }
                    else
                    {
                        //근거리의 경우
                    }
                    //이동을 멈추고 공격
                   

                }
            }
        }
        else
        {
            Destroy(this.gameObject);
        }

        material.SetColor("_Color", new Color(1, 1 - (0.01f * Hp), 1 - (0.01f * Hp)));

        if(transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "floor")
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

        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        isStiff = false;
    }

    public void KnockBack(float x, float y, float z)
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3((transform.position.x - target.x) * x, y, (transform.position.z - target.z) * z), ForceMode.Impulse);
        isGround = false;
    }

    public IEnumerator RangeAttack()
    {   
      
        GameObject Bullet = Instantiate(bullet, front.position, front.rotation);
        yield return new WaitForSeconds(atkSpeed);
        isDelay = false;
    }

}
