using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nautilus : MonoBehaviour
{
    private List<Collider> enemy;
    private SphereCollider range;
    private GameObject player;

    public List<float> damageByLV;
    public GameObject water;

    private float time;
    private float damage;
    private int level;
    private int repeat;

    void Start()
    {
        time = 4.0f;
        damage = 25;
        repeat = 0;
        player = GameObject.FindGameObjectWithTag("Player");
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
            time = 4.0f;
        }
    }

    public IEnumerator Visible()
    {
        enemy.Clear();
        range.enabled = true;
        yield return new WaitForSeconds(0.1f);

        if(enemy.Count != 0)
        {
            int repeatCount;
            if(repeat > enemy.Count)
            {
                repeatCount = enemy.Count;
            }
            else
            {
                repeatCount = repeat;
            }

            for(int i = 0; i < repeatCount; i++)
            {
                int rand = Random.Range(0, enemy.Count);
                GameObject effect = Instantiate(water, player.transform.position, water.transform.rotation);
                effect.GetComponent<Water>().damage = damage;
                Vector3 start = new Vector3(player.transform.position.x, -1, player.transform.position.z);
                Vector3 end = new Vector3(enemy[rand].gameObject.transform.position.x, -1, enemy[rand].gameObject.transform.position.z);
                StartCoroutine(Attack(effect, start, end));
            }
            
            range.enabled = false;
        }
    }

    public IEnumerator Attack(GameObject effect, Vector3 start, Vector3 end)
    {
        effect.transform.position = start;

        while((effect.transform.position - start).magnitude < range.radius)
        {
            effect.transform.position += (end - start).normalized;
            yield return new WaitForSeconds(effect.GetComponent<ParticleSystem>().main.duration / effect.GetComponent<ParticleSystem>().main.simulationSpeed);
        }

        Destroy(effect);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if (!enemy.Contains(other))
            {
                enemy.Add(other);
            }
        }
    }

    public void UpdateLV(int level)
    {
        if(level > damageByLV.Count)
        {
            return;
        }

        if(level == 1)
        {
            repeat = 1;
        }
        else if(level == 3)
        {
            repeat = 2;
        }
        else if(level == 5)
        {
            repeat = 3;
        }

        this.level = level;
        damage = damageByLV[this.level - 1];
    }
}
