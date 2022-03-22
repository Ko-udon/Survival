using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefeb;
    public GameObject rangeEnemy;

    private int spawnType;
    private float time = 1.5f;

    void Start()
    {
        
    }

    void Update()
    {
        time -= Time.deltaTime;
        spawnType = Random.Range(1, 3);
        if(time < 0)
        {
            if (spawnType == 1)
            {
                GameObject enemy = Instantiate(enemyPrefeb) as GameObject;
                float posX = Random.Range(-10.0f, 10.0f);
                float posZ = Random.Range(-10.0f, 10.0f);
                enemy.transform.position = new Vector3(posX, 0, posZ);

                time = 1.5f;
            }
            else if (spawnType == 2)
            {
                GameObject enemy = Instantiate(rangeEnemy) as GameObject;
                float posX = Random.Range(-10.0f, 10.0f);
                float posZ = Random.Range(-10.0f, 10.0f);
                enemy.transform.position = new Vector3(posX, 0, posZ);

                time = 1.5f;
            }
            /* GameObject enemy = Instantiate(rangeEnemy) as GameObject;
             float posX = Random.Range(-10.0f, 10.0f);
             float posZ = Random.Range(-10.0f, 10.0f);
             enemy.transform.position = new Vector3(posX, 0, posZ);*/

            time = 1.5f;
        }
    }
}
