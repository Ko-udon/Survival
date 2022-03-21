using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public float time;
    private float cooltime;
    private List<Collider> enemy;
    private SphereCollider range;

    public GameObject poisonPrefab;

    void Start()
    {
        cooltime = 3.0f;
        enemy = new List<Collider>();
        range = GetComponent<SphereCollider>();

        range.enabled = false;
    }

    void Update()
    {
        time -= Time.deltaTime;
        cooltime -= Time.deltaTime;

        if(time < 0)
        {
            gameObject.transform.parent.GetComponent<EnemyController>().isPosion = false;
            Destroy(gameObject);
        }

        if(cooltime < 0)
        {
            StartCoroutine(Visible());
            cooltime = 3.0f;
        }
    }

    public IEnumerator Visible()
    {
        enemy.Clear();
        range.enabled = true;
        yield return new WaitForSeconds(0.3f);

        foreach (Collider other in enemy)
        {
            if (!other.gameObject.GetComponent<EnemyController>().isPosion)
            {
                other.gameObject.GetComponent<EnemyController>().isPosion = true;
                GameObject poison = Instantiate(poisonPrefab, other.gameObject.transform.position, other.gameObject.transform.rotation, other.gameObject.transform) as GameObject;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (!enemy.Contains(other))
            {
                enemy.Add(other);
            }
        }
    }
}
