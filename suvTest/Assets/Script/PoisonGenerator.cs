using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonGenerator : MonoBehaviour
{
    private List<Collider> enemy;
    private SphereCollider range;

    public GameObject poisonPrefab;

    private float time;
    private float duration;

    void Start()
    {
        time = 6.0f;
        duration = 3.5f;
        enemy = new List<Collider>();
        range = GetComponent<SphereCollider>();

        range.enabled = false;
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time < 0)
        {
            StartCoroutine(Visible());
            time = 6.0f;
        }
    }

    public IEnumerator Visible()
    {
        enemy.Clear();
        range.enabled = true;
        yield return new WaitForSeconds(0.1f);

        foreach(Collider other in enemy)
        {
            if(!other.gameObject.GetComponent<EnemyController>().isPosion)
            {
                other.gameObject.GetComponent<EnemyController>().isPosion = true;
                GameObject poison = Instantiate(poisonPrefab, other.gameObject.transform.position, other.gameObject.transform.rotation, other.gameObject.transform) as GameObject;
                poison.GetComponent<Poison>().time = duration;
            }
        }
        range.enabled = false;
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

    public void UpdateLV(int level)
    {
        duration = 3.5f * level;
    }
}
