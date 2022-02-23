using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taunt : MonoBehaviour
{
    public GameObject tauntPrefab;
    private GameObject player;

    public float coolTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coolTime = 5.0f;
    }

    
    void Update()
    {
        coolTime -= Time.deltaTime;

        if(coolTime < 0)
        {
            GameObject turret = Instantiate(tauntPrefab, new Vector3(player.transform.position.x, -0.5f, player.transform.position.z), player.transform.rotation) as GameObject;
            coolTime = 5.0f;
        }
    }
}
