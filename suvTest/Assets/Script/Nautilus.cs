using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nautilus : MonoBehaviour
{
    private List<Collider> enemy;
    private SphereCollider range;
    private GameObject player;

    public GameObject water;

    private float time;
    private float damage;

    void Start()
    {
        time = 4.0f;
        damage = 25;
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
            int rand = Random.Range(0, enemy.Count);
            GameObject effect = Instantiate(water, player.transform.position, water.transform.rotation);
            effect.GetComponent<Water>().damage = damage;
            Vector3 start = new Vector3(player.transform.position.x, 0, player.transform.position.z);
            Vector3 end = new Vector3(enemy[rand].gameObject.transform.position.x, 0, enemy[rand].gameObject.transform.position.z);
            StartCoroutine(Attack(effect, start, end));
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
        damage = 25 * level;
    }
}
