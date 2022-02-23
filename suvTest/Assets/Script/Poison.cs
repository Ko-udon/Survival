using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    private float time;
    private List<Collider> enemy;
    private SphereCollider range;

    public GameObject poisonPrefab;

    void Start()
    {
        time = 3.0f;
        enemy = new List<Collider>();
        range = GetComponent<SphereCollider>();

        range.enabled = false;
    }

    void Update()
    {
        time -= Time.deltaTime;

        if(time < 0)
        {
            StartCoroutine(Visible());
            time = 3.0f;
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

        gameObject.transform.parent.GetComponent<EnemyController>().isPosion = false;
        Destroy(gameObject);
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
