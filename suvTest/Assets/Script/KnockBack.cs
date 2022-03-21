using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public GameObject effect;

    private GameObject player;
    private float time;
    private SphereCollider range;

    private float degree;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        time = 3.0f;
        range = GetComponent<SphereCollider>();
        range.enabled = false;

        degree = 1;
    }

    
    void Update()
    {
        time -= Time.deltaTime;

        if(time < 0)
        {
            time = 3;
            StartCoroutine(Visible());
        }
    }

    public IEnumerator Visible()
    {
        range.enabled = true;
        GameObject particle = Instantiate(effect, gameObject.transform) as GameObject;
        yield return new WaitForSeconds(0.3f);

        range.enabled = false;
    }

    private float Knockdegree(Vector3 enemyPos)
    {
        float dir = (enemyPos - player.transform.position).magnitude;

        return range.radius - dir;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            float dir = Knockdegree(other.transform.position);
            other.gameObject.GetComponent<EnemyController>().KnockBack(dir * degree, 7, dir * degree);
        }
    }

    public void UpdateLV(int level)
    {
        degree = level;
    }
}
