using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taunt : MonoBehaviour
{
    public GameObject tauntPrefab;
    public List<float> durationByLV;
    private GameObject player;

    public float coolTime;
    private float duration;
    private int level;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coolTime = 5.0f;
        duration = 2.5f;
    }

    
    void Update()
    {
        coolTime -= Time.deltaTime;

        if(coolTime < 0)
        {
            float randomX = Random.Range(-1.0f, 1.0f);
            float randomZ = Random.Range(-1.0f, 1.0f);

            if(randomX < 0)
            {
                randomX = -1;
            }
            else
            {
                randomX = 1;
            }

            if (randomZ < 0)
            {
                randomZ = -1;
            }
            else
            {
                randomZ = 1;
            }

            GameObject turret = Instantiate(tauntPrefab, new Vector3(player.transform.position.x + 3 * randomX, -1, player.transform.position.z + 3 * randomZ), player.transform.rotation) as GameObject;
            turret.GetComponent<Turret>().time = duration;
            coolTime = 5.0f;
        }
    }

    public void UpdateLV(int level)
    {
        if(level > durationByLV.Count)
        {
            return;
        }

        this.level = level;
        duration = durationByLV[this.level - 1];
    }
}
